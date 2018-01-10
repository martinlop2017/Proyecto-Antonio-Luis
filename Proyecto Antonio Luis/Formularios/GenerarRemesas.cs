using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BaseDatos;
using Proyecto_Antonio_Luis.Clases;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class GenerarRemesas : Form
    {
        AdministracionAntonioEntities bd;

        public GenerarRemesas()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                losmios = bd.Propios.

                Remesas miremesa = new Remesas();




                //crea el archivo
                StreamWriter miarchivo = File.CreateText("C:\\Equipo Martin\\Programacion\\archivo prueba\\ejemplocbs.txt");
                //introducimos texto
                miarchivo.WriteLine("5180" + misdatos.micif + "001" + miremesa.remesafecha);
                   
                miarchivo.WriteLine("esto es nuevo");
                //cerramos el archivo
                miarchivo.Close();

            }
            catch (Exception exp)
            {

            }


        }
    }

}
