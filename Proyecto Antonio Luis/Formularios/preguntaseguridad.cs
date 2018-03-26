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
using BaseDatos;
using Proyecto_Antonio_Luis.Clases;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class preguntaseguridad : Form
    {
        AdministracionAntonioEntities bd;
        string respuesta;
        int contador;

        public preguntaseguridad()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }

        private void preguntaseguridad_Load(object sender, EventArgs e)
        {
            var pregunta = bd.Ususarios.Where(X => X.nombre == Globales.llamadas).ToList();
            label2.Text = pregunta.First().pregunta.ToString();
            label2.Text = Encriptar.Descodificar(label2.Text);
            respuesta = pregunta.First().respuesta.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string llave = Encriptar.Descodificar(respuesta);


            if (textBox1.Text == llave)
            {

                Nuevacontraseña form = new Nuevacontraseña();
                form.Show();
            }
            else
            {
                MessageBox.Show("Respuesta incorrecta, intente nuevamente.", "Error Login.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                contador++;
            }
            if (contador == 3)
            {
                MessageBox.Show("Numero de intentos agotados.\n Contacte con el Administrador.", "Error Login.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
