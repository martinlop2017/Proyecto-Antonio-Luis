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

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class Form2 : Form
    {
        List<datoslistadoreme> listadodefinitivo;
        public Form2(List<datoslistadoreme> alistar)
        {
            listadodefinitivo = alistar;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            datoslistadoremeBindingSource.DataSource = listadodefinitivo;
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void datoslistadoremeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
         //   datoslistadoremeBindingSource.DataSource = lista
        }
    }
}
