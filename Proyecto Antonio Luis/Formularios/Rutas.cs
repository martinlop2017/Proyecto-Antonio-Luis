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


namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class Rutas : Form
    {
        public Rutas()
        {
            InitializeComponent();
        }

        private void Rutas_Load(object sender, EventArgs e)
        {

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
                textBox1.Text = buscar.FileName;
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
                    textBox19.Text = buscar.FileName;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog buscar = new OpenFileDialog();

                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    textBox18.Text = buscar.FileName;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog buscar = new OpenFileDialog();

                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    textBox17.Text = buscar.FileName;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            {
                OpenFileDialog buscar = new OpenFileDialog();

                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    textBox16.Text = buscar.FileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
