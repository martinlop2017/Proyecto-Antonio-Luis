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
    public partial class GestionUsuarios : Form
    {
        AdministracionAntonioEntities bd;
        

        public GestionUsuarios()
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



        private void button1_Click(object sender, EventArgs e)
        {
            // Inicializa la variable global llamadas
            Globales.llamadas = "1";

            // Abre Ususarios
            Usuario form = new Usuario();
            form.Show();


        }

        private void eliminar_Click(object sender, EventArgs e)
        {

            try
            {
               


                if (MessageBox.Show("Confirme La Eliminación del Registro.","Eliminar Registro", 
                    MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes)
                {


                    // creamos una variable que va aguardar los datos de la fila seleccionada en el dbgrid

                    int valor1 = Convert.ToInt16(dgvUsuario.CurrentRow.Cells[0].Value);

                    //*** borrar
                    //busca en la tabla la fila con el registro suminstrado
                    //y si lo encuentra borra la linea de la base de datos

                    var borrar = bd.Ususarios.SingleOrDefault(codusuario => codusuario.cod == valor1);
                    if (borrar != null)
                    {
                        bd.Ususarios.Remove(borrar);
                    }


                    //guardamos los cambios
                    bd.SaveChanges();

                    // Refrescamos el dbgrid
                    dgvUsuario.DataSource = bd.Ususarios.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No ha sido posible eliminar los datos", "Error 103");
            }
        }


        private void modificar_Click(object sender, EventArgs e)
        {
            // Inicializa la variable global llamadas
            Globales.llamadas = "2";

            // creamos una variable que va aguardar los datos de la fila seleccionada en el dbgrid
            Globales.modificar =  Convert.ToInt16(dgvUsuario.CurrentRow.Cells[0].Value);

            // Abre Ususarios
            Usuario form = new Usuario();
            form.Show();
        }

        private void buscar_Click(object sender, EventArgs e)
        {

        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
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

        private void dataGridViewArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {

            //CARGA LOS REGISTROS EN EL GRIP AL INICIAR EL FORM

            dgvUsuario.DataSource = bd.Ususarios.ToList();
            dgvUsuario.Refresh();

            dgvUsuario.DataSource = "";
            dgvUsuario.DataSource = bd.Ususarios.ToList();
            dgvUsuario.Refresh();

        }

        private void GestionUsuarios_Activated(object sender, EventArgs e)
        {


            dgvUsuario.DataSource = "";
            dgvUsuario.DataSource = bd.Ususarios.ToList();
            dgvUsuario.Refresh();

        }

        private void GestionUsuarios_Enter(object sender, EventArgs e)
        {
            dgvUsuario.DataSource = "";
            dgvUsuario.DataSource = bd.Ususarios.ToList();
            dgvUsuario.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
