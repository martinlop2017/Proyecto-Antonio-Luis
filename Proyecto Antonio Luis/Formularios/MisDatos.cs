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

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class MisDatos : Form
    {
        AdministracionAntonioEntities bd;

        public MisDatos()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Propios_Load(object sender, EventArgs e)
        {
            //****Al cargar mostramos los datos.
            //extraemos los datos correspondientes de la tabla en el objeto
            var muestramisdatos = bd.Propios.SingleOrDefault(mio => mio.numerador == 1);

            

            textBoxMiNombre.Text = muestramisdatos.minombre;
            textBoxMiCif.Text = muestramisdatos.micif;
            textBoxMiDiereccion.Text = muestramisdatos.midireccion;
            textBoxMiPoblacion.Text = muestramisdatos.mipoblacion;
            textBoxMiProvincia.Text = muestramisdatos.miprovincia;
            textBoxMiCP.Text = muestramisdatos.micp;
            textBoxMiTLF1.Text = muestramisdatos.mitelefono1;
            textBoxMiTLF2.Text = muestramisdatos.mitelefono2;
            textBoxMiFax.Text = muestramisdatos.mifax;
            textBoxMiPersonaContacto.Text = muestramisdatos.micontacto;
            textBoxMiMail.Text = muestramisdatos.mimail;
            textBoxivan1.Text = muestramisdatos.miiban1;
            textBoxivan2.Text = muestramisdatos.miiban2;
            textBoxivan3.Text = muestramisdatos.miiban3;
            textBoxivan4.Text = muestramisdatos.miiban4;
            textBoxivan5.Text = muestramisdatos.miiban5;
            textBoxivan6.Text = muestramisdatos.miiban6;
            textBox23.Text = muestramisdatos.milogo;


        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            //extraemos los datos correspondientes de la tabla en el objeto
            var propioModificar = bd.Propios.SingleOrDefault(mio => mio.numerador == 1);


            //modificamos los valores
            propioModificar.minombre = textBoxMiNombre.Text;
            propioModificar.micif = textBoxMiCif.Text;
            propioModificar.midireccion = textBoxMiDiereccion.Text;
            propioModificar.mipoblacion = textBoxMiPoblacion.Text;
            propioModificar.miprovincia = textBoxMiProvincia.Text;
            propioModificar.micp = textBoxMiCP.Text;
            propioModificar.mitelefono1 = textBoxMiTLF1.Text;
            propioModificar.mitelefono2 = textBoxMiTLF2.Text;
            propioModificar.mifax = textBoxMiFax.Text;
            propioModificar.micontacto = textBoxMiPersonaContacto.Text;
            propioModificar.mimail = textBoxMiMail.Text;
            propioModificar.miiban1 = textBoxivan1.Text;
            propioModificar.miiban2 = textBoxivan2.Text;
            propioModificar.miiban3 = textBoxivan3.Text;
            propioModificar.miiban4 = textBoxivan4.Text;
            propioModificar.miiban5 = textBoxivan5.Text;
            propioModificar.miiban6 = textBoxivan6.Text;
            propioModificar.milogo = textBox23.Text;


            //guardamos los cambios
            bd.SaveChanges();

            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();

            if (buscar.ShowDialog() == DialogResult.OK)
            {
                textBox23.Text = buscar.FileName;
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            panel1.BackgroundImage = Image.FromFile(textBox23.Text);
           
        }
    }
}
