using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using BaseDatos;
using System.IO;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;





namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class GestionDocumentos : Form
    {
        AdministracionAntonioEntities bd;

        public GestionDocumentos()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                                
        }

    private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GestionDocumentos_Load(object sender, EventArgs e)
        {
            dgvclientes.DataSource = bd.Clientes.ToList();
        }

        private void dgvclientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

           


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            dgvclientes.Visible = true;
            var busqueda = from c in bd.Clientes select c;
            busqueda = busqueda.Where(c => c.nombrecliente.Contains(textBox5.Text)).OrderBy(x => x.nombrecliente);

            dgvclientes.DataSource = busqueda.ToList();
        }

        private void sumar_Click(object sender, EventArgs e)
        {



            {
                //comprovamos que tipo de archivo es:
                //para ello hacemos lo siguiente

                //creamos un strng donde almacenamos la direccion
                string cadena = openFileDialog1.FileName;

                //Extraemos el tamaño total de la cadena en la variable.
                int totalcaracteres = openFileDialog1.FileName.Length;
                //Extraemos los caracteres que existen desde el final a el primer punto
                int posicion = openFileDialog1.FileName.LastIndexOf('.') + 1;
                //Calculamos la posion donde empieza le "extension" del archivo
                int tamano = (totalcaracteres - posicion);

                //Cargamos la extension en la variable
                string extension = cadena.Substring(posicion, tamano);

                //indicamos como abrir el archivo dependiendo de la extension.

                int opc = 0;
                // si es pdf   
                if (extension == "pdf")
                {
                    opc = 1;
                }
                // si es word
                if ((extension == "docx") || (extension == "docm") || (extension == "dotx") || (extension == "dotm") ||
                    (extension == "doc") || (extension == "dot"))
                {
                    opc = 2;
                }
                // si es excel
                if ((extension == "xlsx") || (extension == "xlsm") || (extension == "xltx") || (extension == "xltm") ||
                    (extension == "xls") || (extension == "xlt"))
                {
                    opc = 3;
                }

                switch (opc)
                {
                    case 1:
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo.FileName = openFileDialog1.FileName; //  @&#34;&#092;ayuda&#092;mov_basicos.pdf&#34;
                        p.Start();
                        break;
                    case 2:
                        Process.Start(openFileDialog1.FileName);
                        break;
                    case 3:
                        Process.Start(openFileDialog1.FileName);
                        break;
                    default:
                        MessageBox.Show("No es posible abrir el archivo");
                        break;
                }

            }

        }

        private void eliminar_Click(object sender, EventArgs e)
        {

        }

        private void modificar_Click(object sender, EventArgs e)
        {

        }

        private void dgvclientes_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = Convert.ToString(dgvclientes.CurrentRow.Cells[2].Value);
            dgvclientes.Visible = false;
        


        }

        private void textBox5_Leave(object sender, EventArgs e)
        {

            
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Text = Convert.ToString(dgvclientes.CurrentRow.Cells[2].Value);
                dgvclientes.Visible = false;
               
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\ByMartin\\Clientes\\" + textBox5.Text;


            if (openFileDialog1.ShowDialog() == DialogResult.OK) ;
        }

        private void BotonEscaner_Click(object sender, EventArgs e)
        {
            string ruta = "C:\\ByMartin\\Clientes\\" + textBox5.Text;

       /*     string filename = "Excel.exe";

            Process proc = new Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = filename;
            proc.StartInfo.Arguments = "";
            proc.Start();

    */


            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook book = null;

            book = excel.Workbooks.Add();
            book.SaveAs(ruta);
            book.Close();
            excel.Quit();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            object ObjMiss = System.Reflection.Missing.Value;
            Word.Application ObjWord = new Word.Application();
            Word.Document ObjDoc = ObjWord.Documents.Add(ref ObjMiss, ref ObjMiss, ref ObjMiss, ref ObjMiss);
            ObjDoc.Activate();
            ObjWord.Selection.Font.Color = Word.WdColor.wdColorRed;
            // ObjWord.Selection.TypeText(textBox5.Text);
            ObjWord.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            label1.Visible = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void salir_MouseEnter(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void salir_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Salir_Azul;
            label3.Visible = true;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Salir;
            label3.Visible = false;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources._1Escaner_Azul;
            label4.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources._1Escaner;
            label4.Visible = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Word_Azul;
            label5.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Word;
            label5.Visible = false;
        }

        private void BotonEscaner_MouseEnter(object sender, EventArgs e)
        {
            BotonEscaner.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Excel_Azul;
            label6.Visible = true;
        }

        private void BotonEscaner_MouseLeave(object sender, EventArgs e)
        {
            BotonEscaner.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Excel;
            label6.Visible = false;
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
           
        }
    }
}
