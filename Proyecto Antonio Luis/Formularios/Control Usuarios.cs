using BaseDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Antonio_Luis.Formularios;



namespace Proyecto_Antonio_Luis
{







    public partial class Form1 : Form
    {
        AdministracionAntonioEntities baseDeDatos;


        public Form1()
        {
            
            InitializeComponent();
            baseDeDatos = new AdministracionAntonioEntities();
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Llave_azul;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Llave;
        }

        private void dataSet1_Initialized(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            comboBox1.DataSource = baseDeDatos.Ususarios.Select(user => user.nombre).ToList<string>();

         // ***********************************************
         //***********************************************
         //******* Ejempolo de Linkq  ********************
         //****   
         //****   //introducir nueva linea
         //****
         //****   // creamos una nueva clase "ususarios"
         //****
         //****   Ususarios newUser = new Ususarios()
         //****   {
         //****       // cargarmos los datos
         //****       
         //****       cod = "6",
         //****       nombre = "Test6"
         //****   };
         //****  
         //****   //creamos una linea nueva y añade los datos
         //****   baseDeDatos.Ususarios.Add(newUser);
         //****   // guadrdamos la tabla
         //****   baseDeDatos.SaveChanges();
         //**** 
         //****   int pepes = baseDeDatos.Ususarios.Count(user => user.nombre == "pepe");
         //****   comboBox1.Text = pepes.ToString();
         //**********************************************************
         //**********************************************************
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Abre el menu principal

            MenuPrincipal form = new MenuPrincipal();
            form.Show();



        }
    }
}
