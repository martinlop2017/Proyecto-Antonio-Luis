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
    public partial class BORRAR : Form
    {

        AdministracionAntonioEntities bd;
        public BORRAR()
        {
            bd = new AdministracionAntonioEntities();
            InitializeComponent();
        }

        private void BORRAR_Load(object sender, EventArgs e)
        {
            dgvIva.DataSource = bd.Iva.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //**** calculamos el valor de la coluna numerador
            var ultimonumerador = bd.Iva.OrderByDescending(x => x.numerador).First().numerador;

            //****GRABA LOS DATOS EN LA TABLA
              // creamos un obejto donde guardamos los datos a ingresar
            var nuevoiva = new Iva();
            nuevoiva.numerador = ultimonumerador + 1;
            nuevoiva.ivaconcepto = textBox1.Text;
            nuevoiva.ivaporciento = Convert.ToDecimal(textBox2.Text);
            nuevoiva.ivarecargo = Convert.ToDecimal(textBox3.Text);
            // añadiomos los datos
            bd.Iva.Add(nuevoiva);

            //guardamos los cambios
            bd.SaveChanges();

            // Refrescamos el dbgrid
            dgvIva.DataSource = bd.Iva.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // creamos una variable que va aguardar los datos de la fila seleccionada en el dbgrid

           int valor1 = Convert.ToInt16( dgvIva.CurrentRow.Cells[0].Value);
           textBox4.Text = valor1.ToString();



            //*** borrar
            //busca en la tabla la fila con el registro suminstrado
            //y si lo encuentra borra la linea de la base de datos

            var borrar = bd.Iva.SingleOrDefault(iva => iva.numerador == valor1);
            if (borrar != null)
            {
                bd.Iva.Remove(borrar);
            }


            //guardamos los cambios
            bd.SaveChanges();

            // Refrescamos el dbgrid
            dgvIva.DataSource = bd.Iva.ToList();


        }

        private void dgvIva_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
