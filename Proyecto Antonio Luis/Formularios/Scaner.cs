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
using BaseDatos;
using System.IO.Compression;
using Ionic.Zip;



namespace Proyecto_Antonio_Luis.Formularios
{


   
     
   




    public partial class Scaner : Form
    {

        AdministracionAntonioEntities bd;

        public Scaner()
        {
            InitializeComponent();
            
            bd = new AdministracionAntonioEntities();
        }

        private void Scaner_Load(object sender, EventArgs e)
        {
            Devices.Items.Clear();
            var deviceManager = new DeviceManager();
            for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            {
                if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                {
                    return;
                }
                Devices.Items.Add(new Scanner(deviceManager.DeviceInfos[i]));
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var device = Devices.SelectedItem as Scanner;
            if (device == null)
            {
                MessageBox.Show("Please select a device.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var image = device.Scan();
            var path = @"c:\scan.jpeg";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            try
            {/*
                image.SaveFile(path);
                BitmapImage BImage = new BitmapImage(new Uri(path, UriKind.Absolute));
                img.Source = BImage;
            */
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }


    public class Scanner
        {
            private readonly DeviceInfo _deviceInfo;

            public Scanner(DeviceInfo deviceInfo)
            {
                this._deviceInfo = deviceInfo;
            }

            public ImageFile Scan()
            {
                var device = this._deviceInfo.Connect();
                var item = device.Items[1];
                var imageFile = (ImageFile)item.Transfer("{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}");
                return imageFile;
            }

            public override string ToString()
            {
                return this._deviceInfo.Properties["Name"].get_Value().ToString();
            }
        }
 

 







    



     

      

   
    }





















