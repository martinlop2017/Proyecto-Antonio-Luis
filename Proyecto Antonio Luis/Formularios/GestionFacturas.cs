using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BaseDatos;
using Proyecto_Antonio_Luis.Clases;

namespace Proyecto_Antonio_Luis.Formularios
{
    /// <summary>
    /// Lista de facturas emitidas, filtrada por año y serie.
    ///  - Añadir: nueva factura directa (serie D).
    ///  - Doble clic o Intro: ver la factura.
    ///  - Imprimir: crea el PDF de las facturas seleccionadas.
    /// Las facturas no se modifican ni se borran.
    /// </summary>
    public partial class GestionFacturas : Form
    {
        private static readonly CultureInfo Es = new CultureInfo("es-ES");
        private const string Todos = "Todos";
        private const string Todas = "Todas";

        private bool cargando;
        private List<FilaFactura> filas = new List<FilaFactura>();

        /// <summary>Una fila de la lista de facturas.</summary>
        private class FilaFactura
        {
            public decimal Id { get; set; }
            public string Numero { get; set; }
            public DateTime? Fecha { get; set; }
            public string Cliente { get; set; }
            public string Nif { get; set; }
            public decimal Base { get; set; }
            public decimal Iva { get; set; }
            public decimal Total { get; set; }
            public bool Impresa { get; set; }
            public bool Contabilizada { get; set; }
            public bool Domiciliada { get; set; }
            public bool PorMail { get; set; }
            public bool Enviada { get; set; }

            // Para ordenar
            public string Serie { get; set; }
            public int Ejercicio { get; set; }
            public decimal NumeroFactura { get; set; }
            public decimal CodigoCliente { get; set; }
        }

        public GestionFacturas()
        {
            InitializeComponent();
            CrearColumnas();
        }

        private void CrearColumnas()
        {
            dgvfactura.AutoGenerateColumns = false;
            dgvfactura.Columns.Clear();
            Columna("Id", "Id", 0).Visible = false;
            Columna("Numero", "Número", 105);
            Columna("Fecha", "Fecha", 80, "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
            Columna("Cliente", "Cliente", 0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Columna("Nif", "NIF", 85);
            Columna("Base", "Base", 80, "N2", DataGridViewContentAlignment.MiddleRight);
            Columna("Iva", "IVA", 70, "N2", DataGridViewContentAlignment.MiddleRight);
            Columna("Total", "Total", 85, "N2", DataGridViewContentAlignment.MiddleRight);
            Marca("Impresa", "Impr.");
            Marca("Contabilizada", "Cont.");
            Marca("Domiciliada", "Domic.");
            Marca("PorMail", "Mail");
            Marca("Enviada", "Env.");
        }

        private DataGridViewTextBoxColumn Columna(string propiedad, string titulo, int ancho,
            string formato = null, DataGridViewContentAlignment alineacion = DataGridViewContentAlignment.MiddleLeft)
        {
            var c = new DataGridViewTextBoxColumn
            {
                DataPropertyName = propiedad,
                Name = "col" + propiedad,
                HeaderText = titulo,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            if (ancho > 0) c.Width = ancho;
            c.DefaultCellStyle.Alignment = alineacion;
            if (formato != null)
            {
                c.DefaultCellStyle.Format = formato;
                c.DefaultCellStyle.FormatProvider = Es;
            }
            dgvfactura.Columns.Add(c);
            return c;
        }

        private void Marca(string propiedad, string titulo)
        {
            dgvfactura.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = propiedad,
                Name = "col" + propiedad,
                HeaderText = titulo,
                Width = 45,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        // =====================================================================
        //  Carga y filtros
        // =====================================================================

        private void GestionFacturas_Load(object sender, EventArgs e)
        {
            cargando = true;
            try
            {
                using (var bd = new AdministracionAntonioEntities())
                {
                    var años = bd.Facturas
                        .Where(f => f.factejercicio != null)
                        .Select(f => f.factejercicio.Value)
                        .Distinct()
                        .OrderByDescending(a => a)
                        .ToList();
                    if (!años.Contains(DateTime.Today.Year)) años.Insert(0, DateTime.Today.Year);

                    comboEjercicio.Items.Clear();
                    foreach (int ej in años.OrderByDescending(x => x)) comboEjercicio.Items.Add(ej.ToString());
                    comboEjercicio.Items.Add(Todos);

                    // Año actual, o el último con facturas si este año aún no hay
                    int año = DateTime.Today.Year;
                    if (!bd.Facturas.Any(f => f.factejercicio == año) && años.Count > 1)
                    {
                        año = años.Where(a => a != DateTime.Today.Year).Max();
                    }
                    comboEjercicio.SelectedItem = año.ToString();

                    comboSerie.Items.Clear();
                    comboSerie.Items.Add(Todas);
                    foreach (var s in bd.Series.AsNoTracking().OrderBy(s => s.serie).ToList())
                    {
                        comboSerie.Items.Add(s.serie.Trim() + " - " + (s.descripcion ?? "").Trim());
                    }
                    comboSerie.SelectedIndex = 0;
                }
                comboBox1.SelectedItem = "Número";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se han podido cargar las facturas:\n" + ex.Message, "Gestión de facturas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargando = false;
            }
            Cargar(null);
        }

        private void Filtro_Cambiado(object sender, EventArgs e)
        {
            if (!cargando) Cargar(null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!cargando) Mostrar(null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargando) Mostrar(null);
        }

        /// <summary>Lee de la base de datos las facturas del año y serie elegidos.</summary>
        private void Cargar(decimal? seleccionar)
        {
            try
            {
                string textoAño = Convert.ToString(comboEjercicio.SelectedItem);
                string textoSerie = Convert.ToString(comboSerie.SelectedItem);
                int año;
                bool filtrarAño = int.TryParse(textoAño, out año);
                string serie = textoSerie == Todas || textoSerie.Length == 0 ? null : textoSerie.Split('-')[0].Trim();

                using (var bd = new AdministracionAntonioEntities())
                {
                    var consulta = bd.Facturas.AsNoTracking().AsQueryable();
                    if (filtrarAño) consulta = consulta.Where(f => f.factejercicio == año);
                    if (serie != null) consulta = consulta.Where(f => f.factserie == serie);

                    filas = consulta.ToList().Select(f => new FilaFactura
                    {
                        Id = f.factcontador,
                        Numero = FacturasUtil.Numero(f),
                        Fecha = f.factfechadoc,
                        Cliente = (f.factnombre ?? "").Trim(),
                        Nif = (f.factnif ?? "").Trim(),
                        Base = f.factbaseimponible ?? ((f.factbase1 ?? 0) + (f.factbaseempleado ?? 0)),
                        Iva = (f.factimporteiva ?? 0),
                        Total = f.facttotalfactura ?? 0,
                        Impresa = f.factimpresa == true,
                        Contabilizada = f.factcontabilizada == true,
                        Domiciliada = f.factdomiciliada == true,
                        PorMail = f.factpormail == true,
                        Enviada = f.factenviada == true,
                        Serie = f.factserie ?? "",
                        Ejercicio = f.factejercicio ?? 0,
                        NumeroFactura = f.factnumerofact ?? 0,
                        CodigoCliente = f.factcodcliente ?? 0
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                filas = new List<FilaFactura>();
                MessageBox.Show("No se han podido leer las facturas:\n" + ex.Message, "Gestión de facturas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Mostrar(seleccionar);
        }

        /// <summary>Aplica la búsqueda por nombre/NIF/número y el orden, sin volver a leer la base de datos.</summary>
        private void Mostrar(decimal? seleccionar)
        {
            IEnumerable<FilaFactura> lista = filas;

            string buscar = textBox1.Text.Trim();
            if (buscar.Length > 0)
            {
                lista = lista.Where(f =>
                    f.Cliente.IndexOf(buscar, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                    f.Nif.IndexOf(buscar, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                    f.Numero.IndexOf(buscar, StringComparison.CurrentCultureIgnoreCase) >= 0);
            }

            switch (Convert.ToString(comboBox1.SelectedItem))
            {
                case "Código":
                    lista = lista.OrderBy(f => f.CodigoCliente).ThenBy(f => f.Fecha);
                    break;
                case "Nombre":
                    lista = lista.OrderBy(f => f.Cliente).ThenBy(f => f.Fecha);
                    break;
                case "Fecha":
                    lista = lista.OrderByDescending(f => f.Fecha).ThenBy(f => f.Serie).ThenByDescending(f => f.NumeroFactura);
                    break;
                default: // Número
                    lista = lista.OrderByDescending(f => f.Ejercicio).ThenBy(f => f.Serie).ThenByDescending(f => f.NumeroFactura);
                    break;
            }

            var mostradas = lista.ToList();
            dgvfactura.DataSource = mostradas;

            labelResumen.Text = mostradas.Count + (mostradas.Count == 1 ? " factura" : " facturas") +
                                "   ·   Base: " + mostradas.Sum(f => f.Base).ToString("N2", Es) + " €" +
                                "   ·   Total: " + mostradas.Sum(f => f.Total).ToString("N2", Es) + " €";

            dgvfactura.ClearSelection();
            if (seleccionar.HasValue)
            {
                foreach (DataGridViewRow fila in dgvfactura.Rows)
                {
                    if (((FilaFactura)fila.DataBoundItem).Id == seleccionar.Value)
                    {
                        dgvfactura.CurrentCell = fila.Cells["colNumero"];
                        fila.Selected = true;
                        break;
                    }
                }
            }
        }

        private List<FilaFactura> Seleccionadas()
        {
            return dgvfactura.SelectedRows.Cast<DataGridViewRow>()
                .Select(r => (FilaFactura)r.DataBoundItem)
                .OrderBy(f => f.Serie).ThenBy(f => f.Ejercicio).ThenBy(f => f.NumeroFactura)
                .ToList();
        }

        // =====================================================================
        //  Acciones
        // =====================================================================

        private void sumar_Click(object sender, EventArgs e)
        {
            using (var form = new FacturaUnitaria())
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.FacturaGrabada.HasValue)
                {
                    Cargar(form.FacturaGrabada);
                }
                else
                {
                    Cargar(null);
                }
            }
        }

        private void dgvclientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            VerFactura(((FilaFactura)dgvfactura.Rows[e.RowIndex].DataBoundItem).Id);
        }

        private void dgvfactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvfactura.CurrentRow != null)
            {
                e.Handled = true;
                VerFactura(((FilaFactura)dgvfactura.CurrentRow.DataBoundItem).Id);
            }
        }

        private void VerFactura(decimal id)
        {
            using (var form = new FacturaUnitaria(id))
            {
                form.ShowDialog(this);
            }
            Cargar(id);   // por si se ha impreso
        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            var elegidas = Seleccionadas();
            if (elegidas.Count == 0)
            {
                MessageBox.Show("Selecciona en la lista las facturas que quieres imprimir.\n" +
                                "(Con Ctrl o Mayús puedes seleccionar varias.)", "Imprimir facturas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (elegidas.Count > 1 &&
                MessageBox.Show("Se va a crear el PDF de " + elegidas.Count + " facturas en la carpeta de cada cliente.\n¿Continuar?",
                    "Imprimir facturas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            var errores = new List<string>();
            Cursor = Cursors.WaitCursor;
            try
            {
                foreach (var f in elegidas)
                {
                    try
                    {
                        FacturasUtil.GenerarPdf(f.Id, elegidas.Count == 1);
                    }
                    catch (Exception ex)
                    {
                        var interna = ex;
                        while (interna.InnerException != null) interna = interna.InnerException;
                        errores.Add(f.Numero + ": " + interna.Message);
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (errores.Count > 0)
            {
                MessageBox.Show("No se han podido crear estos PDF:\n\n" + string.Join("\n", errores.Take(15)),
                    "Imprimir facturas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (elegidas.Count > 1)
            {
                MessageBox.Show(elegidas.Count + " PDF creados en las carpetas de facturación de cada cliente.",
                    "Imprimir facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cargar(elegidas.Count == 1 ? elegidas[0].Id : (decimal?)null);
        }

        /// <summary>Envía por correo las facturas seleccionadas (también se pueden reenviar).</summary>
        private void enviar_Click(object sender, EventArgs e)
        {
            var elegidas = Seleccionadas();
            if (elegidas.Count == 0)
            {
                MessageBox.Show("Selecciona en la lista las facturas que quieres enviar por correo.\n" +
                                "(Con Ctrl o Mayús puedes seleccionar varias.)", "Envío por correo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var sinMail = elegidas.Where(f => !f.PorMail).ToList();
            var yaEnviadas = elegidas.Where(f => f.Enviada).ToList();
            string pregunta = "Se van a enviar por correo " + elegidas.Count + (elegidas.Count == 1 ? " factura" : " facturas") +
                              " al email que tiene cada una.";
            if (yaEnviadas.Count > 0) pregunta += "\n\n" + yaEnviadas.Count + " ya se habían enviado antes y se volverán a enviar.";
            if (sinMail.Count > 0) pregunta += "\n\n" + sinMail.Count + " son de clientes que no tienen marcado \"por mail\" (se enviarán igualmente si tienen email).";
            pregunta += "\n\n¿Enviarlas?";

            EnvioFacturas.PreguntarYEnviar(this, elegidas.Select(f => f.Id).ToList(), pregunta);
            Cargar(elegidas.Count == 1 ? elegidas[0].Id : (decimal?)null);
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // =====================================================================
        //  Rótulos que aparecen al pasar el ratón
        // =====================================================================

        private void sumar_MouseEnter(object sender, EventArgs e) { label1.Visible = true; }
        private void sumar_MouseLeave(object sender, EventArgs e) { label1.Visible = false; }
        private void imprimir_MouseEnter(object sender, EventArgs e) { label8.Visible = true; }
        private void imprimir_MouseLeave(object sender, EventArgs e) { label8.Visible = false; }
        private void enviar_MouseEnter(object sender, EventArgs e) { labelEnviar.Visible = true; }
        private void enviar_MouseLeave(object sender, EventArgs e) { labelEnviar.Visible = false; }
        private void panel1_MouseEnter(object sender, EventArgs e) { label4.Visible = true; }
        private void panel1_MouseLeave(object sender, EventArgs e) { label4.Visible = false; }
        private void panelEjercicio_MouseEnter(object sender, EventArgs e) { labelEjercicio.Visible = true; }
        private void panelEjercicio_MouseLeave(object sender, EventArgs e) { labelEjercicio.Visible = false; }
        private void panelSerie_MouseEnter(object sender, EventArgs e) { labelSerie.Visible = true; }
        private void panelSerie_MouseLeave(object sender, EventArgs e) { labelSerie.Visible = false; }
        private void panel2_MouseEnter(object sender, EventArgs e) { label6.Visible = true; }
        private void panel2_MouseLeave(object sender, EventArgs e) { label6.Visible = false; }
        private void salir_MouseEnter(object sender, EventArgs e) { label5.Visible = true; }
        private void salir_MouseLeave(object sender, EventArgs e) { label5.Visible = false; }
    }
}
