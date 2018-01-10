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
    public partial class Facturacion : Form
    {
         AdministracionAntonioEntities bd;
        //esta lista la declaro arriba para poder usarla posteriormente
        List<albaranesclientes> albaranes = new List<albaranesclientes>();

        public Facturacion()
        {
            InitializeComponent();
           
            bd = new AdministracionAntonioEntities();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        //************************************************************************************************************
        //************************************************************************************************************
        //************************************************************************************************************
        //*****************                                                                               ************
        //*****************  Esto controla el que cambie de color los botones cuando los señala el raton  ************
        //*****************                                                                               ************
        //*****************                                                                               ************
        //************************************************************************************************************
        //************************************************************************************************************

        private void toolStripButton1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            // cargamos el combo del iva y la fecha.
            comboiva.DataSource = bd.Iva.Select(user => user.ivaporciento).ToList();
            comboiva.Text = "10";

            fechafactura.Value = DateTime.Now;

            //mostramos el mes que tenemos que factuar
            // para ello  filtramos la tabla por la fecha, y añadimos uno
            //   var mes = bd.Temporal.OrderByDescending(x => x.tempfecharemesa).FirstOrDefault();


            // borrar
            dgvTemporal.DataSource = "";
            dgvTemporal.DataSource = bd.Clientes .ToList();
            dgvTemporal.Refresh();

        }


        private void sumar_Click(object sender, EventArgs e)
        {
            // cuando generamos, recorremos los datos de la tabla clientes, y extraemos los datos de los que
            //tienen como true el campo activo.

       var facturcliente = bd.Clientes.Where(x => x.activocliente == true).ToList();

            Globales.fechafactura = fechafactura.Value;
            Globales.mesfactura = combomes.Text;
            Globales.tipoiva = Convert.ToDecimal(comboiva.Text);



            //aqui realiza el mapeo 
            //esta lista la declaro arriba para poder usarla posteriormente
          //  List<albaranesclientes> albaranes = new List<albaranesclientes>();
            albaranes = Mapeos.creaalbaran.pasoclientes_a_albaran(facturcliente);

            dgvTemporal.DataSource = albaranes.ToList();
//**************************









            





/*
           
            List<temporal> listaTemporales = new List<temporal>();

            listaTemporales = Mapeos.Mapeo.MapeoClienteDB_A_Temporal(facturcliente);
                
             dataGridView1.DataSource = listaTemporales.ToList();
             */
        }


  

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
        }

   
        private void generar_MouseEnter(object sender, EventArgs e)
        {
            label9.Visible = true;
        }

        private void generar_MouseLeave(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void añadir_MouseEnter(object sender, EventArgs e)
        {
            label8.Visible = true;
        }

        private void añadir_MouseLeave(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void eliminar_MouseEnter(object sender, EventArgs e)
        {
            label6.Visible = true;
        }

        private void eliminar_MouseLeave(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void facturar_MouseEnter(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void facturar_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void imprimir_MouseEnter(object sender, EventArgs e)
        {
            label4.Visible = true;
        }

        private void imprimir_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void salir_MouseEnter(object sender, EventArgs e)
        {
            label10.Visible = true;

        }

        private void salir_MouseLeave(object sender, EventArgs e)
        {
            label10.Visible = false;
        }

  

        private void dgvTemporal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //  creamos variables para los calculos y les damos valor
            decimal basealbaran, ivaalbaran, tarifa1albaran, tarifa2albaran, laboralalbaran,
                    tipoivaalbaran, totalalbaran, empleadosalbaran, precioempleadoalbaran;
            // creamos la variable para acceder a la fila
            int fila;
            
            
            
            // realizamos esto si modificamos la tarifa 1 o tarifa 2
            if ((dgvTemporal.Columns[e.ColumnIndex].Name == "albtarifaDataGridViewTextBoxColumn")||
                    (dgvTemporal.Columns[e.ColumnIndex].Name == "albtarifa2DataGridViewTextBoxColumn"))
            {
                fila = Convert.ToInt32(dgvTemporal.CurrentRow.Index);


                // cargamos las variables con los datos del dgv
                tarifa1albaran = Convert.ToDecimal(dgvTemporal[4, fila].Value);
                tarifa2albaran = Convert.ToDecimal(dgvTemporal[6, fila].Value);
                laboralalbaran = Convert.ToDecimal(dgvTemporal[9, fila].Value);
                tipoivaalbaran = Convert.ToDecimal(dgvTemporal[13, fila].Value);

                // realizamos lo scalculos
                basealbaran = (tarifa1albaran + tarifa2albaran + laboralalbaran);
                ivaalbaran = (basealbaran * tipoivaalbaran)/100;

                totalalbaran = basealbaran + ivaalbaran;

                // cargamos los datos e el dgv
                dgvTemporal[10, fila].Value = basealbaran;
                dgvTemporal[11, fila].Value = ivaalbaran;
                dgvTemporal[12, fila].Value = totalalbaran;
            }



            // realizamos esto si modificamos los empleados o el precio por emleado
            if ((dgvTemporal.Columns[e.ColumnIndex].Name == "albempleadosDataGridViewTextBoxColumn") ||
                    (dgvTemporal.Columns[e.ColumnIndex].Name == "albpvpempleadosDataGridViewTextBoxColumn"))
            {
                fila = Convert.ToInt32(dgvTemporal.CurrentRow.Index);

                // cargamos las variables con los datos del dgv
                tarifa1albaran = Convert.ToDecimal(dgvTemporal[4, fila].Value);
                tarifa2albaran = Convert.ToDecimal(dgvTemporal[6, fila].Value);
                tipoivaalbaran = Convert.ToDecimal(dgvTemporal[13, fila].Value);
                empleadosalbaran = Convert.ToInt32(dgvTemporal[7, fila].Value);
                precioempleadoalbaran = Convert.ToDecimal(dgvTemporal[8, fila].Value);

                // realizamos lo scalculos
                laboralalbaran = empleadosalbaran * precioempleadoalbaran;
                basealbaran = (tarifa1albaran + tarifa2albaran + laboralalbaran);
                ivaalbaran = (basealbaran * tipoivaalbaran) / 100;
                totalalbaran = basealbaran + ivaalbaran;

                // cargamos los datos e el dgv
                dgvTemporal[10, fila].Value = basealbaran;
                dgvTemporal[11, fila].Value = ivaalbaran;
                dgvTemporal[12, fila].Value = totalalbaran;
                dgvTemporal[9, fila].Value = laboralalbaran;

            }



            }

        private void añadir_Click(object sender, EventArgs e)
        {



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //var buscaclientes = bd.Clientes.OrderByDescending(x => x.nombrecliente).f


      //      int index = comboiva.FindString(textBox1.Text);
     //       comboiva.SelectedIndex = index;

            var buscaclientes = bd.Clientes.OrderByDescending(y => y.nombrecliente == textBox1.Text );

       



            dataGridView2.DataSource = buscaclientes.ToList();




        }

        private void button1_Click(object sender, EventArgs e)
        {


          //  bd.Clientes.Add(nuevocliente);

            //guardamos los cambios
        //    bd.SaveChanges();











            /*

            int fila = dgvTemporal.Rows.Count + 1;

            textBox2.Text = fila.ToString();

            dgvTemporal.Rows.Insert(fila);
            
         /*   dgvTemporal.


            clienteseleccionado = DatosdataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            */
        }

        private void facturar_Click(object sender, EventArgs e)
        {





            //cargamos los datos en el dgv.

            //**** calculamos el valor de la coluna numerador
            decimal numerofactura = 1;

            if (bd.Facturas.Any())
            {
                numerofactura = (bd.Facturas.OrderByDescending(x => x.factnumerofact).First().factnumerofact.Value)+1;
                
            }


            List<temporal> lista = new List<temporal>();


            foreach (DataGridViewRow row in dgvTemporal.Rows)

            {
                temporal datosapasar = new temporal();

                

                datosapasar.tempnumerofactura = Convert.ToDecimal(numerofactura);
                numerofactura++;
                datosapasar.tempremesa = Convert.ToString(row.Cells[0].Value);
                datosapasar.tempfecha = Convert.ToString(row.Cells[1].Value);
                datosapasar.tempnombre = Convert.ToString(row.Cells[2].Value);
                datosapasar.tempconcepto1 = Convert.ToString(row.Cells[3].Value);
                datosapasar.temptarifa = Convert.ToDecimal(row.Cells[4].Value);
                datosapasar.tempconcepto2 = Convert.ToString(row.Cells[5].Value);
                datosapasar.temptarifa2 = Convert.ToDecimal(row.Cells[6].Value);
                datosapasar.tempempleados = Convert.ToDecimal(row.Cells[7].Value);
                datosapasar.temppvempleados = Convert.ToDecimal(row.Cells[8].Value);
                datosapasar.templaboral = Convert.ToDecimal(row.Cells[9].Value);
                datosapasar.tempbase = Convert.ToDecimal(row.Cells[10].Value);
                datosapasar.tempiva = Convert.ToDecimal(row.Cells[11].Value);
                datosapasar.temptotal = Convert.ToDecimal(row.Cells[12].Value);
                datosapasar.temptipoiva = Convert.ToDecimal(row.Cells[13].Value);
                datosapasar.tempcod = Convert.ToDecimal(row.Cells[14].Value);

                datosapasar.temppormail = Convert.ToBoolean(row.Cells[15].Value);
                datosapasar.tempdoiciliado = Convert.ToBoolean(row.Cells[16].Value);
                datosapasar.tempcif = Convert.ToString(row.Cells[17].Value);
                datosapasar.tempdireccion = Convert.ToString(row.Cells[18].Value);
                datosapasar.templocalidad = Convert.ToString(row.Cells[19].Value);
                datosapasar.tempprovincia = Convert.ToString(row.Cells[20].Value);
                datosapasar.tempcp = Convert.ToString(row.Cells[21].Value);
                datosapasar.tempmail = Convert.ToString(row.Cells[22].Value);
                datosapasar.tempiban1 = Convert.ToString(row.Cells[23].Value);
                datosapasar.tempiban2 = Convert.ToDecimal(row.Cells[24].Value);
                datosapasar.tempiban3 = Convert.ToDecimal(row.Cells[25].Value);
                datosapasar.tempiban4 = Convert.ToDecimal(row.Cells[26].Value);
                datosapasar.tempiban5 = Convert.ToDecimal(row.Cells[27].Value);
                datosapasar.tempiban6 = Convert.ToDecimal(row.Cells[28].Value);




                lista.Add(datosapasar);

            }
            
            dataGridView1.DataSource = lista.ToList();

            //ahora vamos a pasar los datos a la tabla de factura.

            //**** calculamos el valor de la coluna numerador
            //var ultimonumerador = bd.Facturas.OrderByDescending(x => x.factcontador).First().factcontador;


            try
            {
                List<Facturas> facturasAGuardar = new List<Facturas>();
                
                foreach(var temp in lista)
                {
                    Facturas myFactura = new Facturas();

                    myFactura.factbase1 = temp.tempbase;
                    myFactura.factnumerofact = temp.tempnumerofactura;
                    myFactura.factremesa = temp.tempremesa;
                    myFactura.factfecha = temp.tempfecha;
                    myFactura.factcodcliente = temp.tempcod;
                    myFactura.factnombre = temp.tempnombre;
                    myFactura.factdireccion = temp.tempdireccion;
                    myFactura.factlocalidad = temp.templocalidad;
                    myFactura.factprovincia = temp.tempprovincia;
                    myFactura.factcp = temp.tempcp;
                    myFactura.factnif = temp.tempcif;
                    myFactura.factiban1 = temp.tempiban1;
                    myFactura.factiban2 = temp.tempiban2;
                    myFactura.factiban3 = temp.tempiban6;
                    myFactura.factiban4 = temp.tempiban4;
                    myFactura.factiban5 = temp.tempiban5;
                    myFactura.factiban6 = temp.tempiban6;
                    myFactura.factconcepto1 = temp.tempconcepto1;
                    myFactura.factbase1 = temp.temptarifa;
                    myFactura.factconcepto2 = temp.tempconcepto2;
                    myFactura.factbase2 = temp.temptarifa2;
                    myFactura.factemleados = temp.tempempleados;
                    myFactura.factprecioempleado = temp.temppvempleados;
                    myFactura.factbaseempleado = temp.templaboral;
                    myFactura.facttipoiva = temp.temptipoiva;
                    myFactura.factimporteiva = temp.tempiva;
                    myFactura.facttotalfactura = temp.temptotal;
                    myFactura.factpara_imprimir = true;
                    if (temp.temppormail == true)
                    {
                        myFactura.factpara_imprimir = false;
                    }
                    myFactura.factpormail = temp.temppormail;
                    myFactura.factmail = temp.tempmail;
                    myFactura.factimpresa = false;
                    myFactura.factparacontabilizar = true;
                    myFactura.factcontabilizada = false;
                    myFactura.factparadomiciliar = temp.tempdoiciliado;
                    myFactura.factdomiciliada = false;


    
                    facturasAGuardar.Add(myFactura);
                }

                bd.Facturas.AddRange(facturasAGuardar);
                bd.SaveChanges();

           


               

            }
            catch(Exception exp)
            { 
            }



        }

        private void dgvTemporal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void temporalBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}

