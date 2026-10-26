using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BaseDatos;
using Proyecto_Antonio_Luis.Clases;

namespace Proyecto_Antonio_Luis.Formularios
{
    /// <summary>
    /// Lista de clientes: alta, modificación (incluida la baja temporal,
    /// desmarcando "Activo") y eliminación definitiva.
    /// </summary>
    public partial class GestionClientes : Form
    {
        public GestionClientes()
        {
            InitializeComponent();
        }

        private void GestionClientes_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Nombre";
            CargarClientes();
        }

        // =====================================================================
        //  Carga del listado
        // =====================================================================

        /// <summary>
        /// Recarga la lista aplicando el texto de búsqueda y el orden elegidos.
        /// Usa un contexto nuevo cada vez para ver siempre los datos actuales.
        /// </summary>
        private void CargarClientes(decimal? seleccionarCodigo = null)
        {
            try
            {
                List<Clientes> lista;
                using (var bd = new AdministracionAntonioEntities())
                {
                    IQueryable<Clientes> consulta = bd.Clientes.AsNoTracking();

                    string buscar = textBox1.Text.Trim();
                    if (buscar.Length > 0)
                    {
                        decimal codigoBuscado;
                        bool esCodigo = decimal.TryParse(buscar, out codigoBuscado);
                        consulta = consulta.Where(c => c.nombrecliente.Contains(buscar)
                                                    || c.cifcliente.Contains(buscar)
                                                    || (esCodigo && c.codcliente == codigoBuscado));
                    }

                    consulta = comboBox1.Text == "Código"
                        ? consulta.OrderBy(c => c.codcliente)
                        : consulta.OrderBy(c => c.nombrecliente);

                    lista = consulta.ToList();
                }

                dgvclientes.DataSource = lista;

                // Los clientes de baja se ven en gris
                foreach (DataGridViewRow fila in dgvclientes.Rows)
                {
                    var c = fila.DataBoundItem as Clientes;
                    if (c != null && c.activocliente != true)
                    {
                        fila.DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
                    }
                }

                if (seleccionarCodigo.HasValue)
                {
                    SeleccionarFila(seleccionarCodigo.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido cargar la lista de clientes.\n\n" + MensajeInterno(ex),
                    "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarFila(decimal codigo)
        {
            foreach (DataGridViewRow fila in dgvclientes.Rows)
            {
                var c = fila.DataBoundItem as Clientes;
                if (c != null && c.codcliente == codigo)
                {
                    fila.Selected = true;
                    dgvclientes.CurrentCell = fila.Cells.Cast<DataGridViewCell>().First(x => x.Visible);
                    return;
                }
            }
        }

        /// <summary>Cliente de la fila seleccionada, o null si no hay ninguna.</summary>
        private Clientes ClienteSeleccionado()
        {
            if (dgvclientes.CurrentRow == null)
            {
                return null;
            }
            return dgvclientes.CurrentRow.DataBoundItem as Clientes;
        }

        // =====================================================================
        //  Alta
        // =====================================================================

        private void sumar_Click(object sender, EventArgs e)
        {
            Globales.llamadas = "1";
            using (var form = new Cliente())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    // Al grabar, Cliente deja el código asignado en Globales.modificar
                    CargarClientes(Globales.modificar);
                }
            }
        }

        // =====================================================================
        //  Modificación
        // =====================================================================

        private void modificar_Click(object sender, EventArgs e)
        {
            AbrirModificacion();
        }

        private void dgvclientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AbrirModificacion();
            }
        }

        private void AbrirModificacion()
        {
            var seleccionado = ClienteSeleccionado();
            if (seleccionado == null || !seleccionado.codcliente.HasValue)
            {
                MessageBox.Show("Selecciona primero un cliente de la lista.", "Modificar cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal codigo = seleccionado.codcliente.Value;
            Globales.llamadas = "2";
            Globales.modificar = Convert.ToInt32(codigo);

            using (var form = new Cliente())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    CargarClientes(codigo);
                }
            }
        }

        // =====================================================================
        //  Eliminar: borrado DEFINITIVO del cliente, tras varios avisos.
        //  (Para una baja temporal, p. ej. baja en Hacienda, no se elimina:
        //   se desmarca "Activo" en la ficha y el cliente conserva sus datos.)
        //  Las facturas ya emitidas no se tocan (guardan su propia copia de los
        //  datos del cliente) ni tampoco su carpeta de documentos.
        // =====================================================================

        private void eliminar_Click(object sender, EventArgs e)
        {
            var seleccionado = ClienteSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Selecciona primero un cliente de la lista.", "Eliminar cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombre = (seleccionado.nombrecliente ?? "").Trim();
            string codigo = seleccionado.codcliente.HasValue ? seleccionado.codcliente.Value.ToString("0") : "-";
            string titulo = codigo + " - " + nombre;

            // Aviso 1: si está activo, quizá lo que se quiere es darlo de baja
            if (seleccionado.activocliente == true)
            {
                if (MessageBox.Show(
                        "El cliente " + titulo + " está ACTIVO.\n\n" +
                        "Si solo quieres que deje de facturarse durante un tiempo (por ejemplo, " +
                        "baja temporal en Hacienda), no lo elimines: ábrelo con Modificar y " +
                        "desmarca \"Activo\". Así conserva todos sus datos y podrás reactivarlo.\n\n" +
                        "¿Quieres ELIMINARLO de todas formas?",
                        "Eliminar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }
            }

            // Aviso 2: facturas pendientes de domiciliar o de contabilizar
            int pendientes = FacturasPendientes(seleccionado.codcliente);
            if (pendientes > 0)
            {
                if (MessageBox.Show(
                        "El cliente " + titulo + " tiene " + pendientes +
                        " factura(s) pendiente(s) de domiciliar o de contabilizar.\n\n" +
                        "Las facturas no se borran, pero conviene terminar de tramitarlas antes.\n\n" +
                        "¿Continuar con la eliminación?",
                        "Eliminar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }
            }

            // Aviso 3: confirmación final
            string aviso =
                "Se va a ELIMINAR DEFINITIVAMENTE el cliente:\n\n" +
                "   " + titulo + "\n\n" +
                "Esta acción NO se puede deshacer.\n\n" +
                "- Las facturas ya emitidas no se borran.\n" +
                "- Su carpeta de documentos no se borra:\n   " + ClientesUtil.CarpetaCliente(nombre) + "\n" +
                "- Su código no se volverá a usar para otro cliente.\n\n" +
                "¿ELIMINAR el cliente?";

            if (MessageBox.Show(aviso, "Eliminar cliente - confirmación final", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (var bd = new AdministracionAntonioEntities())
                {
                    var borrar = bd.Clientes.Find(seleccionado.numerador);
                    if (borrar != null)
                    {
                        bd.Clientes.Remove(borrar);
                        bd.SaveChanges();
                    }
                }
                CargarClientes();
                MessageBox.Show("Cliente " + titulo + " eliminado.", "Eliminar cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido eliminar el cliente.\n\n" + MensajeInterno(ex),
                    "Eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Facturas del cliente pendientes de domiciliar o de contabilizar.</summary>
        private static int FacturasPendientes(decimal? codigo)
        {
            if (!codigo.HasValue)
            {
                return 0;
            }
            try
            {
                using (var bd = new AdministracionAntonioEntities())
                {
                    decimal cod = codigo.Value;
                    return bd.Facturas.Count(f => f.factcodcliente == cod &&
                        ((f.factparadomiciliar == true && f.factdomiciliada != true) ||
                         (f.factparacontabilizar == true && f.factcontabilizada != true)));
                }
            }
            catch
            {
                return 0;
            }
        }

        // =====================================================================
        //  Búsqueda y orden
        // =====================================================================

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        // =====================================================================
        //  Salir
        // =====================================================================

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // =====================================================================
        //  Etiquetas de ayuda al pasar el ratón por los botones
        // =====================================================================

        private void sumar_MouseEnter(object sender, EventArgs e) { label1.Visible = true; }
        private void sumar_MouseLeave(object sender, EventArgs e) { label1.Visible = false; }
        private void eliminar_MouseEnter(object sender, EventArgs e) { label2.Visible = true; }
        private void eliminar_MouseLeave(object sender, EventArgs e) { label2.Visible = false; }
        private void modificar_MouseEnter(object sender, EventArgs e) { label3.Visible = true; }
        private void modificar_MouseLeave(object sender, EventArgs e) { label3.Visible = false; }
        private void buscar_MouseEnter(object sender, EventArgs e) { label4.Visible = true; }
        private void buscar_MouseLeave(object sender, EventArgs e) { label4.Visible = false; }
        private void salir_MouseEnter(object sender, EventArgs e) { label5.Visible = true; }
        private void salir_MouseLeave(object sender, EventArgs e) { label5.Visible = false; }
        private void panel1_MouseEnter(object sender, EventArgs e) { label4.Visible = true; }
        private void panel1_MouseLeave(object sender, EventArgs e) { label4.Visible = false; }
        private void textBox1_MouseEnter(object sender, EventArgs e) { label4.Visible = true; }
        private void textBox1_MouseLeave(object sender, EventArgs e) { label4.Visible = false; }
        private void panel2_MouseEnter(object sender, EventArgs e) { label6.Visible = true; }
        private void panel2_MouseLeave(object sender, EventArgs e) { label6.Visible = false; }
        private void comboBox1_MouseEnter(object sender, EventArgs e) { label6.Visible = true; }
        private void comboBox1_MouseLeave(object sender, EventArgs e) { label6.Visible = false; }

        private static string MensajeInterno(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex.Message;
        }
    }
}
