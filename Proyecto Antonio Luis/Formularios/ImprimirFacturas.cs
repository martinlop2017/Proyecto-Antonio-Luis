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
            decimal inicio = Convert.ToDecimal(textBoxDocumentoInicial.Text);
            decimal final = Convert.ToDecimal(textBoxDocumentoFinal.Text);

            if (Convert.ToInt16(textBoxDocumentoFinal.Text) < Convert.ToInt16(textBoxDocumentoInicial.Text))
            {
                MessageBox.Show("Las facturas introducidas son incorrectas.");
            }
            else
            {
                FolderBrowserDialog buscar = new FolderBrowserDialog();
                string ruta;
                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    ruta = buscar.SelectedPath;

                    var facturasacontabilizar = bd.Facturas.Where(x => x.factnumerofact >= inicio && x.factnumerofact <= final).OrderBy(x => x.factnumerofact).ToList(); ;

                    dgvfactura.DataSource = facturasacontabilizar;//  facturasacontabilizar.OrderBy(x => x.factnumerofact).ToList();




                    //****************************
                    //*************************
                    //*****************************
                    //*****************************

                    List<ImpresionDirecta> lista = new List<ImpresionDirecta>();


                    foreach (var temp in facturasacontabilizar)
                    {
                        ImpresionDirecta datosapasar = new ImpresionDirecta();

                        datosapasar.imprifactura = Convert.ToDecimal(temp.factnumerofact);
                        datosapasar.imprifecha = temp.factfecha;
                        datosapasar.imprinombre = temp.factnombre;
                        datosapasar.impridireccion = temp.factdireccion;
                        datosapasar.impricp = temp.factcp;
                        datosapasar.impriciudad = temp.factlocalidad;
                        datosapasar.impriprovincia = temp.factprovincia;
                        datosapasar.imprinif = temp.factnif;
                        datosapasar.impriconcepto1 = temp.factconcepto1;
                        datosapasar.impribase1 = Convert.ToDecimal(temp.factbase1);
                        datosapasar.impriconcepto2 = temp.factconcepto2;
                        datosapasar.impribase2 = Convert.ToDecimal(temp.factbase2);
                        //atosapasar.impriconcepto3 = temp.
                        datosapasar.impribasenosujeta = Convert.ToDecimal(temp.factbase2);
                        datosapasar.impribasesujeta = Convert.ToDecimal(temp.factbase1);
                        datosapasar.impritotalfactura = Convert.ToDecimal(temp.facttotalfactura);
                        datosapasar.impritipoiva = Convert.ToDecimal(temp.facttipoiva);


                        lista.Add(datosapasar);

                    }

                    //marcamos lo s registros como IMPRESOS
                    foreach (var temp in facturasacontabilizar)
                    {
                        temp.factcontabilizada = true;
                    }
                    bd.SaveChanges();


                    // cargamos la pantalla de listados de remesas
                    Form4 forma = new Form4(lista, ruta);
                    forma.Show();

                }

            }




        }

        private void textBoxDocumentoFinal_Leave(object sender, EventArgs e)
        {
            // cuando introducimos el valor final comprueba si esta fuera de rrango, y si no es asi no permite sguir.
            // extraemos el numero maximo de factura
            var ultimafactura = bd.Facturas.OrderByDescending(x => x.factnumerofact).First().factnumerofact;
            //pasamos a decimal el valor del edit.
            decimal tope = Convert.ToDecimal(textBoxDocumentoFinal.Text);
      

            if (tope > ultimafactura)
            {
                MessageBox.Show("El documento final no puede ser mayor de: " + ultimafactura);
                textBoxDocumentoFinal.Text = "0";
                textBoxDocumentoFinal.Focus();
            }

        }
    }
}

