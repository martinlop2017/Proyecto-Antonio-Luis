using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseDatos;


namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class GestionFacturas : Form
    {
        AdministracionAntonioEntities bd;

        public GestionFacturas()
        {
            InitializeComponent();

            bd = new AdministracionAntonioEntities();
        }

        private void sumar_MouseEnter(object sender, EventArgs e)
        {
            label1.Visible = true;
        }

        private void sumar_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void eliminar_MouseEnter(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void eliminar_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void modificar_MouseEnter(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void modificar_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible =false;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            label4.Visible = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            label4.Visible = true;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            label6.Visible = true;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            label6.Visible = true;
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void salir_MouseEnter(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void salir_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void GestionFacturas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'administracionAntonioDataSet1.Facturas' Puede moverla o quitarla según sea necesario.
            this.facturasTableAdapter.Fill(this.administracionAntonioDataSet1.Facturas);

            comboBox1.Text = "Número";
        }

        private void dgvclientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void imprimir_MouseEnter(object sender, EventArgs e)
        {
            label8.Visible = true;
        }

        private void imprimir_MouseLeave(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Número")
            {
                dgvclientes.DataSource = bd.Facturas.OrderBy(x => x.factnumerofact).ToList();
            }
            if (comboBox1.Text == "Código")
            {
                dgvclientes.DataSource = bd.Facturas.OrderBy(x => x.factcodcliente).ToList();
            }

            if (comboBox1.Text == "Nombre")
            {
                dgvclientes.DataSource = bd.Facturas.OrderBy(x => x.factnombre).ToList();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var busqueda = from c in bd.Facturas select c;
            busqueda = busqueda.Where(c => c.factnombre.Contains(textBox1.Text)).OrderBy(x => x.factnombre);

            dgvclientes.DataSource = busqueda.ToList();
        }

        private void dgvclientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Esto lo que hace es mostrar los datos para modificar
            // Inicializa la variable global llamadas
            Globales.llamadas = "2";
            try
            {
                // creamos una variable que va aguardar los datos de la fila seleccionada en el dbgrid
                Globales.modificar = Convert.ToInt16(dgvclientes.CurrentRow.Cells [1].Value);
                // Abre Ususarios
                FacturaUnitaria form = new FacturaUnitaria();
                form.Show();


                dgvclientes.DataSource = "";
                dgvclientes.DataSource = bd.Facturas.ToList();
                dgvclientes.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Debe Seleccionar un registro.", "Error 303", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirme La Eliminación del Registro.", "Eliminar Registro",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    // creamos una variable que va aguardar los datos de la fila seleccionada en el dbgrid

                    int valor1 = Convert.ToInt16(dgvclientes.CurrentRow.Cells[1].Value);

                    //*** borrar
                    //busca en la tabla la fila con el registro suminstrado
                    //y si lo encuentra borra la linea de la base de datos

                    var borrar = bd.Facturas.SingleOrDefault(codcliente => codcliente.factnumerofact == valor1);
                    if (borrar != null)
                    {
                        bd.Facturas.Remove(borrar);
                    }
                    //guardamos los cambios
                    bd.SaveChanges();

                    // Refrescamos el dbgrid
                    dgvclientes.DataSource = bd.Facturas.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No ha sido posible eliminar los datos", "Error 103", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificar_Click(object sender, EventArgs e)
        {

            //Esto lo que hace es mostrar los datos para modificar
            // Inicializa la variable global llamadas
            Globales.llamadas = "2";
            try
            {
                // creamos una variable que va aguardar los datos de la fila seleccionada en el dbgrid
                Globales.modificar = Convert.ToInt16(dgvclientes.CurrentRow.Cells[1].Value);
                // Abre Ususarios
                FacturaUnitaria form = new FacturaUnitaria();
                form.Show();


                dgvclientes.DataSource = "";
                dgvclientes.DataSource = bd.Facturas.ToList();
                dgvclientes.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Debe Seleccionar un registro.", "Error 303", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sumar_Click(object sender, EventArgs e)
        {
            Globales.llamadas = "1";
            FacturaUnitaria form = new FacturaUnitaria();
            form.Show();
        }
    }
}
