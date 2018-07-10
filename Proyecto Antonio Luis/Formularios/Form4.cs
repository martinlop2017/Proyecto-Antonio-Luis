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
using Microsoft.Reporting.WinForms;
using System.IO;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class Form4 : Form
    {
        List<ImpresionDirecta> listadodefinitivo;
        string ruta;

        public Form4(List<ImpresionDirecta> lista, string ruta)
        {
            listadodefinitivo = lista;
            this.ruta = ruta;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            Warning[] warnings;
            string[] streamIds;

            foreach(var factura in listadodefinitivo)
            {
                this.reportViewer1.RefreshReport();
                ImpresionDirectaBindingSource.DataSource = factura;

                byte[] bytes = reportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding,
                    out extension, out streamIds, out warnings);

                var exportPath = string.Format($"{ruta}\\Factura {factura.imprifactura}.pdf");

                File.WriteAllBytes(exportPath, bytes);

                
            }

            this.Close();
            //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
