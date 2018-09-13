using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;
using BaseDatos;
using System.IO.Compression;
using Ionic.Zip;



namespace Proyecto_Antonio_Luis.Formularios
{





    public partial class Scaner : Form
    {

        AdministracionAntonioEntities bd;

        public Scaner()
        {
            InitializeComponent();
            
            bd = new AdministracionAntonioEntities();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            // esto comprueba que las facturas corresponde a un año nuevo
            //por lo que deberia reiniciar la numeracion de las facturas

            // extrae el año de la ultima factuar
            string yearfactura = (bd.Facturas.OrderByDescending(x => x.factfecha).First().factfecha.Split('/').Last());


            // string yearfactura = (bd.Facturas.OrderByDescending(X=> X.factnumerofact.tol);
            textBox1.Text = yearfactura.ToString();


            string yearactual = yearfactura.Split('/').Last();
            textBox2.Text = yearactual;

            int fechaHoy = DateTime.Now.Year;
            textBox1.Text = Convert.ToString(fechaHoy);

            if (fechaHoy <= Convert.ToInt16(yearactual))
                {
                    MessageBox.Show("es menor, mismo año");
                }
            else
            {
                    MessageBox.Show("año nuevo");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {


        }


       




        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //no usaremos código try/catch aquí, a no ser que después hagamos un throw de la excepción capturada.
            //es necesario dejar que el backgroundworker sea quien capture cualquier excepción producida.
            //si se produce una excepción, el control la disponibilizará una vez haya finalizado su ejecución,
            //y disparado el evento "backgroundWorker1_RunWorkerCompleted"
            //the RunWorkerCompletedEventArgs object, method backgroundWorker1_RunWorkerCompleted
            //try
            //{
           // DateTime start = DateTime.Now;
            e.Result = "";

            //   static void Main(string[] args)
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(@"C:\ByMartin", "ByMartin");
                //  zip.AddDirectory(@"C:\Carpeta2", "Carpeta2");
                zip.Comment = "Archivo comprimido el " + System.DateTime.Now.ToString("G");
                zip.Save(@"C:\ByMartin\COPIA DE SEGURIDADArchivoCreado.zip");
            }


            //         for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(50); //simulamos trabajo

                //hemos completado un porcentaje del trabajo previsto, luego notificamos de ello.
          //      int paso = 10;
                backgroundWorker1.ReportProgress(10) ;

                //descomenta este código para ver como esta excepción es gestionada por el
                //control backgroundworker
                //descomenta también el atributo indicado arriba para evitar que el depurador
                //pare en la excepción, ya que queremos simular
                //el comportamiento del control en tiempo de ejecución.
                //if (i == 34)
                //    throw new Exception("something wrong here!!");

            }

            //       TimeSpan duration = DateTime.Now - start;

            //aquí podríamos devolver información de utilidad, como el resultado de un cálculo,
            //número de elementos afectados, etc.. de manera sencilla y segura
            //al hilo principal
            e.Result = "Clientes Completados.";
            //}
            //catch(Exception ex){
            //    MessageBox.Show("Don't use try catch here!");
            //}
       

    }



        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                MessageBox.Show("The task has been cancelled");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString());
            }
            else
            {
                MessageBox.Show("The task has been completed. Results: " + e.Result.ToString());
            }


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage; //actualizamos la barra de progreso
            string time = (e.UserState.ToString()); //obtenemos información adicional si procede

            //en este ejemplo, logamos a un textbox
            txt.AppendText(time);
            txt.AppendText(Environment.NewLine);
        }
    }



     
}


   












