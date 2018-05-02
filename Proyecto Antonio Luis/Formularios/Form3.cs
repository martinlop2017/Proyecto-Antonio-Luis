﻿using System;
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
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
        public void ExportarToPdf(datoslistadoreme datosListado, string pdfName)
        {
            //this.reportViewer1.RefreshReport();
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            Warning[] warnings;
            string[] streamIds;

            //var form = new FormEsperar("Imprimiendo");
            //CheckForIllegalCrossThreadCalls = false;
            //var test = Task.Factory.StartNew(() =>
            //{
                    this.administracionAntonioDataSet1BindingSource.DataSource = datosListado;

                    byte[] bytes = reportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding,
                    out extension, out streamIds, out warnings);

                    var exportPath = string.Format(pdfName);

            FileInfo file = new FileInfo(exportPath);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            //File.WriteAllText(file.FullName, bytes);
            //var exportPath = string.Format($"C:\\Equipo Martin\\facturas\\Nueva carpeta\\Test{i+1}.pdf");
            File.WriteAllBytes(file.FullName, bytes);
                //}
            //    form.Close();
            //});

            //form.ShowDialog();

            //test.Dispose();
            //CheckForIllegalCrossThreadCalls = true;

        }
    }
}
