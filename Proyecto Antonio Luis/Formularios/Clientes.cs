
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
using System.Data.SqlClient;
//using Administracion_Antonio_Luis.Utils.Iva;





namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class Clientes : Form
    {

        AdministracionAntonioEntities baseDeDatos;
        
        public Clientes()
        {
            InitializeComponent();
            baseDeDatos = new AdministracionAntonioEntities();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ivaDevuelto1 = baseDeDatos.Iva.SingleOrDefault(iva => iva.ivaconcepto.Equals("Superreducido"));


            textBoxMiNombre.Text = ivaDevuelto1.ivaconcepto;


            /*

            var nuevoArticulo = this.ReadNewArticuloFromForm();
            var Ok = false;

           
                Ok = this.IIva.SaveArticulo(nuevoArticulo);
            */
        }
    }
}
