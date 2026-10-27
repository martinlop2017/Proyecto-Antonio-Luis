using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BaseDatos;
using Proyecto_Antonio_Luis.Clases;

namespace Proyecto_Antonio_Luis.Formularios
{
    /// <summary>
    /// Tipos de impuestos:
    ///   - Tipos de IVA (tabla Iva): concepto, % IVA y % recargo de equivalencia.
    ///   - Retenciones IRPF (tabla Retenciones): concepto, % y cuál es la que se aplica
    ///     a los clientes que tienen marcada "Retención IRPF" en su ficha.
    /// </summary>
    public partial class Impuestos : Form
    {
        /// <summary>Fila de la lista (sirve para los dos tipos).</summary>
        private class FilaImpuesto
        {
            public decimal Numerador { get; set; }
            public string Concepto { get; set; }
            public decimal? Porcentaje { get; set; }
            public string Extra { get; set; }
        }

        private static readonly CultureInfo Es = new CultureInfo("es-ES");

        /// <summary>Número del registro que se está modificando (null = alta).</summary>
        private decimal? editando;

        private bool EsRetencion
        {
            get { return radioRetencion.Checked; }
        }

        public Impuestos()
        {
            InitializeComponent();

            // Columnas de la lista enlazadas a FilaImpuesto
            dataGridViewTextBoxColumn1.DataPropertyName = "Numerador";
            dataGridViewTextBoxColumn2.DataPropertyName = "Concepto";
            dataGridViewTextBoxColumn3.DataPropertyName = "Porcentaje";
            dataGridViewTextBoxColumn4.DataPropertyName = "Extra";
            dataGridViewTextBoxColumn3.DefaultCellStyle.Format = "0.00";
            dgvIva.ReadOnly = true;
        }

        private void Impuestos_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        // =====================================================================
        //  Lista
        // =====================================================================

        private void radioTipo_CheckedChanged(object sender, EventArgs e)
        {
            // Se dispara dos veces (uno se desmarca y otro se marca): solo nos interesa el marcado
            var radio = sender as RadioButton;
            if (radio != null && radio.Checked)
            {
                CargarLista();
            }
        }

        private void CargarLista(decimal? seleccionar = null)
        {
            try
            {
                List<FilaImpuesto> filas;
                using (var bd = new AdministracionAntonioEntities())
                {
                    if (EsRetencion)
                    {
                        filas = bd.Retenciones.AsNoTracking()
                            .OrderBy(r => r.retporciento).ToList()
                            .Select(r => new FilaImpuesto
                            {
                                Numerador = r.numerador,
                                Concepto = (r.retconcepto ?? "").Trim(),
                                Porcentaje = r.retporciento,
                                Extra = r.retpordefecto ? "Sí" : ""
                            }).ToList();
                    }
                    else
                    {
                        filas = bd.Iva.AsNoTracking()
                            .OrderBy(i => i.ivaporciento).ToList()
                            .Select(i => new FilaImpuesto
                            {
                                Numerador = i.numerador,
                                Concepto = (i.ivaconcepto ?? "").Trim(),
                                Porcentaje = i.ivaporciento,
                                Extra = i.ivarecargo.HasValue ? i.ivarecargo.Value.ToString("0.00", Es) : ""
                            }).ToList();
                    }
                }

                label7.Text = EsRetencion ? "Retenciones IRPF" : "Tipos de IVA";
                dataGridViewTextBoxColumn3.HeaderText = EsRetencion ? "Retención %" : "Iva %";
                dataGridViewTextBoxColumn4.HeaderText = EsRetencion ? "Se aplica" : "R.E. %";

                dgvIva.DataSource = filas;

                if (seleccionar.HasValue)
                {
                    foreach (DataGridViewRow fila in dgvIva.Rows)
                    {
                        var f = fila.DataBoundItem as FilaImpuesto;
                        if (f != null && f.Numerador == seleccionar.Value)
                        {
                            fila.Selected = true;
                            dgvIva.CurrentCell = fila.Cells[1];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError("No se ha podido cargar la lista.", ex);
            }
        }

        private FilaImpuesto FilaSeleccionada()
        {
            return dgvIva.CurrentRow == null ? null : dgvIva.CurrentRow.DataBoundItem as FilaImpuesto;
        }

        // =====================================================================
        //  Añadir / Modificar / Eliminar
        // =====================================================================

        private void sumar_Click(object sender, EventArgs e)
        {
            editando = null;
            boxconcepto.Text = "";
            boxiva.Text = "";
            boxrecargo.Text = "";
            // Si es la primera retención, será la que se aplique
            checPorDefecto.Checked = EsRetencion && dgvIva.Rows.Count == 0;
            AbrirPanel(EsRetencion ? "Alta de retención" : "Alta de tipo de IVA");
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            var fila = FilaSeleccionada();
            if (fila == null)
            {
                MessageBox.Show("Selecciona primero un tipo de la lista.", "Modificar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            editando = fila.Numerador;
            boxconcepto.Text = fila.Concepto;
            boxiva.Text = fila.Porcentaje.HasValue ? fila.Porcentaje.Value.ToString("0.00", Es) : "";
            if (EsRetencion)
            {
                boxrecargo.Text = "";
                checPorDefecto.Checked = fila.Extra == "Sí";
            }
            else
            {
                boxrecargo.Text = fila.Extra;
            }
            AbrirPanel(EsRetencion ? "Modificar retención" : "Modificar tipo de IVA");
        }

        private void dgvIva_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modificar_Click(sender, e);
            }
        }

        private void eliminar_Click_1(object sender, EventArgs e)
        {
            var fila = FilaSeleccionada();
            if (fila == null)
            {
                MessageBox.Show("Selecciona primero un tipo de la lista.", "Eliminar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string descripcion = fila.Concepto + " (" +
                (fila.Porcentaje.HasValue ? fila.Porcentaje.Value.ToString("0.00", Es) : "?") + " %)";
            string aviso = "¿Eliminar " + (EsRetencion ? "la retención " : "el tipo de IVA ") + descripcion + "?";
            if (EsRetencion && fila.Extra == "Sí")
            {
                aviso += "\n\nEs la retención que se aplica: si la eliminas, marca otra como \"la que se aplica\".";
            }
            aviso += "\n\nLas facturas ya emitidas no cambian.";

            if (MessageBox.Show(aviso, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (var bd = new AdministracionAntonioEntities())
                {
                    if (EsRetencion)
                    {
                        var borrar = bd.Retenciones.Find(fila.Numerador);
                        if (borrar != null) bd.Retenciones.Remove(borrar);
                    }
                    else
                    {
                        var borrar = bd.Iva.Find(fila.Numerador);
                        if (borrar != null) bd.Iva.Remove(borrar);
                    }
                    bd.SaveChanges();
                }
                CargarLista();
            }
            catch (Exception ex)
            {
                MostrarError("No se ha podido eliminar.", ex);
            }
        }

        // =====================================================================
        //  Panel de alta / modificación
        // =====================================================================

        private void AbrirPanel(string titulo)
        {
            label9.Text = titulo;
            label6.Text = EsRetencion ? "% Retención" : "% I.V.A.";
            label8.Visible = !EsRetencion;
            boxrecargo.Visible = !EsRetencion;
            checPorDefecto.Visible = EsRetencion;
            boxconcepto.MaxLength = EsRetencion ? 50 : 20;

            panel1.Visible = true;
            sumar.Enabled = false;
            modificar.Enabled = false;
            eliminar.Enabled = false;
            radioIva.Enabled = false;
            radioRetencion.Enabled = false;
            salir.Visible = false;

            AcceptButton = buttonAceptar;
            CancelButton = button2;
            boxconcepto.Focus();
        }

        private void CerrarPanel()
        {
            panel1.Visible = false;
            sumar.Enabled = true;
            modificar.Enabled = true;
            eliminar.Enabled = true;
            radioIva.Enabled = true;
            radioRetencion.Enabled = true;
            salir.Visible = true;
            AcceptButton = null;
            CancelButton = null;
        }

        /// <summary>Aceptar.</summary>
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            string concepto = (boxconcepto.Text ?? "").Trim();
            decimal porcentaje, recargo = 0;
            var errores = new List<string>();
            Control primerError = null;

            if (concepto.Length == 0)
            {
                errores.Add("El concepto es obligatorio.");
                primerError = boxconcepto;
            }
            if (!LeerPorcentaje(boxiva.Text, out porcentaje))
            {
                errores.Add((EsRetencion ? "% de retención" : "% de IVA") + " no válido (entre 0 y 99,99).");
                if (primerError == null) primerError = boxiva;
            }
            if (!EsRetencion && !LeerPorcentaje(boxrecargo.Text, out recargo))
            {
                errores.Add("% de recargo de equivalencia no válido (entre 0 y 99,99; vacío = 0).");
                if (primerError == null) primerError = boxrecargo;
            }

            if (errores.Count > 0)
            {
                MessageBox.Show("Revisa los datos:\n\n- " + string.Join("\n- ", errores), "Impuestos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                primerError.Focus();
                return;
            }

            try
            {
                decimal guardado;
                using (var bd = new AdministracionAntonioEntities())
                {
                    guardado = EsRetencion
                        ? GrabarRetencion(bd, concepto, porcentaje)
                        : GrabarIva(bd, concepto, porcentaje, recargo);
                }
                CerrarPanel();
                CargarLista(guardado);
            }
            catch (OperationCanceledException)
            {
                // El usuario ha decidido no grabar un tipo repetido
            }
            catch (Exception ex)
            {
                MostrarError("No se ha podido grabar.", ex);
            }
        }

        private decimal GrabarIva(AdministracionAntonioEntities bd, string concepto, decimal porcentaje, decimal recargo)
        {
            decimal? actual = editando;
            if (bd.Iva.Any(i => i.ivaporciento == porcentaje && i.ivarecargo == recargo && i.numerador != actual))
            {
                ConfirmarRepetido();
            }

            Iva iva;
            if (actual.HasValue)
            {
                iva = bd.Iva.Find(actual.Value);
                if (iva == null) throw new InvalidOperationException("El tipo de IVA ya no existe (¿lo ha borrado otro usuario?).");
            }
            else
            {
                iva = new Iva { numerador = (bd.Iva.Max(i => (decimal?)i.numerador) ?? 0) + 1 };
                bd.Iva.Add(iva);
            }

            iva.ivaconcepto = concepto;
            iva.ivaporciento = porcentaje;
            iva.ivarecargo = recargo;
            bd.SaveChanges();
            return iva.numerador;
        }

        private decimal GrabarRetencion(AdministracionAntonioEntities bd, string concepto, decimal porcentaje)
        {
            decimal? actual = editando;
            if (bd.Retenciones.Any(r => r.retporciento == porcentaje && r.numerador != actual))
            {
                ConfirmarRepetido();
            }

            Retenciones ret;
            if (actual.HasValue)
            {
                ret = bd.Retenciones.Find(actual.Value);
                if (ret == null) throw new InvalidOperationException("La retención ya no existe (¿la ha borrado otro usuario?).");
            }
            else
            {
                ret = new Retenciones { numerador = (bd.Retenciones.Max(r => (decimal?)r.numerador) ?? 0) + 1 };
                bd.Retenciones.Add(ret);
            }

            ret.retconcepto = concepto;
            ret.retporciento = porcentaje;
            ret.retpordefecto = checPorDefecto.Checked;

            // Solo puede haber una que se aplique
            if (ret.retpordefecto)
            {
                decimal numero = ret.numerador;
                foreach (var otra in bd.Retenciones.Where(r => r.numerador != numero && r.retpordefecto))
                {
                    otra.retpordefecto = false;
                }
            }

            bd.SaveChanges();
            return ret.numerador;
        }

        private void ConfirmarRepetido()
        {
            if (MessageBox.Show("Ya existe otro tipo con el mismo porcentaje. ¿Grabar igualmente?", "Impuestos",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                throw new OperationCanceledException();
            }
        }

        /// <summary>Cancelar.</summary>
        private void button2_Click(object sender, EventArgs e)
        {
            CerrarPanel();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // =====================================================================
        //  Utilidades
        // =====================================================================

        /// <summary>Porcentaje entre 0 y 99,99 (admite coma o punto; vacío = 0).</summary>
        private static bool LeerPorcentaje(string texto, out decimal valor)
        {
            string t = (texto ?? "").Trim().Replace("%", "").Replace('.', ',');
            if (t.Length == 0)
            {
                valor = 0;
                return true;
            }
            return decimal.TryParse(t, NumberStyles.Number, Es, out valor)
                   && valor >= 0 && valor < 100
                   && decimal.Round(valor, 2) == valor;
        }

        private static void MostrarError(string mensaje, Exception ex)
        {
            Exception interna = ex;
            while (interna.InnerException != null)
            {
                interna = interna.InnerException;
            }
            string detalle = interna.Message;
            if (detalle.Contains("Retenciones") || detalle.Contains("retencion"))
            {
                detalle += "\n\nFalta ejecutar el script SQL\\2026-10-27_Retenciones_IRPF.sql en la base de datos.";
            }
            MessageBox.Show(mensaje + "\n\n" + detalle, "Impuestos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // =====================================================================
        //  Etiquetas de ayuda al pasar el ratón y eventos sin uso
        // =====================================================================

        private void sumar_MouseEnter(object sender, EventArgs e) { label1.Visible = true; }
        private void sumar_MouseLeave(object sender, EventArgs e) { label1.Visible = false; }
        private void eliminar_MouseEnter(object sender, EventArgs e) { label2.Visible = true; }
        private void eliminar_MouseLeave(object sender, EventArgs e) { label2.Visible = false; }
        private void modificar_MouseEnter(object sender, EventArgs e) { label3.Visible = true; }
        private void modificar_MouseLeave(object sender, EventArgs e) { label3.Visible = false; }
        private void salir_MouseEnter(object sender, EventArgs e) { label5.Visible = true; }
        private void salir_MouseLeave(object sender, EventArgs e) { label5.Visible = false; }

        private void dataGridViewIVAs_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void boxconcepto_TextChanged(object sender, EventArgs e) { }
        private void ivaBindingSource_CurrentChanged(object sender, EventArgs e) { }
    }
}
