using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BaseDatos;
using Proyecto_Antonio_Luis.Clases;

namespace Proyecto_Antonio_Luis.Formularios
{
    /// <summary>
    /// Factura directa (serie D): una factura suelta a un cliente dado de alta
    /// o a un cliente ocasional, con tantas líneas como haga falta y el IVA
    /// de cada línea. Se cobran en efectivo: nunca se pasan al banco,
    /// pero sí a contabilidad.
    ///
    /// new FacturaUnitaria()            -> factura nueva
    /// new FacturaUnitaria(factcontador) -> ver una factura ya emitida (solo lectura)
    ///
    /// Una vez emitida, la factura no se puede modificar ni borrar.
    /// </summary>
    public partial class FacturaUnitaria : Form
    {
        private const string TextoSuplido = "Suplido";

        private static readonly CultureInfo Es = new CultureInfo("es-ES");

        /// <summary>Factura que se está viendo, o null si es nueva.</summary>
        private readonly decimal? facturaVista;

        private List<Clientes> clientes = new List<Clientes>();
        private Clientes clienteElegido;
        private bool cargando;

        /// <summary>Tipos de IVA de la tabla Iva.</summary>
        private List<decimal> tiposIva = new List<decimal>();

        /// <summary>% de retención de IRPF (el "por defecto" de la tabla Retenciones).</summary>
        private decimal porcRetencion = 15m;

        /// <summary>Identificador de la factura grabada (para que Gestión de facturas la seleccione).</summary>
        public decimal? FacturaGrabada { get; private set; }

        public FacturaUnitaria()
        {
            InitializeComponent();
        }

        public FacturaUnitaria(decimal factcontador) : this()
        {
            facturaVista = factcontador;
        }

        // =====================================================================
        //  Carga
        // =====================================================================

        private void FacturaUnitaria_Load(object sender, EventArgs e)
        {
            cargando = true;
            try
            {
                using (var bd = new AdministracionAntonioEntities())
                {
                    CargarTiposIva(bd);

                    if (facturaVista.HasValue)
                    {
                        MostrarFactura(bd, facturaVista.Value);
                        return;
                    }

                    clientes = bd.Clientes.AsNoTracking()
                        .Where(c => c.activocliente != false)
                        .OrderBy(c => c.nombrecliente)
                        .ToList();
                }

                comboCliente.DisplayMember = "nombrecliente";
                comboCliente.DataSource = clientes;
                comboCliente.SelectedIndex = -1;
                comboCliente.Text = "";

                dateTimePickerFecha.Value = DateTime.Today;
                ActualizarNumero();
                ModoOcasional(false);
                imprimir.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se han podido cargar los datos:\n" + ex.Message, "Factura directa",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargando = false;
            }
        }

        /// <summary>Rellena el desplegable de IVA de las líneas con los tipos de la tabla Iva.</summary>
        private void CargarTiposIva(AdministracionAntonioEntities bd)
        {
            var tipos = bd.Iva.AsNoTracking()
                .Where(i => i.ivaporciento != null)
                .ToList()
                .GroupBy(i => i.ivaporciento.Value)
                .OrderByDescending(g => g.Key)
                .ToList();

            tiposIva = tipos.Select(g => g.Key).ToList();
            if (!tiposIva.Contains(0)) tiposIva.Add(0);
            porcRetencion = FacturasUtil.PorcentajeRetencion(bd);

            colIva.Items.Clear();
            foreach (var tipo in tiposIva.OrderByDescending(k => k))
            {
                colIva.Items.Add(TextoIva(tipo));
            }
            colIva.Items.Add(TextoSuplido);
        }

        private static string TextoIva(decimal tipo)
        {
            return tipo.ToString("0.##", Es) + " %";
        }

        // =====================================================================
        //  Número provisional
        // =====================================================================

        private void ActualizarNumero()
        {
            if (facturaVista.HasValue) return;
            try
            {
                int año = dateTimePickerFecha.Value.Year;
                using (var bd = new AdministracionAntonioEntities())
                {
                    decimal siguiente = FacturasUtil.SiguienteNumero(bd, FacturasUtil.SerieDirecta, año);
                    labelNumeroFactura.Text = FacturasUtil.Numero(FacturasUtil.SerieDirecta, año, siguiente) + "  (provisional)";
                }
            }
            catch
            {
                labelNumeroFactura.Text = "(se asigna al grabar)";
            }
        }

        private void dateTimePickerFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!cargando) ActualizarNumero();
        }

        // =====================================================================
        //  Cliente
        // =====================================================================

        private void comboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando || checkOcasional.Checked) return;
            PonerCliente(comboCliente.SelectedItem as Clientes);
        }

        private void comboCliente_Leave(object sender, EventArgs e)
        {
            if (checkOcasional.Checked) return;
            // Si se ha escrito el nombre a mano, buscar el cliente exacto
            if (comboCliente.SelectedItem == null && comboCliente.Text.Trim().Length > 0)
            {
                var c = clientes.FirstOrDefault(x =>
                    string.Equals((x.nombrecliente ?? "").Trim(), comboCliente.Text.Trim(), StringComparison.CurrentCultureIgnoreCase));
                if (c != null)
                {
                    comboCliente.SelectedItem = c;
                }
            }
            if (comboCliente.SelectedItem == null)
            {
                PonerCliente(null);
            }
        }

        private void PonerCliente(Clientes c)
        {
            clienteElegido = c;
            if (c == null)
            {
                LimpiarCliente();
                return;
            }
            txtNombre.Text = (c.nombrecliente ?? "").Trim();
            txtNif.Text = (c.cifcliente ?? "").Trim();
            txtDireccion.Text = (c.direcioncliente ?? "").Trim();
            txtCp.Text = (c.cod_postalcliente ?? "").Trim();
            txtLocalidad.Text = (c.localidacliente ?? "").Trim();
            txtProvincia.Text = (c.provinciacliente ?? "").Trim();
            txtMail.Text = (c.mailcliente ?? "").Trim();
            checkContabilizar.Checked = c.contabilizarcliente == true;
            checkRetencion.Checked = c.retencioncliente == true;
            checkPorMail.Checked = c.pormailcliente == true;
            Recalcular();
        }

        private void LimpiarCliente()
        {
            foreach (var t in new[] { txtNombre, txtNif, txtDireccion, txtCp, txtLocalidad, txtProvincia, txtMail })
            {
                t.Text = "";
            }
            checkContabilizar.Checked = true;
            checkRetencion.Checked = false;
            checkPorMail.Checked = false;
            Recalcular();
        }

        private void checkOcasional_CheckedChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            ModoOcasional(checkOcasional.Checked);
        }

        /// <summary>
        /// Cliente ocasional: los datos se escriben a mano.
        /// Cliente dado de alta: se toman de su ficha y no se pueden cambiar aquí.
        /// </summary>
        private void ModoOcasional(bool ocasional)
        {
            comboCliente.Enabled = !ocasional;
            foreach (var t in new[] { txtNombre, txtNif, txtDireccion, txtCp, txtLocalidad, txtProvincia, txtMail })
            {
                t.ReadOnly = !ocasional;
            }
            checkContabilizar.Enabled = ocasional;
            checkRetencion.Enabled = ocasional;
            checkPorMail.Enabled = ocasional;

            if (ocasional)
            {
                cargando = true;
                comboCliente.SelectedIndex = -1;
                comboCliente.Text = "";
                cargando = false;
                clienteElegido = null;
                LimpiarCliente();
                txtNombre.Focus();
            }
            else
            {
                PonerCliente(comboCliente.SelectedItem as Clientes);
            }
        }

        private void checkRetencion_CheckedChanged(object sender, EventArgs e)
        {
            if (!cargando) Recalcular();
        }

        // =====================================================================
        //  Líneas
        // =====================================================================

        private void dataGridLineas_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[colCantidad.Index].Value = "1";
            e.Row.Cells[colIva.Index].Value = colIva.Items.Count > 0 ? colIva.Items[0] : TextoSuplido;
        }

        private void dataGridLineas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Que el cambio en el desplegable de IVA se note al momento
            if (dataGridLineas.IsCurrentCellDirty && dataGridLineas.CurrentCell is DataGridViewComboBoxCell)
            {
                dataGridLineas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridLineas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != colCantidad.Index && e.ColumnIndex != colPrecio.Index) return;
            string texto = Convert.ToString(e.FormattedValue).Replace("€", "").Trim();
            decimal valor;
            if (texto.Length > 0 && !ClientesUtil.LeerDecimal(texto, out valor))
            {
                dataGridLineas.Rows[e.RowIndex].ErrorText = "Escribe un número.";
                e.Cancel = true;
            }
        }

        private void dataGridLineas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var fila = dataGridLineas.Rows[e.RowIndex];
            fila.ErrorText = "";
            if (e.ColumnIndex == colCantidad.Index || e.ColumnIndex == colPrecio.Index)
            {
                decimal valor;
                string texto = Convert.ToString(fila.Cells[e.ColumnIndex].Value).Replace("€", "").Trim();
                if (ClientesUtil.LeerDecimal(texto, out valor) && texto.Length > 0)
                {
                    fila.Cells[e.ColumnIndex].Value = e.ColumnIndex == colCantidad.Index
                        ? valor.ToString("0.###", Es)
                        : valor.ToString("N2", Es);
                }
            }
            Recalcular();
        }

        private void dataGridLineas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!cargando && e.RowIndex >= 0 && e.ColumnIndex == colIva.Index) Recalcular();
        }

        private void dataGridLineas_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (!cargando) Recalcular();
        }

        private void dataGridLineas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        /// <summary>Lee las líneas de la rejilla (las vacías se ignoran).</summary>
        private List<LineaFactura> LeerLineas(bool avisar, out string error)
        {
            error = null;
            var lineas = new List<LineaFactura>();
            foreach (DataGridViewRow fila in dataGridLineas.Rows)
            {
                if (fila.IsNewRow) continue;
                string concepto = Convert.ToString(fila.Cells[colConcepto.Index].Value).Trim();
                string textoCantidad = Convert.ToString(fila.Cells[colCantidad.Index].Value).Trim();
                string textoPrecio = Convert.ToString(fila.Cells[colPrecio.Index].Value).Replace("€", "").Trim();
                string textoIva = Convert.ToString(fila.Cells[colIva.Index].Value);

                if (concepto.Length == 0 && textoPrecio.Length == 0) continue;

                decimal cantidad, precio;
                if (!ClientesUtil.LeerDecimal(textoCantidad.Length == 0 ? "1" : textoCantidad, out cantidad))
                {
                    error = "La cantidad de la línea " + (fila.Index + 1) + " no es válida.";
                    continue;
                }
                if (!ClientesUtil.LeerDecimal(textoPrecio, out precio))
                {
                    error = "El precio de la línea " + (fila.Index + 1) + " no es válido.";
                    continue;
                }
                if (concepto.Length == 0)
                {
                    error = "Falta el concepto de la línea " + (fila.Index + 1) + ".";
                }

                var linea = new LineaFactura
                {
                    Cantidad = cantidad,
                    Concepto = concepto,
                    Precio = precio,
                    Suplido = textoIva == TextoSuplido
                };
                if (!linea.Suplido)
                {
                    decimal tipo;
                    ClientesUtil.LeerDecimal(textoIva.Replace("%", "").Trim(), out tipo);
                    linea.TipoIva = tipo;
                    linea.TipoRecargo = 0;   // los servicios no llevan recargo de equivalencia
                }
                lineas.Add(linea);
            }
            return lineas;
        }

        private void Recalcular()
        {
            string error;
            var lineas = LeerLineas(false, out error);

            foreach (DataGridViewRow fila in dataGridLineas.Rows)
            {
                if (fila.IsNewRow) continue;
                decimal cantidad, precio;
                string textoCantidad = Convert.ToString(fila.Cells[colCantidad.Index].Value).Trim();
                string textoPrecio = Convert.ToString(fila.Cells[colPrecio.Index].Value).Replace("€", "").Trim();
                if (ClientesUtil.LeerDecimal(textoCantidad.Length == 0 ? "1" : textoCantidad, out cantidad)
                    && ClientesUtil.LeerDecimal(textoPrecio, out precio) && textoPrecio.Length > 0)
                {
                    fila.Cells[colImporte.Index].Value =
                        Math.Round(cantidad * precio, 2, MidpointRounding.AwayFromZero).ToString("N2", Es) + " €";
                }
                else
                {
                    fila.Cells[colImporte.Index].Value = "";
                }
            }

            var t = FacturasUtil.Calcular(lineas, PorcActual());
            MostrarTotales(t, t.Retencion);
        }

        /// <summary>% de retención que lleva esta factura (0 si no lleva).</summary>
        private decimal PorcActual()
        {
            return checkRetencion.Checked ? porcRetencion : 0;
        }

        private void MostrarTotales(TotalesFactura t, decimal retencion)
        {
            valorBase.Text = Euros(t.BaseImponible);
            valorIva.Text = Euros(t.CuotaIva);
            valorRetencion.Text = retencion != 0 ? Euros(-retencion) : Euros(0);
            valorSuplidos.Text = Euros(t.Suplidos);
            valorTotal.Text = Euros(t.TotalFactura - retencion + t.Suplidos);

            string desglose = string.Join("   ", t.Desglose.Select(d =>
                TextoIva(d.TipoIva) + ": " + Euros(d.Base) +
                (d.TipoRecargo != 0 ? " (R.E. " + TextoIva(d.TipoRecargo) + ")" : "")));
            labelDesglose.Text = t.Desglose.Count > 1 ? desglose : "";
        }

        private static string Euros(decimal importe)
        {
            return importe.ToString("N2", Es) + " €";
        }

        // =====================================================================
        //  Grabar
        // =====================================================================

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridLineas.EndEdit();

            string error;
            var lineas = LeerLineas(true, out error);
            if (error != null)
            {
                Aviso(error);
                return;
            }
            if (lineas.Count == 0)
            {
                Aviso("La factura no tiene ninguna línea.");
                dataGridLineas.Focus();
                return;
            }

            if (!checkOcasional.Checked && clienteElegido == null)
            {
                Aviso("Elige un cliente de la lista, o marca \"Cliente ocasional\" para escribir sus datos.");
                comboCliente.Focus();
                return;
            }
            if (txtNombre.Text.Trim().Length == 0)
            {
                Aviso("Falta el nombre del cliente.");
                txtNombre.Focus();
                return;
            }
            if (txtNif.Text.Trim().Length == 0)
            {
                Aviso("Falta el NIF del cliente. Es obligatorio en una factura completa.");
                if (checkOcasional.Checked) txtNif.Focus();
                return;
            }
            if (checkPorMail.Checked && txtMail.Text.Trim().Length == 0)
            {
                Aviso("Está marcado \"Por mail\" pero el cliente no tiene email.");
                return;
            }

            var totales = FacturasUtil.Calcular(lineas, PorcActual());
            if (totales.TotalAPagar <= 0)
            {
                Aviso("El total de la factura tiene que ser mayor que cero.\nPara anular o corregir una factura se hará una rectificativa.");
                return;
            }

            DateTime fecha = dateTimePickerFecha.Value.Date;
            int año = fecha.Year;

            try
            {
                using (var bd = new AdministracionAntonioEntities())
                {
                    // Las facturas de una serie van en orden de fecha
                    DateTime? ultimaFecha = bd.Facturas
                        .Where(f => f.factserie == FacturasUtil.SerieDirecta && f.factejercicio == año)
                        .Max(f => f.factfechadoc);
                    if (ultimaFecha.HasValue && fecha < ultimaFecha.Value)
                    {
                        Aviso("La última factura directa de " + año + " tiene fecha " + ultimaFecha.Value.ToString("dd/MM/yyyy") +
                              ".\nLas facturas tienen que ir numeradas en orden de fecha: pon una fecha igual o posterior.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Error("No se ha podido comprobar la numeración", ex);
                return;
            }

            if (fecha > DateTime.Today &&
                MessageBox.Show("La fecha de la factura es posterior a hoy. ¿Seguro?", "Factura directa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }

            string resumen = "Se va a emitir la factura a:\n\n   " + txtNombre.Text.Trim() +
                             "\n\nTotal a pagar: " + Euros(totales.TotalAPagar) +
                             "\n\nUna vez emitida no se puede modificar ni borrar.\n¿Emitir la factura?";
            if (MessageBox.Show(resumen, "Factura directa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            var cliente = new DatosClienteFactura
            {
                Codigo = checkOcasional.Checked || clienteElegido == null ? (decimal?)null : clienteElegido.codcliente,
                Nombre = txtNombre.Text,
                Nif = txtNif.Text,
                Direccion = txtDireccion.Text,
                Localidad = txtLocalidad.Text,
                Provincia = txtProvincia.Text,
                CodigoPostal = txtCp.Text,
                Mail = txtMail.Text,
                PorMail = checkPorMail.Checked,
                Iban = "",             // las facturas directas se cobran en efectivo
                Domiciliar = false,    // nunca se pasan al banco
                Contabilizar = checkContabilizar.Checked,
                PorcRetencion = PorcActual()
            };

            decimal id;
            try
            {
                id = FacturasUtil.GrabarDirecta(cliente, fecha, lineas);
                FacturaGrabada = id;
            }
            catch (Exception ex)
            {
                Error("No se ha podido grabar la factura. No se ha guardado nada", ex);
                return;
            }

            string numero;
            using (var bd = new AdministracionAntonioEntities())
            {
                numero = FacturasUtil.Numero(bd.Facturas.Find(id));
            }

            try
            {
                string ruta = FacturasUtil.GenerarPdf(id, true);
                MessageBox.Show("Factura " + numero + " emitida.\n\nPDF guardado en:\n" + ruta, "Factura directa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Error("La factura " + numero + " está grabada, pero no se ha podido crear el PDF.\n" +
                      "Puedes imprimirla después desde Gestión de facturas", ex);
            }

            if (checkPorMail.Checked)
            {
                EnvioFacturas.PreguntarYEnviar(this, EnvioFacturas.PendientesDeEnviar(new[] { id }),
                    "El cliente recibe las facturas por correo (" + txtMail.Text.Trim() + ").\n\n¿Enviarla ahora?");
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FacturaUnitaria_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (facturaVista.HasValue || DialogResult == DialogResult.OK) return;

            string error;
            bool hayDatos = LeerLineas(false, out error).Count > 0 || txtNombre.Text.Trim().Length > 0;
            if (hayDatos &&
                MessageBox.Show("La factura no se ha emitido. ¿Salir sin grabarla?", "Factura directa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        // =====================================================================
        //  Ver una factura emitida
        // =====================================================================

        private void MostrarFactura(AdministracionAntonioEntities bd, decimal factcontador)
        {
            var f = bd.Facturas.AsNoTracking().FirstOrDefault(x => x.factcontador == factcontador);
            if (f == null)
            {
                MessageBox.Show("La factura no existe.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BeginInvoke(new Action(Close));
                return;
            }

            labelTitulo.Text = f.factserie == FacturasUtil.SerieMensual ? "Factura mensual"
                             : f.factserie == FacturasUtil.SerieRectificativa ? "Factura rectificativa"
                             : "Factura directa";
            labelNumeroFactura.Text = FacturasUtil.Numero(f);
            if (f.factfechadoc.HasValue) dateTimePickerFecha.Value = f.factfechadoc.Value;
            dateTimePickerFecha.Enabled = false;

            checkOcasional.Checked = f.factcodcliente == FacturasUtil.CodigoClienteOcasional;
            checkOcasional.Enabled = false;
            comboCliente.Enabled = false;
            comboCliente.Text = f.factcodcliente.HasValue && f.factcodcliente != FacturasUtil.CodigoClienteOcasional
                ? "Código " + f.factcodcliente.Value.ToString("0")
                : "";

            txtNombre.Text = (f.factnombre ?? "").Trim();
            txtNif.Text = (f.factnif ?? "").Trim();
            txtDireccion.Text = (f.factdireccion ?? "").Trim();
            txtCp.Text = (f.factcp ?? "").Trim();
            txtLocalidad.Text = (f.factlocalidad ?? "").Trim();
            txtProvincia.Text = (f.factprovincia ?? "").Trim();
            txtMail.Text = (f.factmail ?? "").Trim();
            checkContabilizar.Checked = f.factparacontabilizar == true;
            checkRetencion.Checked = (f.factretencion ?? 0) != 0;
            checkPorMail.Checked = f.factpormail == true;

            foreach (var t in new[] { txtNombre, txtNif, txtDireccion, txtCp, txtLocalidad, txtProvincia, txtMail })
            {
                t.ReadOnly = true;
            }
            foreach (var c in new[] { checkContabilizar, checkRetencion, checkPorMail })
            {
                c.Enabled = false;
            }

            var lineas = FacturasUtil.LineasDe(bd, f);
            dataGridLineas.ReadOnly = true;
            dataGridLineas.AllowUserToAddRows = false;
            dataGridLineas.AllowUserToDeleteRows = false;
            foreach (var l in lineas)
            {
                string iva = l.Suplido ? TextoSuplido : TextoIva(l.TipoIva);
                if (!colIva.Items.Contains(iva)) colIva.Items.Add(iva);
                dataGridLineas.Rows.Add(l.Concepto, l.Cantidad.ToString("0.###", Es), l.Precio.ToString("N2", Es), iva,
                    l.Importe.ToString("N2", Es) + " €");
            }
            MostrarTotales(FacturasUtil.Calcular(lineas), f.factretencion ?? 0);

            var estado = new List<string>();
            estado.Add(f.factimpresa == true ? "Impresa" : "Sin imprimir");
            if (f.factparacontabilizar == true) estado.Add(f.factcontabilizada == true ? "Contabilizada" : "Pendiente de contabilizar");
            if (f.factparadomiciliar == true) estado.Add(f.factdomiciliada == true ? "Domiciliada" : "Pendiente de domiciliar");
            labelAviso.Text = string.Join("  ·  ", estado);

            button1.Visible = false;
            button2.Location = new Point(130, 575);
            imprimir.Visible = true;
            Text = "eGESTION - Factura " + FacturasUtil.Numero(f);
        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            if (!facturaVista.HasValue) return;
            try
            {
                Cursor = Cursors.WaitCursor;
                FacturasUtil.GenerarPdf(facturaVista.Value, true);
            }
            catch (Exception ex)
            {
                Error("No se ha podido crear el PDF", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // =====================================================================

        private static void Aviso(string texto)
        {
            MessageBox.Show(texto, "Factura directa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static void Error(string texto, Exception ex)
        {
            var interna = ex;
            while (interna.InnerException != null) interna = interna.InnerException;
            MessageBox.Show(texto + ":\n\n" + interna.Message, "Factura directa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
