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
using Proyecto_Antonio_Luis.Clases;
namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class GestionClientes : Form
    {

        AdministracionAntonioEntities bd;
        private List<string> originalClientValues;

        public GestionClientes()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }



        //============================================================================================================
        //============================================================================================================
        //============================================================================================================
        //=================                                                                               ============
        //=================                                                                               ============
        //=================      Aquí comineza las acciones al pulsar los distintos botones               ============
        //=================                                                                               ============
        //=================                                                                               ============
        //============================================================================================================
        //============================================================================================================
        //============================================================================================================

        private void sumar_Click(object sender, EventArgs e)
        {
          
            // Inicializa la variable global llamadas
            Globales.llamadas = "1";

            // Abre Clientes
              Cliente form = new Cliente();
            form.Show();

            dgvclientes.DataSource = "";
            dgvclientes.DataSource = bd.Clientes.OrderBy(x => x.nombrecliente).ToList();
            dgvclientes.Refresh();
        }



        //************************************************************************************************************
        //************************************************************************************************************
        //************************************************************************************************************
        //*****************                                                                              *************
        //*****************        Los eventos del mouse sobre los botones para mostrar las etiquetas    *************
        //*****************                                                                              *************
        //************************************************************************************************************
        //************************************************************************************************************
        //************************************************************************************************************

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
            label3.Visible = false;
        }

        private void buscar_MouseEnter(object sender, EventArgs e)
        {
            label4.Visible = true;
        }

        private void buscar_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void salir_MouseEnter(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void salir_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GestionClientes_Load(object sender, EventArgs e)
        {
            //CARGA LOS REGISTROS EN EL GRIP AL INICIAR EL FORM

            dgvclientes.DataSource = "";
            var cargaclientes = bd.Clientes.OrderBy(x => x.nombrecliente);
            dgvclientes.DataSource = cargaclientes.ToList();
            dgvclientes.Refresh();

        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirme La Eliminación del Registro.", "Eliminar Registro",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    // creamos una variable que va aguardar los datos de la fila seleccionada en el dbgrid

                    int valor1 = Convert.ToInt16(dgvclientes.CurrentRow.Cells[0].Value);

                    //*** borrar
                    //busca en la tabla la fila con el registro suminstrado
                    //y si lo encuentra borra la linea de la base de datos

                    var borrar = bd.Clientes.SingleOrDefault(codcliente => codcliente.numerador == valor1);
                    if (borrar != null)
                    {
                        bd.Clientes.Remove(borrar);
                    }
                    //guardamos los cambios
                    bd.SaveChanges();

                    // Refrescamos el dbgrid
                    dgvclientes.DataSource = bd.Clientes.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No ha sido posible eliminar los datos", "Error 103", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            // Inicializa la variable global llamadas
            Globales.llamadas = "2";
            try
            {
               // creamos una variable que va aguardar los datos de la fila seleccionada en el dbgrid
               Globales.modificar = Convert.ToInt16(dgvclientes.CurrentRow.Cells[0].Value);
                // Abre Ususarios
                Cliente form = new Cliente();
                form.Show();


                dgvclientes.DataSource = "";
                dgvclientes.DataSource = bd.Clientes.OrderBy(x=> x.nombrecliente). ToList();
                dgvclientes.Refresh();
            }
            catch (Exception)
            { 
                MessageBox.Show("Debe Seleccionar un registro.", "Error 303", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                
        }

        private void dgvclientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GestionClientes_MouseEnter(object sender, EventArgs e)
        {

        }

        private void GestionClientes_Enter(object sender, EventArgs e)
        {


        }

        private void GestionClientes_Activated(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {


        }

        private void comboBoxClientes_TextUpdate(object sender, EventArgs e)
        {

        }

        private void comboBoxClientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
         

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           

            var busqueda = from c in bd.Clientes select c;
            busqueda = busqueda.Where(c => c.nombrecliente.Contains(textBox1.Text));

            dgvclientes.DataSource = busqueda.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var busqueda = from c in bd.Clientes select c;
            busqueda = busqueda.Where(c => c.nombrecliente.Contains(textBox1.Text)).OrderBy(x=> x.nombrecliente);

            dgvclientes.DataSource = busqueda.ToList();
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

        private void dgvclientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Esto lo que hace es mostrar los datos para modificar
            // Inicializa la variable global llamadas
            Globales.llamadas = "2";
            try
            {
                // creamos una variable que va aguardar los datos de la fila seleccionada en el dbgrid
                Globales.modificar = Convert.ToInt16(dgvclientes.CurrentRow.Cells[0].Value);
                // Abre Ususarios
                Cliente form = new Cliente();
                form.Show();


                dgvclientes.DataSource = "";
                dgvclientes.DataSource = bd.Clientes.ToList();
                dgvclientes.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Debe Seleccionar un registro.", "Error 303", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {



        }


            //============================================================================================================
            //============================================================================================================
            //============================================================================================================
            //=================                                                                               ============
            //=================                                                                               ============
            //=================      Aquí termina las acciones al pulsar los distintos botones               ============
            //=================                                                                               ============
            //=================                                                                               ============
            //============================================================================================================
            //============================================================================================================
            //============================================================================================================







        }
}
