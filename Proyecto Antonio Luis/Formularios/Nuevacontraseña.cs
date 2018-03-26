using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Antonio_Luis.Clases;
using BaseDatos;

namespace Proyecto_Antonio_Luis.Formularios
{
    

    public partial class Nuevacontraseña : Form
    {
            AdministracionAntonioEntities bd;

        public Nuevacontraseña()
        {
            bd = new AdministracionAntonioEntities();
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Nuevacontraseña_Load(object sender, EventArgs e)
        {
           
            var pregunta = bd.Ususarios.Where(X => X.nombre == Globales.llamadas).ToList();

            

        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("No puede dejar campos sin rellenar.\n Revise los datos introducidos.", "Documento Incompleto.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var pregunta = bd.Ususarios.Where(X => X.nombre == Globales.llamadas).ToList();

                pregunta.First().login = Encriptar.codificar(textBox1.Text);
                pregunta.First().pregunta = Encriptar.codificar(textBox3.Text);
                pregunta.First().respuesta = Encriptar.codificar(textBox4.Text);

                bd.SaveChanges();

                Close();
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Los valores no coinciden.");
               textBox2.Text = "";
               textBox1.Text = "";
               textBox1.Focus();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
