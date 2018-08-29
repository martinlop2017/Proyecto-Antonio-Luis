using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;

namespace Proyecto_Antonio_Luis.Formularios
{
    




    public partial class Scaner : Form
    {
        public Scaner()
        {
            InitializeComponent();
        }

        private void Scaner_Load(object sender, EventArgs e)
        {
           

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new WIA.CommonDialogClass();
                var scannedImage = dialog.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType) as WIA.ImageFile;
                if (scannedImage != null)
                {
                    if (System.IO.File.Exists("scanwia.png"))
                        System.IO.File.Delete("scanwia.png");
                    scannedImage.SaveFile("scanwia.png");
                }
            }
            catch
            {
                MessageBox.Show("Erro na digitalização do documento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }

   


}


