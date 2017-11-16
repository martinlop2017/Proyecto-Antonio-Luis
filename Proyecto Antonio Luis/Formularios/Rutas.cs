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


namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class Rutas : Form
    {

        AdministracionAntonioEntities bd;

        public Rutas()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }

        private void Rutas_Load(object sender, EventArgs e)
        {
            // cargamos los datos de la tabla
            // creamos un objeto y cargamos los datos
            var mostrarRutas = bd.Cuentas.SingleOrDefault(codigo => codigo.cod == 0);

            if (mostrarRutas != null)
            {
                textdigitos.Text = mostrarRutas.NumDigitos;
                textclientes.Text = mostrarRutas.CtaCliente.ToString();
                textbanco.Text = mostrarRutas.CtaBanco.ToString();
                textsuplidos.Text = mostrarRutas.CtaSuplido.ToString();
                textretenciones.Text = mostrarRutas.CtaRetencion.ToString();
                textprestaciones.Text = mostrarRutas.CtaPrestaciones.ToString();
                textiva0.Text = mostrarRutas.Iva0.ToString();
                textivasuper.Text = mostrarRutas.IvaSuper.ToString();
                textivaredu.Text = mostrarRutas.IvaReducido.ToString();
                textivageneral.Text = mostrarRutas.IvaGeneral.ToString();
                textsubcuenta.Text = mostrarRutas.RutaSubcuenta;
                textdiario.Text = mostrarRutas.RutaDiario;
                textasi.Text = mostrarRutas.RutaAsi;
                textcsb19.Text = mostrarRutas.RutaCSB19;

            }

            else
            {
                Globales.llamadas = "1";
                MessageBox.Show("No existen datos a mostrar.");

            }
            //textdigitos.Text = mostrarRutas.
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();

            if (buscar.ShowDialog() == DialogResult.OK)
            {
                textclientes.Text = buscar.FileName;
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog buscar = new OpenFileDialog();

                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    textsubcuenta.Text = buscar.FileName;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog buscar = new OpenFileDialog();

                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    textdiario.Text = buscar.FileName;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog buscar = new OpenFileDialog();

                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    textasi.Text = buscar.FileName;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            {
                OpenFileDialog buscar = new OpenFileDialog();

                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    textcsb19.Text = buscar.FileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Globales.llamadas == "1") //graba los datos
            {
                try
                {
                    //****GRABA LOS DATOS EN LA TABLA
                    var grabarutas = new Cuentas();

                    grabarutas.cod = 0;
                    grabarutas.NumDigitos = textdigitos.Text;
                    grabarutas.CtaCliente = Convert.ToDecimal(textclientes.Text);
                    grabarutas.CtaBanco = Convert.ToDecimal(textbanco.Text);
                    grabarutas.CtaSuplido = Convert.ToDecimal(textsuplidos.Text);
                    grabarutas.CtaRetencion = Convert.ToDecimal(textretenciones.Text);
                    grabarutas.CtaPrestaciones = Convert.ToDecimal(textprestaciones.Text);
                    grabarutas.Iva0 = Convert.ToDecimal(textiva0.Text);
                    grabarutas.IvaSuper = Convert.ToDecimal(textivasuper.Text);
                    grabarutas.IvaReducido = Convert.ToDecimal(textivaredu.Text);
                    grabarutas.IvaGeneral = Convert.ToDecimal(textivageneral.Text);
                    grabarutas.RutaSubcuenta = textsubcuenta.Text;
                    grabarutas.RutaDiario = textdiario.Text;
                    grabarutas.RutaAsi = textasi.Text;
                    grabarutas.RutaCSB19 = textcsb19.Text;
   

                    bd.Cuentas.Add(grabarutas);

                    //guardamos los cambios
                    bd.SaveChanges();

                }
                catch (Exception)
                {
                    MessageBox.Show("No se ha guardado los datos","Error 101");
                }
            }

            if (Globales.llamadas!="1") // modifica los datos
            {
                try
                {
                    var grabarutas = bd.Cuentas.SingleOrDefault(codigo => codigo.cod == 0);

                    grabarutas.cod = 0;
                    grabarutas.NumDigitos = textdigitos.Text;
                    grabarutas.CtaCliente = Convert.ToDecimal(textclientes.Text);
                    grabarutas.CtaBanco = Convert.ToDecimal(textbanco.Text);
                    grabarutas.CtaSuplido = Convert.ToDecimal(textsuplidos.Text);
                    grabarutas.CtaRetencion = Convert.ToDecimal(textretenciones.Text);
                    grabarutas.CtaPrestaciones = Convert.ToDecimal(textprestaciones.Text);
                    grabarutas.Iva0 = Convert.ToDecimal(textiva0.Text);
                    grabarutas.IvaSuper = Convert.ToDecimal(textivasuper.Text);
                    grabarutas.IvaReducido = Convert.ToDecimal(textivaredu.Text);
                    grabarutas.IvaGeneral = Convert.ToDecimal(textivageneral.Text);
                    grabarutas.RutaSubcuenta = textsubcuenta.Text;
                    grabarutas.RutaDiario = textdiario.Text;
                    grabarutas.RutaAsi = textasi.Text;
                    grabarutas.RutaCSB19 = textcsb19.Text;

                    bd.SaveChanges();

                }
                catch (Exception)
                {
                    MessageBox.Show("No ha sido possible gabar los datos", "Error 202");

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {


            //*** borrar
            //busca en la tabla la fila con el registro suminstrado
            //y si lo encuentra borra la linea de la base de datos

            var borrar = bd.Cuentas.SingleOrDefault(codigo => codigo.cod == 0);
            if (borrar != null)
            {
                bd.Cuentas.Remove(borrar);
                bd.SaveChanges();
            }
        }
    }
}
