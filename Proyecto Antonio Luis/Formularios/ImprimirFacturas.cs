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
using BaseDatos;
using Proyecto_Antonio_Luis.Clases;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class ImprimirFacturas : Form
    {
        private PrintDialog Impresora = new PrintDialog();
        AdministracionAntonioEntities bd;

        public ImprimirFacturas()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }


        private void button8_Click(object sender, EventArgs e)
        {


            DialogResult Result = Impresora.ShowDialog();
        }

        private void ImprimirFacturas_Load(object sender, EventArgs e)
        {
            textBoxDocumentoFinal.Text = Globales.modificar.ToString();
            textBoxDocumentoInicial.Text = Globales.modificar.ToString();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            int inicio = Convert.ToInt16(textBoxDocumentoInicial);
            int final = Convert.ToInt16(textBoxDocumentoFinal);

            if (Convert.ToInt16(textBoxDocumentoFinal.Text) < Convert.ToInt16(textBoxDocumentoInicial.Text))
            {
                MessageBox.Show("Las facturas introducidas son incorrectas.");
            }
            else
            {
                var facturasacontabilizar = bd.Facturas.Where(x => Convert.ToInt32(x.factremesa) >= Convert.ToInt32(textBoxDocumentoInicial.Text) && Convert.ToInt32(x.factnumerofact <= Convert.ToInt32(textBoxDocumentoFinal.Text))).ToList();


               
                var facturaimpresa = bd.Facturas.Where(x => x.factnumerofact >= Convert.ToInt16(textBoxDocumentoInicial) && x.factnumerofact >= Convert.ToInt16(textBoxDocumentoFinasInicial)
                x.factparadomiciliar == true
                            && x.factdomiciliada == false).ToList();
                //Enumerable.r  Range(documentoInicial, documentoFinal - documentoInicial + 1).Select(x => x);
            }



           
        }
    }
}

