using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class pruebasprogress : Form
    {
        TaskScheduler uiScheduler;
        int pasos = 1;

        public pruebasprogress()
        {
            InitializeComponent();
            this.uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        }

        private void pruebasprogress_Load(object sender, EventArgs e)
        {
            Image img = Image.FromFile("C:\\Equipo Martin\\Programacion\\Repositorio Remoto\\Proyecto Antonio Luis\\Proyecto Antonio Luis\\Imagenes\\pROGRESS\\gif flor 1.gif");

            pictureBox1.Image = img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
   //         Task.Factory.StartNew(DoWork).ContinueWith(t => this.progressBar1.Value = 100, this.uiScheduler);
            Task.Factory.StartNew(DoWork).ContinueWith(t => this.timer1.Enabled = true,this.uiScheduler);
        }

        private void DoWork()
        {
           
                // notificación de progreso
                // tiene que ser en el hilo del interfaz de usuario
                Task.Factory.StartNew(() => (this.timer1.Enabled=true),
                    CancellationToken.None, TaskCreationOptions.None, this.uiScheduler);
                
         


        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            switch (pasos)
            {
                case 1:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_2;
                    pasos++;
                    break;
                case 2:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_3;
                    pasos++;
                    break;
                case 3:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_4;
                    pasos++;
                    break;
                case 4:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_5;
                    pasos++;
                    break;
                case 5:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_6;
                    pasos++;
                    break;
                case 6:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_7;
                    pasos++;
                    break;
                case 7:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_8;
                    pasos++;
                    break;
                case 8:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_9;
                    pasos++;
                    break;
                case 9:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_10;
                    pasos++;
                    break;
                case 10:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_11;
                    pasos++;
                    break;
                case 11:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_12;
                    pasos++;
                    break;
                case 12:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_13;
                    pasos++;
                    break;
                case 13:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_14;
                    pasos++;
                    break;
                case 14:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_15;
                    pasos++;
                    break;
                case 15:
                    panel1.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Flor_16;
                    pasos = 1;
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
