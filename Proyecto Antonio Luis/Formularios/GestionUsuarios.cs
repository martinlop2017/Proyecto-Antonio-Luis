using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class GestionUsuarios : Form
    {
        public GestionUsuarios()
        {
            InitializeComponent();
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
            // Abre Ususarios

            Usuarios form = new Usuarios();
            form.Show();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {

        }

        private void modificar_Click(object sender, EventArgs e)
        {

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
    }
}
