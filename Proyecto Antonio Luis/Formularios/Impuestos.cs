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
        string llamada;


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





        //************************************************************************************************************
        //************************************************************************************************************
        //************************************************************************************************************
        //*****************                                                                              *************
        //*****************        Aqui termina los eventos al pasar el mousse                           *************
        //*****************                                                                              *************
        //************************************************************************************************************
        //************************************************************************************************************
        //************************************************************************************************************


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
            
            llamada = "1";
            panel1.Visible = true;
            sumar.Enabled = false;
            modificar.Enabled = false;
            eliminar.Enabled = false;
            salir.Visible = false;
            boxconcepto.Text = "";
            boxiva.Text = "";
            boxiva.Text = "";

            

        }

        private void modificar_Click(object sender, EventArgs e)
        {
            llamada = "2";
            panel1.Visible = true;
            sumar.Enabled = false;
            modificar.Enabled = false;
            eliminar.Visible = false;
            salir.Visible = false;




            int columna = 0;
            int fila = Convert.ToInt16(dataGridViewIVAs.CurrentRow.Index);

            boxconcepto.Text = dataGridViewIVAs[columna,fila].Value.ToString();           
            boxiva.Text = dataGridViewIVAs[columna + 1, fila].Value.ToString();
            boxrecargo.Text = dataGridViewIVAs[columna + 2, fila].Value.ToString();



        }

        private void eliminar_Click(object sender, EventArgs e)
        {

        }


        private void salir_Click(object sender, EventArgs e)
        {
            Close();
            
        }





        private void buttonAceptar_Click(object sender, EventArgs e)
        {



            // realiza esto si es llamado desde el boton añadir


            if (llamada == "1")
            {


                try
                {
                    //**** calculamos el valor de la coluna numerador
                    var ultimonumerador = baseDeDatos.Iva.OrderByDescending(x => x.numerador).First().numerador;

                    //****GRABA LOS DATOS EN LA TABLA
                    var nuevoiva = new Iva();
                    nuevoiva.numerador = ultimonumerador + 1;
                    nuevoiva.ivaconcepto = boxconcepto.Text;
                    nuevoiva.ivaporciento = Convert.ToDecimal(boxiva.Text);
                    nuevoiva.ivarecargo = Convert.ToDecimal(boxrecargo.Text);

                    baseDeDatos.Iva.Add(nuevoiva);

                    //guardamos los cambios
                    baseDeDatos.SaveChanges();

                }
                catch (Exception exp)
                {

                }
                // Refrescamos el dbgrid
                dataGridViewIVAs.DataSource = baseDeDatos.Iva.ToList();

                //Conectamos lo sbotones y hacemos invisible el panel
                sumar.Enabled = true;
                modificar.Enabled = true;
                eliminar.Enabled = true;
                salir.Visible = true;
                panel1.Visible = false;


             }

            // esto lo hace si llamamos desde modificar

            if (llamada == "2")
            {






            }

            


                




                
  // ejemplo de como se borra
  /*
                //*** borrar
                var ivaABorrar = baseDeDatos.Iva.SingleOrDefault(iva => iva.numerador == "11");
                if (ivaABorrar != null)
                {
                    baseDeDatos.Iva.Remove(ivaABorrar);
                }
*/

            



  
          }
    
  
        private void button2_Click(object sender, EventArgs e)
        {
            
            sumar.Enabled = true;
            modificar.Enabled = true;
            eliminar.Enabled = true;
            salir.Visible = true;
            panel1.Visible = false;
        }

        private void boxconcepto_TextChanged(object sender, EventArgs e)
        {

        }

        private void ivaBindingSource_CurrentChanged(object sender, EventArgs e)
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
