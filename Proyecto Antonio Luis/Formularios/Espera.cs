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
        
    public partial class Espera : Form
    {
        int pasos = 1;

        public Espera()
        {
           

            InitializeComponent();
           
        }



        private void Espera_Load(object sender, EventArgs e)
        {
          


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
    }
}
