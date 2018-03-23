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
using Proyecto_Antonio_Luis.Clases;



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

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string llave = Encriptar.codificar(textBox1.Text);

            var compro = baseDeDatos.Ususarios.Where(X => X.nombre == comboBox1.Text && X.login == llave).ToList();
            if (compro.Count == 1)
            {

                // Abre el menu principal

                MenuPrincipal form = new MenuPrincipal();
                form.Show();
            }
            else
            {
                MessageBox.Show("Contraseña y/o Ususario Incoreccto.","Error Login.",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            var compro = baseDeDatos.Ususarios.Where(X => X.nombre == comboBox1.Text && X.grupo == "Administrador").ToList();
            if (compro.Count == 1)
            {
                label4.Visible = true;
            }
  
        }
    }
}
