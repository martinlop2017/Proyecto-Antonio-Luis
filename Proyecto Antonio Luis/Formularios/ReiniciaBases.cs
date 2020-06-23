using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Data.SqlClient;
using BaseDatos;


namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class ReiniciaBases : Form
    {
        int contador = 0;
        AdministracionAntonioEntities bd;
        public ReiniciaBases()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();

        }

        private void ReiniciaBases_Load(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("La aplicación a detectado que el año de facturación ha cambiado.\n Se va a proceder a reiniciar las tablas, este proceso puede tardar.", "Reinicio de Tablas", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


           


                      
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                MessageBox.Show("El reinicio ha sido cancelado.","Operacion Cancelada.");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Se ha producido un error al reiniciar las Tablas. Mas detalles: " +
                    (e.Error as Exception).ToString(),"Operación incompleta.");
            }
            else
            {

                progressBar1.Value = 11;
                MessageBox.Show("Operación realizada satisfactoriamente.\n La aplicación se cerrará, una vez abierta podrá trabajar con normalidad." + e.Result.ToString(),
                 "Reinicio Tablas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            contador++;

            switch (contador)
            {
                case 1:
                    label3.Text = "Preparando Archivos.";

                    break;
                case 2:
                    label3.Text = "Copiando Tablas.";
                    break;
                case 5:
                    label3.Text = "Borrando Tablas.";
                    break;
                case 6:
                    label3.Text = "Acondiacionando Tablas.";
                    break;
                case 7:
                    label3.Text = "Operacion Finalizada.";
                    break;

                default:

                    break;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            


            e.Result = "";
            backgroundWorker1.ReportProgress(10);
            Thread.Sleep(900);

            // creamos las variables que guardaran año historico y directorio.
            string directorio, oldyear;

            //extraemos el valor de oldyear
            StreamReader sr = new StreamReader("C:\\ByMartin\\Tmp\\Systemyear.txt");
            oldyear = sr.ReadLine();
            sr.Close();

            // Cargamos el valor a directorio
            directorio = "Historico" + oldyear;


            backgroundWorker1.ReportProgress(10);
            Thread.Sleep(2000);
            // realizamos la copia de seguridad de la tabla y la almacenamos en la carpeta Tmp

            string sBackup = "BACKUP DATABASE " + "AdministracionAntonio" +
                " TO DISK = N'" + @"C:\ByMartin\Historico\Sql" + directorio +
                "' WITH NOFORMAT, NOINIT, NAME =N'" + "AdministracionAntonio" +
                "', SKIP,NOREWIND, NOUNLOAD,  STATS = 10";


            backgroundWorker1.ReportProgress(10);

            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();

            csb.DataSource = @"DESKTOP-UKKKNCG\SQLEXPRESS";// this.txtServidor.Text;
            csb.InitialCatalog = @"AdministracionAntonio";
            csb.IntegratedSecurity = true;

            backgroundWorker1.ReportProgress(10);

            using (SqlConnection con = new SqlConnection(csb.ConnectionString))
            {
                con.Open();
                SqlCommand cmdBackUp = new SqlCommand(sBackup, con);
                cmdBackUp.ExecuteNonQuery();
                con.Close();


            }
            backgroundWorker1.ReportProgress(10);


            {
                //borramos los registros de las tabla resilla
                var borrarresilla = bd.Resilla.Where(x => x.remesanumerador > 0).ToList();

                bd.Resilla.RemoveRange(borrarresilla);
                bd.SaveChanges();

                //borrando los registro de la tabla Facturas
                var borrarfacturas = bd.Facturas.Where(x => x.factcontador > 0).ToList();

                bd.Facturas.RemoveRange(borrarfacturas);
                bd.SaveChanges();
            }


            {
                //actualiza los datos del txt con el año actual

                // borra el archivo para sustituirlo por uno nuevo
                File.Delete("C:\\ByMartin\\Tmp\\Systemyear.txt");

                //crea el nuevo con la fecha actual
                StreamWriter sw = File.CreateText("C:\\ByMartin\\Tmp\\Systemyear.txt");

                sw.WriteLine(DateTime.Now.ToString("yyyy"));
                sw.Close();
            }



                        backgroundWorker1.ReportProgress(10);
                        Thread.Sleep(2500);

                        backgroundWorker1.ReportProgress(10);

             

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para un correcto funcionamiento es nescesario reiniciar las tablas.\n  Si tiene alguna dudas contacte con el propietario del Software.", "Reinicio Tablas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //lanza el evento en segudo plano
            panel1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
