using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class ImprimirFacturas : Form
    {
        private PrintDialog Impresora = new PrintDialog();

        public ImprimirFacturas()
        {
            InitializeComponent();
        }


        private void button8_Click(object sender, EventArgs e)
        {


            DialogResult Result = Impresora.ShowDialog();
        }
    }
}

