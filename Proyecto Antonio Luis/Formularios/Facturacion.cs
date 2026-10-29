using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BaseDatos;
using Proyecto_Antonio_Luis.Clases;

namespace Proyecto_Antonio_Luis.Formularios
{
    /// <summary>
    /// Facturación mensual (serie M).
    ///
    ///  1. Generar: propone una factura para cada cliente activo con su tarifa,
    ///     sus nóminas (empleados × precio) y su retención de IRPF si la lleva.
    ///  2. Se pueden retocar importes, añadir suplidos, añadir o quitar clientes.
    ///  3. Facturar: graba todas las facturas de golpe (o ninguna si algo falla),
    ///     las añade a la remesa del mes ("Octubre 2026"), crea los PDF y saca el
    ///     listado de control.
    ///
    /// Un cliente no puede tener dos facturas en la misma remesa: si el mes ya
    /// está facturado, solo se proponen los clientes que falten.
    /// </summary>
    public partial class Facturacion : Form
    {
        private static readonly CultureInfo Es = new CultureInfo("es-ES");

        private static readonly string[] Meses =
        {
            "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
            "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
        };

        private readonly BindingList<FilaMensual> filas = new BindingList<FilaMensual>();
        private decimal porcRetencion = 15m;
        private bool cargando;

        // =====================================================================
        //  Una fila de la facturación (una factura propuesta)
        // =====================================================================

        private class FilaMensual
        {
            public Clientes Cliente { get; set; }

            public decimal Codigo { get { return Cliente.codcliente ?? 0; } }
            public string Nombre { get { return (Cliente.nombrecliente ?? "").Trim(); } }

            public decimal Honorarios { get; set; }
            public decimal Empleados { get; set; }
            public decimal PrecioEmpleado { get; set; }
            public string ConceptoSuplido { get; set; }
            public decimal Suplidos { get; set; }

            public decimal TipoIva { get; set; }
            /// <summary>% de retención (0 si el cliente no lleva).</summary>
            public decimal PorcRetencion { get; set; }

            public decimal Laboral
            {
                get { return Math.Round(Empleados * PrecioEmpleado, 2, MidpointRounding.AwayFromZero); }
            }

            public decimal BaseImponible { get { return Honorarios + Laboral; } }

            public decimal Iva
            {
                get { return Math.Round(BaseImponible * TipoIva / 100, 2, MidpointRounding.AwayFromZero); }
            }

            public decimal Retencion
            {
                get { return Math.Round(BaseImponible * PorcRetencion / 100, 2, MidpointRounding.AwayFromZero); }
            }

            public decimal Total { get { return BaseImponible + Iva - Retencion + Suplidos; } }

            public bool PorMail { get { return Cliente.pormailcliente == true; } }
            public bool Domiciliar { get { return Cliente.domiciliadocliente == true; } }
        }

        public Facturacion()
        {
            InitializeComponent();
            CrearColumnas();
            combomes.KeyDown += SoloElegir_KeyDown;
            comboiva.KeyDown += SoloElegir_KeyDown;
        }

        // =====================================================================
        //  Carga
        // =====================================================================

        private void Facturacion_Load(object sender, EventArgs e)
        {
            cargando = true;
            try
            {
                using (var bd = new AdministracionAntonioEntities())
                {
                    var tipos = bd.Iva.AsNoTracking()
                        .Where(i => i.ivaporciento != null)
                        .Select(i => i.ivaporciento.Value)
                        .ToList()
                        .Distinct()
                        .OrderByDescending(t => t)
                        .ToList();
                    comboiva.DataSource = tipos;
                    comboiva.FormatString = "0.##";
                    if (tipos.Contains(21m)) comboiva.SelectedItem = 21m;

                    porcRetencion = FacturasUtil.PorcentajeRetencion(bd);
                }

                combomes.Items.Clear();
                combomes.Items.AddRange(Meses);
                combomes.SelectedIndex = DateTime.Today.Month - 1;
                fechafactura.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                Error("No se han podido cargar los datos", ex);
            }
            finally
            {
                cargando = false;
            }

            dgvTemporal.DataSource = filas;
            ActualizarContador();
            facturar.Enabled = false;
        }

        private void CrearColumnas()
        {
            dgvTemporal.AutoGenerateColumns = false;
            dgvTemporal.Columns.Clear();
            dgvTemporal.AllowUserToAddRows = false;
            dgvTemporal.AllowUserToDeleteRows = false;
            dgvTemporal.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvTemporal.RowTemplate.DefaultCellStyle.Format = null;

            Columna("Nombre", "Cliente", 0, null, true).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Columna("Honorarios", "Fiscal y contable", 90, "N2", false);
            Columna("Empleados", "Emp.", 50, "0.##", false);
            Columna("PrecioEmpleado", "Precio empl.", 80, "N2", false);
            Columna("Laboral", "Laboral", 80, "N2", true);
            Columna("ConceptoSuplido", "Concepto suplidos", 170, null, false);
            Columna("Suplidos", "Suplidos", 80, "N2", false);
            Columna("BaseImponible", "Base", 85, "N2", true);
            Columna("Iva", "IVA", 75, "N2", true);
            Columna("Retencion", "Ret. IRPF", 75, "N2", true);
            Columna("Total", "Total", 90, "N2", true);
            Marca("PorMail", "Mail");
            Marca("Domiciliar", "Domic.");
        }

        private DataGridViewTextBoxColumn Columna(string propiedad, string titulo, int ancho, string formato, bool soloLectura)
        {
            var c = new DataGridViewTextBoxColumn
            {
                DataPropertyName = propiedad,
                Name = "col" + propiedad,
                HeaderText = titulo,
                ReadOnly = soloLectura,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            if (ancho > 0) c.Width = ancho;
            if (formato != null)
            {
                c.DefaultCellStyle.Format = formato;
                c.DefaultCellStyle.FormatProvider = Es;
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            // Las columnas que se pueden cambiar, en blanco; el resto, en amarillo
            if (!soloLectura) c.DefaultCellStyle.BackColor = Color.White;
            dgvTemporal.Columns.Add(c);
            return c;
        }

        private void Marca(string propiedad, string titulo)
        {
            dgvTemporal.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = propiedad,
                Name = "col" + propiedad,
                HeaderText = titulo,
                Width = 45,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        // =====================================================================
        //  Mes, año y fecha
        // =====================================================================

        private int MesFacturado
        {
            get { return combomes.SelectedIndex + 1; }
        }

        /// <summary>
        /// Año del mes que se factura: el año actual. Solo si estamos en enero o
        /// febrero y se factura noviembre o diciembre, es el año anterior
        /// (facturar en enero el mes de diciembre).
        /// No depende de la fecha de la factura, para que "fin de mes" no lo cambie.
        /// </summary>
        private int AñoFacturado
        {
            get
            {
                DateTime hoy = DateTime.Today;
                return hoy.Month <= 2 && MesFacturado >= 11 ? hoy.Year - 1 : hoy.Year;
            }
        }

        /// <summary>Nombre de la remesa: "Octubre 2026".</summary>
        private string NombreRemesa
        {
            get { return Meses[MesFacturado - 1] + " " + AñoFacturado; }
        }

        private string MesTexto
        {
            get { return Meses[MesFacturado - 1].ToLower(Es) + " de " + AñoFacturado; }
        }

        /// <summary>
        /// Los desplegables de mes e IVA se dejan en blanco (estilo normal), pero no
        /// se puede escribir en ellos: solo elegir de la lista.
        /// </summary>
        private void SoloElegir_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void SoloElegir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) e.SuppressKeyPress = e.Handled = true;
        }

        private void linkFinMes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (combomes.SelectedIndex < 0) return;
            int año = AñoFacturado;
            fechafactura.Value = new DateTime(año, MesFacturado, DateTime.DaysInMonth(año, MesFacturado));
        }

        // =====================================================================
        //  Generar
        // =====================================================================

        private void sumar_Click(object sender, EventArgs e)
        {
            if (combomes.SelectedIndex < 0)
            {
                Aviso("Elige el mes que vas a facturar.");
                return;
            }
            if (filas.Count > 0 &&
                MessageBox.Show("Se va a volver a generar la lista y se perderán los cambios hechos a mano.\n¿Continuar?",
                    "Facturación mensual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                List<Clientes> activos;
                HashSet<decimal> yaFacturados;
                using (var bd = new AdministracionAntonioEntities())
                {
                    activos = bd.Clientes.AsNoTracking()
                        .Where(c => c.activocliente == true)
                        .OrderBy(c => c.nombrecliente)
                        .ToList();
                    yaFacturados = FacturasUtil.ClientesYaFacturados(bd, NombreRemesa);
                }

                filas.RaiseListChangedEvents = false;
                filas.Clear();
                int omitidos = 0;
                foreach (var c in activos)
                {
                    if (c.codcliente.HasValue && yaFacturados.Contains(c.codcliente.Value))
                    {
                        omitidos++;
                        continue;
                    }
                    filas.Add(NuevaFila(c));
                }
                filas.RaiseListChangedEvents = true;
                filas.ResetBindings();

                ActualizarContador();
                facturar.Enabled = filas.Count > 0;
                añadir.Enabled = true;
                eliminar.Enabled = true;

                if (omitidos > 0)
                {
                    MessageBox.Show("La remesa " + NombreRemesa + " ya está facturada para " + omitidos +
                                    (omitidos == 1 ? " cliente" : " clientes") + ".\n" +
                                    (filas.Count > 0
                                        ? "Solo se proponen los " + filas.Count + " que faltan."
                                        : "No falta ningún cliente activo por facturar."),
                        "Facturación mensual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Error("No se ha podido generar la facturación", ex);
            }
        }

        private FilaMensual NuevaFila(Clientes c)
        {
            return new FilaMensual
            {
                Cliente = c,
                Honorarios = c.tarifacliente ?? 0,
                Empleados = c.empleadoscliente ?? 0,
                PrecioEmpleado = c.precioempleadocliente ?? 0,
                ConceptoSuplido = "",
                Suplidos = 0,
                TipoIva = TipoIvaElegido(),
                PorcRetencion = c.retencioncliente == true ? porcRetencion : 0
            };
        }

        private decimal TipoIvaElegido()
        {
            return comboiva.SelectedItem is decimal ? (decimal)comboiva.SelectedItem : 21m;
        }

        private void ActualizarContador()
        {
            label14.Text = filas.Count + "   ·   Total: " + filas.Sum(f => f.Total).ToString("N2", Es) + " €";
        }

        /// <summary>Al cambiar el IVA se recalculan todas las filas.</summary>
        private void comboiva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando || filas.Count == 0) return;
            decimal tipo = TipoIvaElegido();
            foreach (var f in filas) f.TipoIva = tipo;
            filas.ResetBindings();
            ActualizarContador();
        }

        private void dgvTemporal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // Los totales de la fila dependen de lo que se ha cambiado
            dgvTemporal.InvalidateRow(e.RowIndex);
            ActualizarContador();
        }

        private void dgvTemporal_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Escribe un número válido.", "Facturación mensual", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = true;
        }

        // =====================================================================
        //  Añadir y quitar clientes
        // =====================================================================

        private void añadir_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.BringToFront();
            textBox2.Text = "";
            BuscarClientes();
            textBox2.Focus();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            BuscarClientes();
        }

        private void textBox2_Enter_1(object sender, EventArgs e)
        {
        }

        private void BuscarClientes()
        {
            try
            {
                string texto = textBox2.Text.Trim();
                using (var bd = new AdministracionAntonioEntities())
                {
                    var lista = bd.Clientes.AsNoTracking()
                        .Where(c => texto == "" || c.nombrecliente.Contains(texto))
                        .OrderBy(c => c.nombrecliente)
                        .ToList()
                        .Select(c => new { c.codcliente, Nombre = (c.nombrecliente ?? "").Trim(), Nif = (c.cifcliente ?? "").Trim(),
                                           Activo = c.activocliente == true, Cliente = c })
                        .ToList();
                    dataGridView2.AutoGenerateColumns = true;
                    dataGridView2.DataSource = lista;
                    if (dataGridView2.Columns.Contains("Cliente")) dataGridView2.Columns["Cliente"].Visible = false;
                    if (dataGridView2.Columns.Contains("codcliente")) dataGridView2.Columns["codcliente"].HeaderText = "Código";
                    if (dataGridView2.Columns.Contains("Nombre")) dataGridView2.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView2.MultiSelect = true;
                    dataGridView2.ReadOnly = true;
                    dataGridView2.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                Error("No se han podido buscar los clientes", ex);
            }
        }

        /// <summary>Añade a la facturación los clientes seleccionados en la búsqueda.</summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (combomes.SelectedIndex < 0)
            {
                Aviso("Elige primero el mes que vas a facturar.");
                return;
            }
            var elegidos = dataGridView2.SelectedRows.Cast<DataGridViewRow>()
                .Select(r => (Clientes)r.DataBoundItem.GetType().GetProperty("Cliente").GetValue(r.DataBoundItem, null))
                .ToList();
            if (elegidos.Count == 0)
            {
                Aviso("Selecciona en la lista el cliente (o los clientes) que quieres añadir.");
                return;
            }

            HashSet<decimal> yaFacturados;
            using (var bd = new AdministracionAntonioEntities())
            {
                yaFacturados = FacturasUtil.ClientesYaFacturados(bd, NombreRemesa);
            }

            var avisos = new List<string>();
            foreach (var c in elegidos)
            {
                decimal cod = c.codcliente ?? 0;
                if (filas.Any(f => f.Codigo == cod))
                {
                    avisos.Add((c.nombrecliente ?? "").Trim() + ": ya está en la lista.");
                    continue;
                }
                if (yaFacturados.Contains(cod))
                {
                    avisos.Add((c.nombrecliente ?? "").Trim() + ": ya tiene factura en la remesa " + NombreRemesa + ".");
                    continue;
                }
                filas.Add(NuevaFila(c));
            }

            panel3.Visible = false;
            ActualizarContador();
            facturar.Enabled = filas.Count > 0;
            eliminar.Enabled = filas.Count > 0;

            if (avisos.Count > 0)
            {
                MessageBox.Show("No se han añadido:\n\n" + string.Join("\n", avisos), "Facturación mensual",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            var quitar = dgvTemporal.SelectedCells.Cast<DataGridViewCell>()
                .Select(c => c.RowIndex)
                .Distinct()
                .Where(i => i >= 0 && i < filas.Count)
                .Select(i => filas[i])
                .ToList();
            if (quitar.Count == 0)
            {
                Aviso("Selecciona en la lista el cliente que quieres quitar.");
                return;
            }
            string nombres = string.Join("\n", quitar.Take(10).Select(f => "   " + f.Nombre)) + (quitar.Count > 10 ? "\n   ..." : "");
            if (MessageBox.Show("Se van a quitar de esta facturación:\n\n" + nombres + "\n\n¿Continuar?", "Quitar de la facturación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            foreach (var f in quitar) filas.Remove(f);
            ActualizarContador();
            facturar.Enabled = filas.Count > 0;
        }

        // =====================================================================
        //  Facturar
        // =====================================================================

        private void facturar_Click(object sender, EventArgs e)
        {
            dgvTemporal.EndEdit();
            if (filas.Count == 0)
            {
                Aviso("No hay ninguna factura que emitir. Pulsa Generar.");
                return;
            }

            var sinImporte = filas.Where(f => f.Total <= 0).ToList();
            if (sinImporte.Count > 0)
            {
                Aviso("Estas facturas tienen total cero o negativo. Corrige el importe o quítalas de la lista:\n\n" +
                      string.Join("\n", sinImporte.Take(15).Select(f => "   " + f.Nombre)));
                return;
            }
            var sinNif = filas.Where(f => string.IsNullOrWhiteSpace(f.Cliente.cifcliente)).ToList();
            if (sinNif.Count > 0)
            {
                Aviso("Estos clientes no tienen NIF en su ficha. Complétalo antes de facturar:\n\n" +
                      string.Join("\n", sinNif.Take(15).Select(f => "   " + f.Nombre)));
                return;
            }

            DateTime fecha = fechafactura.Value.Date;
            string remesa = NombreRemesa;
            int añoRemesa = AñoFacturado;

            if (fecha < new DateTime(añoRemesa, MesFacturado, 1) &&
                MessageBox.Show("La fecha de las facturas (" + fecha.ToString("dd/MM/yyyy") + ") es anterior al mes que facturas (" +
                                remesa + ").\n¿Es correcto?", "Facturación mensual",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (var bd = new AdministracionAntonioEntities())
                {
                    int ejercicio = fecha.Year;
                    DateTime? ultima = bd.Facturas
                        .Where(f => f.factserie == FacturasUtil.SerieMensual && f.factejercicio == ejercicio)
                        .Max(f => f.factfechadoc);
                    if (ultima.HasValue && fecha < ultima.Value)
                    {
                        Aviso("La última factura mensual de " + ejercicio + " tiene fecha " + ultima.Value.ToString("dd/MM/yyyy") +
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

            string resumen = "Se van a emitir " + filas.Count + " facturas de la remesa " + remesa +
                             "\ncon fecha " + fecha.ToString("dd/MM/yyyy") + " e IVA del " + TipoIvaElegido().ToString("0.##", Es) + " %." +
                             "\n\nTotal: " + filas.Sum(f => f.Total).ToString("N2", Es) + " €" +
                             "\n\nUna vez emitidas no se pueden modificar ni borrar.\n¿Emitir las facturas?";
            if (MessageBox.Show(resumen, "Facturación mensual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            // 1. Grabar todas (o ninguna)
            List<decimal> ids;
            Cursor = Cursors.WaitCursor;
            try
            {
                var nuevas = filas.Select(f => Preparar(f)).ToList();
                ids = FacturasUtil.GrabarMensual(remesa, añoRemesa, fecha, nuevas);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                Error("No se ha grabado ninguna factura", ex);
                return;
            }

            filas.Clear();
            ActualizarContador();
            facturar.Enabled = false;
            eliminar.Enabled = false;

            // 2. PDF de cada factura
            var errores = new List<string>();
            var espera = new FormEsperar("Creando los PDF de las facturas");
            try
            {
                espera.Show(this);
                Application.DoEvents();
                using (var bd = new AdministracionAntonioEntities())
                {
                    foreach (var id in ids)
                    {
                        try
                        {
                            FacturasUtil.GenerarPdf(id, false);
                        }
                        catch (Exception ex)
                        {
                            var f = bd.Facturas.Find(id);
                            var interna = ex;
                            while (interna.InnerException != null) interna = interna.InnerException;
                            errores.Add((f != null ? FacturasUtil.Numero(f) + " " + (f.factnombre ?? "").Trim() : id.ToString()) + ": " + interna.Message);
                        }
                        Application.DoEvents();
                    }
                }
            }
            finally
            {
                espera.Close();
                Cursor = Cursors.Default;
            }

            MessageBox.Show(ids.Count + " facturas emitidas en la remesa " + remesa + "." +
                            (errores.Count > 0
                                ? "\n\nNo se ha podido crear el PDF de:\n" + string.Join("\n", errores.Take(10)) +
                                  "\n\nSe pueden imprimir después desde Gestión de facturas."
                                : "\nLos PDF están en la carpeta de facturación de cada cliente."),
                "Facturación mensual", MessageBoxButtons.OK, errores.Count > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

            // 3. Envío por correo a los clientes que la reciben por mail
            try
            {
                var porMail = EnvioFacturas.PendientesDeEnviar(ids);
                if (porMail.Count > 0)
                {
                    EnvioFacturas.PreguntarYEnviar(this, porMail,
                        porMail.Count + (porMail.Count == 1 ? " factura es de un cliente que la recibe" : " facturas son de clientes que las reciben") +
                        " por correo.\n\n¿Enviarlas ahora?");
                }
            }
            catch (Exception ex)
            {
                Error("No se han podido enviar las facturas por correo", ex);
            }

            // 4. Listado de control de la remesa
            MostrarListado(remesa);
        }

        /// <summary>Prepara los datos y las líneas de una factura a partir de su fila.</summary>
        private FacturaMensualNueva Preparar(FilaMensual f)
        {
            var c = f.Cliente;
            var lineas = new List<LineaFactura>();
            if (f.Honorarios != 0)
            {
                lineas.Add(new LineaFactura
                {
                    Cantidad = 1,
                    Concepto = "Honorarios correspondientes al mes de " + MesTexto,
                    Precio = f.Honorarios,
                    TipoIva = f.TipoIva
                });
            }
            if (f.Laboral != 0)
            {
                lineas.Add(new LineaFactura
                {
                    Cantidad = f.Empleados,
                    Concepto = "Gestión laboral: nóminas del mes de " + MesTexto,
                    Precio = f.PrecioEmpleado,
                    TipoIva = f.TipoIva
                });
            }
            string conceptoSuplido = string.IsNullOrWhiteSpace(f.ConceptoSuplido) ? "Suplidos" : f.ConceptoSuplido.Trim();
            if (f.Suplidos != 0)
            {
                lineas.Add(new LineaFactura
                {
                    Cantidad = 1,
                    Concepto = conceptoSuplido,
                    Precio = f.Suplidos,
                    Suplido = true
                });
            }

            return new FacturaMensualNueva
            {
                Cliente = new DatosClienteFactura
                {
                    Codigo = c.codcliente,
                    Nombre = c.nombrecliente,
                    Nif = c.cifcliente,
                    Direccion = c.direcioncliente,
                    Localidad = c.localidacliente,
                    Provincia = c.provinciacliente,
                    CodigoPostal = c.cod_postalcliente,
                    Mail = c.mailcliente,
                    PorMail = c.pormailcliente == true,
                    Iban = ClientesUtil.IbanCliente(c),
                    Domiciliar = c.domiciliadocliente == true,
                    Contabilizar = c.contabilizarcliente == true,
                    PorcRetencion = f.PorcRetencion
                },
                Lineas = lineas,
                Honorarios = f.Honorarios,
                Empleados = f.Empleados,
                PrecioEmpleado = f.PrecioEmpleado,
                Laboral = f.Laboral,
                Suplidos = f.Suplidos,
                ConceptoSuplido = conceptoSuplido
            };
        }

        /// <summary>Listado de control con todas las facturas de la remesa.</summary>
        private void MostrarListado(string remesa)
        {
            try
            {
                var lista = new List<datoslistadoreme>();
                using (var bd = new AdministracionAntonioEntities())
                {
                    var mios = ClientesUtil.BuscarMisDatos(bd);
                    var facturas = bd.Facturas.AsNoTracking()
                        .Where(f => f.factserie == FacturasUtil.SerieMensual && f.factremesa == remesa)
                        .OrderBy(f => f.factnumerofact)
                        .ToList();
                    decimal total = facturas.Sum(f => f.facttotalfactura ?? 0);
                    foreach (var f in facturas)
                    {
                        lista.Add(new datoslistadoreme
                        {
                            listnumerofactura = FacturasUtil.Numero(f),
                            listfecha = f.factfechadoc.HasValue ? f.factfechadoc.Value.ToString("dd/MM/yyyy") : (f.factfecha ?? "").Trim(),
                            listnombre = (f.factnombre ?? "").Trim(),
                            listbase = (f.factbaseimponible ?? 0) + (f.factbase2 ?? 0),
                            listsuplidos = f.factbase2 ?? 0,
                            listiva = f.factimporteiva ?? 0,
                            listretencion = f.factretencion ?? 0,
                            listtotal = f.facttotalfactura ?? 0,
                            listnumeroremesa = remesa,
                            listtotalremesa = total,
                            listtotaldocumentos = facturas.Count,
                            listnombreemisor = mios != null ? (mios.minombre ?? "").Trim() : ""
                        });
                    }
                }
                new Form2(lista).Show();
            }
            catch (Exception ex)
            {
                Error("No se ha podido sacar el listado de control", ex);
            }
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // =====================================================================
        //  Rótulos que aparecen al pasar el ratón
        // =====================================================================

        private void generar_MouseEnter(object sender, EventArgs e) { label9.Visible = true; }
        private void generar_MouseLeave(object sender, EventArgs e) { label9.Visible = false; }
        private void añadir_MouseEnter(object sender, EventArgs e) { label8.Visible = true; }
        private void añadir_MouseLeave(object sender, EventArgs e) { label8.Visible = false; }
        private void eliminar_MouseEnter(object sender, EventArgs e) { label6.Visible = true; }
        private void eliminar_MouseLeave(object sender, EventArgs e) { label6.Visible = false; }
        private void facturar_MouseEnter(object sender, EventArgs e) { label5.Visible = true; }
        private void facturar_MouseLeave(object sender, EventArgs e) { label5.Visible = false; }
        private void salir_MouseEnter(object sender, EventArgs e) { label10.Visible = true; }
        private void salir_MouseLeave(object sender, EventArgs e) { label10.Visible = false; }

        // =====================================================================

        private static void Aviso(string texto)
        {
            MessageBox.Show(texto, "Facturación mensual", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static void Error(string texto, Exception ex)
        {
            var interna = ex;
            while (interna.InnerException != null) interna = interna.InnerException;
            MessageBox.Show(texto + ":\n\n" + interna.Message, "Facturación mensual", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
