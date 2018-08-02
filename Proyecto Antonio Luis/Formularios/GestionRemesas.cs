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
using Proyecto_Antonio_Luis.Clases;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class GestionRemesas : Form
    {
        AdministracionAntonioEntities bd;
        string mesrremesa; // lo usamos para extraer el numero deremesa de la linea seleccionada en el dgv



        public GestionRemesas()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();

        }

        private void GestionRemesas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'administracionAntonioDataSet1.Resilla' Puede moverla o quitarla según sea necesario.
            this.resillaTableAdapter.Fill(this.administracionAntonioDataSet1.Resilla);
            // TODO: esta línea de código carga datos en la tabla 'administracionAntonioDataSet.Remesas' Puede moverla o quitarla según sea necesario.
    //        this.remesasTableAdapter.Fill(this.administracionAntonioDataSet.Remesas);

        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            //cuando pulsamos en el dvg extraemos el numero de la remesa
            int fila = Convert.ToInt32(dgvremesas.CurrentRow.Index);
            mesrremesa = Convert.ToString(dgvremesas[1, fila].Value);

            //filtramos la base de datos de facturacion por el numero de remesa. y que contabilizado= false
            var facturasacontabilizar = bd.Facturas.Where(x => x.factremesa == mesrremesa).ToList();



            // pasamos los datos a la clase para imprimir el listado

            List<datoslistadoreme> alistar = new List<datoslistadoreme>();


            foreach (var temp in facturasacontabilizar)
            {
                datoslistadoreme mylistado = new datoslistadoreme();
                
                mylistado.listnumerofactura = temp.factnumerofact.ToString();
                mylistado.listfecha = temp.factfecha;
                mylistado.listnombre = temp.factnombre;
                mylistado.listbase = Convert.ToDecimal(temp.factbase1 + temp.factbase2 + temp.factbaseempleado);
                mylistado.listsuplidos = Convert.ToDecimal(temp.factbase2);
                mylistado.listiva = Convert.ToDecimal(temp.factimporteiva);
                mylistado.listtotal = Convert.ToDecimal(temp.facttotalfactura);
                mylistado.listnumeroremesa = temp.factremesa;
                mylistado.listtotalremesa = Convert.ToDecimal(temp.facttotalremesa);
                
                alistar.Add(mylistado);
            }

            // cargamos la pantalla de listados de remesas
            Form2 forma = new Form2(alistar);
            forma.Show();


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void sumar_Click(object sender, EventArgs e)
        {
            CBS19 form = new CBS19();
            form.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Remesa")
            {
                dgvremesas.DataSource = bd.Resilla.OrderBy(x => x.remesanumero).ToList();
            }

            if (comboBox1.Text == "Fecha")
            {
                dgvremesas.DataSource = bd.Resilla.OrderBy(x => x.remesafecha).ToList();
            }

            if (comboBox1.Text == "Importe")
            {
                dgvremesas.DataSource = bd.Resilla.OrderBy(x => x.remesatotal).ToList();
            }
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var busqueda = from c in bd.Resilla select c;
            busqueda = busqueda.Where(c => c.remesanumero.Contains(textBox1.Text)).OrderBy(x => x.remesanumero);

            dgvremesas.DataSource = busqueda.ToList();
        }
    }
}
