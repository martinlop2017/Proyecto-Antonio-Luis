using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class FormEsperar : Form
    {
        private string texto;
        public FormEsperar(string text)
        {
            texto = text;
            InitializeComponent();
        }

        private void FormEsperar_Load(object sender, EventArgs e)
        {
            this.label1.Text = texto;
                     
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           

        }
    }
}
