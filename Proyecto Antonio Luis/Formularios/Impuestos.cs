using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseDatos;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class Impuestos : Form
    {

        AdministracionAntonioEntities baseDeDatos;


        public Impuestos()
        {
            InitializeComponent();
            baseDeDatos = new AdministracionAntonioEntities();
        }

        private void dataGridViewIVAs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Impuestos_Load(object sender, EventArgs e)
        {
            // baseDeDatos.Ususarios.Select(user => user.nombre).ToList<string>();
            //   dataGridViewIVAs.Column[1].Name = "hola";
            //BaseDatos.Iva.Select(User => user.icaconcepto).ToList<string>();
            //          dataGridViewIVAs.DataSource = baseDeDatos.Ususarios.Select(user => user.nombre).ToList<string>();

            dataGridViewIVAs.DataSource = baseDeDatos.Iva.Select(user => user.ivaconcepto).ToList<string>();
           // dataGridViewIVAs.Columns[0] = baseDeDatos.Iva.Select(user => user.ivaconcepto).ToList<string>();

        }
    }
}
