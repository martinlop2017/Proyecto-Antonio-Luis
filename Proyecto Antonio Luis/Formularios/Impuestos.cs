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
using System.Data.SqlClient;



namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class Impuestos : Form
    {

        AdministracionAntonioEntities baseDeDatos;


        public Impuestos()
        {
            InitializeComponent();
            baseDeDatos = new AdministracionAntonioEntities();
        }

        private void dataGridViewIVAs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Impuestos_Load(object sender, EventArgs e)
        {


            dataGridViewIVAs.DataSource = baseDeDatos.Iva.ToList();





        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                var nuevoiva = new Iva();
                nuevoiva.ivaconcepto = "fff concpeto";
                nuevoiva.ivaporciento = 3;
                nuevoiva.numerador = "111";




                baseDeDatos.Iva.Add(nuevoiva);

//*** borrar
                var ivaABorrar = baseDeDatos.Iva.Single(iva => iva.numerador == "11");
                baseDeDatos.Iva.Remove(ivaABorrar);
              //**

                // Guardamos los cambios

                baseDeDatos.SaveChanges();
            }
            catch(Exception exp)
            {

            }

            dataGridViewIVAs.DataSource = baseDeDatos.Iva.ToList();




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

        private void salir_MouseEnter(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void salir_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
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
