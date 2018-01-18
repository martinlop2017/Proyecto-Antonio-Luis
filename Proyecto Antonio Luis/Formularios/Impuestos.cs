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

        AdministracionAntonioEntities bd;
 


        public Impuestos()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }

        private void dataGridViewIVAs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Impuestos_Load(object sender, EventArgs e)
        {
            //CARGA LOS REGISTROS EN EL GRIP AL INICIAR EL FORM

            dgvIva.DataSource = bd.Iva.ToList();

          //  dgvIva.DataSource = baseDeDatos.Iva.ToList();





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

            Globales.llamadas = "1";
           // llamada = "1";
            panel1.Visible = true;
            sumar.Enabled = false;
            modificar.Enabled = false;
            eliminar.Enabled = false;
            salir.Visible = false;
            boxconcepto.Text = "";
            boxiva.Text = "";
            boxrecargo.Text = "";

            

        }

        private void modificar_Click(object sender, EventArgs e)
        {
            Globales.llamadas = "2";
            panel1.Visible = true;
            sumar.Enabled = false;
            modificar.Enabled = false;
            eliminar.Enabled = false;
            salir.Visible = false;




           // int columna = 0;
            int fila = Convert.ToInt16(dgvIva.CurrentRow.Index);

            boxconcepto.Text = dgvIva[1,fila].Value.ToString();           
            boxiva.Text = dgvIva[2, fila].Value.ToString();
            boxrecargo.Text = dgvIva[3, fila].Value.ToString();



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


            if (Globales.llamadas == "1")
            {


                try
                {
                    //**** calculamos el valor de la coluna numerador
                    var ultimonumerador = bd.Iva.OrderByDescending(x => x.numerador).First().numerador;

                    //****GRABA LOS DATOS EN LA TABLA
                    var nuevoiva = new Iva();
                    
                    nuevoiva.numerador = ultimonumerador + 1;
                    nuevoiva.ivaconcepto = boxconcepto.Text;
                    nuevoiva.ivaporciento = Convert.ToDecimal(boxiva.Text);
                    nuevoiva.ivarecargo = Convert.ToDecimal(boxrecargo.Text);
                    

                    bd.Iva.Add(nuevoiva);

                    //guardamos los cambios
                    bd.SaveChanges();

                }
                catch (Exception)
                {

                }
                // Refrescamos el dbgrid
                dgvIva.DataSource = bd.Iva.ToList();

                //Conectamos lo sbotones y hacemos invisible el panel
                sumar.Enabled = true;
                modificar.Enabled = true;
                eliminar.Enabled = true;
                salir.Visible = true;
                panel1.Visible = false;


             }

            // esto lo hace si llamamos desde modificar

            if (Globales.llamadas == "2")
            {
                //Primero extraemos el valor de la columna numerador 
                int valor1 = Convert.ToInt16(dgvIva.CurrentRow.Cells[0].Value);

                //extraemos los datos correspondientes de la tabla en el objeto
                var ivaAmodificar = bd.Iva.SingleOrDefault(iva => iva.numerador == valor1);


                
                //modificamos los valores
                ivaAmodificar.ivaconcepto = boxconcepto.Text;
                ivaAmodificar.ivaconcepto = boxconcepto.Text;
                ivaAmodificar.ivaporciento = Convert.ToDecimal(boxiva.Text);
                ivaAmodificar.ivarecargo = Convert.ToDecimal(boxrecargo.Text);


                //guardamos los cambios
                bd.SaveChanges();

                // Refrescamos el dbgrid
                dgvIva.DataSource = bd.Iva.ToList();

            }

 
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

        private void eliminar_Click_1(object sender, EventArgs e)
        {
            // creamos una variable que va aguardar los datos de la fila seleccionada en el dbgrid

            int valor1 = Convert.ToInt16(dgvIva.CurrentRow.Cells[0].Value);
            
            //*** borrar
            //busca en la tabla la fila con el registro suminstrado
            //y si lo encuentra borra la linea de la base de datos

            var borrar = bd.Iva.SingleOrDefault(iva => iva.numerador == valor1);
            if (borrar != null)
            {
                bd.Iva.Remove(borrar);
            }


            //guardamos los cambios
            bd.SaveChanges();

            // Refrescamos el dbgrid
            dgvIva.DataSource = bd.Iva.ToList();
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
