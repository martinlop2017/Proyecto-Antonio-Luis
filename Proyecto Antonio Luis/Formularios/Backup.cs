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
using System.Data;
using System.Data.SqlClient;
using Ionic.Zip;
using System.Threading;
using System.IO;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class Backup : Form
    {
        int contador = 0;
        public Backup()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if (e.Cancelled)
            {
                MessageBox.Show("El Backup ha sido cancelado.");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Se ha producido un error al copiar la base de datos. Mas detalles: " + 
                    (e.Error as Exception).ToString());
            }
            else
            {

                progressBar1.Value = 11;
                MessageBox.Show("Backup realizado satisfactoriamente"+ e.Result.ToString(),
                 "Copias Seguridad",MessageBoxButtons.OK, MessageBoxIcon.Information);
                
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
                    label3.Text = "Copiando Documentos.";
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
            // creamos un directorio dentro de copias de seguriad
            // que se llamará "backup + fecha +hora;
            string dia, hora, directorio;
            dia = DateTime.Now.ToString("ddMMyyy");
            hora = DateTime.Now.TimeOfDay.ToString("hhmmssff");
            directorio = "Backup" + dia + "-" + hora;
            //     textBox1.Text = directorio;

            backgroundWorker1.ReportProgress(10);
            Thread.Sleep(2000);
            // realizamos la copia de seguridad de la tabla y la almacenamos en la carpeta Tmp

            string sBackup = "BACKUP DATABASE " + "AdministracionAntonio" +
                " TO DISK = N'" + @"C:\ByMartin\tmp\Sql" + directorio +
                "' WITH NOFORMAT, NOINIT, NAME =N'" + "AdministracionAntonio" +
                "', SKIP,NOREWIND, NOUNLOAD,  STATS = 10";


            backgroundWorker1.ReportProgress(10);

            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();

            csb.DataSource = @"DESKTOP-C91G7H5\SQLEXPRESS";// this.txtServidor.Text;
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
            // ahora vamos a realizar la copia de seguridad de las carpetas y añadimos la copia de seguridad de las tablas
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(@"C:\ByMartin", "ByMartin");
                backgroundWorker1.ReportProgress(10);
                zip.AddDirectory(@"C:\ByMartin\tmp");
                backgroundWorker1.ReportProgress(10);
                zip.Comment = "Archivo comprimido el " + System.DateTime.Now.ToString("G");
                backgroundWorker1.ReportProgress(10);
                zip.Save(@"C:\ByMartin\Backup\"+ directorio + ".zip");
            }
            backgroundWorker1.ReportProgress(10);

            //ahora borramos la carpeta tmp
            string[] filePaths = Directory.GetFiles(@"C:\ByMartin\tmp");
            foreach (string filePath in filePaths)
                File.Delete(filePath);
            backgroundWorker1.ReportProgress(10);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //lanza el evento en segudo plano
            panel2.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
