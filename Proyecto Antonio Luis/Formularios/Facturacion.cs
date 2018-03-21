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
using Proyecto_Antonio_Luis.Formularios;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class Facturacion : Form
    {
         AdministracionAntonioEntities bd;
        //esta lista la declaro arriba para poder usarla posteriormente
        List<albaranesclientes> albaranes = new List<albaranesclientes>();
        List<datoslistadoreme> alistar = new List<datoslistadoreme>();
        private List<string> originalClientValues;


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
            // TODO: esta línea de código carga datos en la tabla 'administracionAntonioDataSet1.Facturas' Puede moverla o quitarla según sea necesario.
            //this.facturasTableAdapter.Fill(this.administracionAntonioDataSet1.Facturas);
            // cargamos el combo del iva y la fecha.
            comboiva.DataSource = bd.Iva.Select(user => user.ivaporciento).ToList();
            comboiva.Text = "21";

            fechafactura.Value = DateTime.Now;

            //mostramos el mes actual
            combomes.Text = DateTime.Now.ToString("MMMM");


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

            dgvTemporal.DataSource = albaranes.OrderBy(x => x.albnombre).ToList();
            //**************************

            label14.Text = albaranes.Count.ToString();

            //activamos los botones de imprimir y facturar.
            facturar.Enabled = true;
            
            añadir.Enabled = true;
            eliminar.Enabled = true;




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
            if (dgvTemporal.Columns[e.ColumnIndex].Name == "albtarifaDataGridViewTextBoxColumn")
            {
                fila = Convert.ToInt32(dgvTemporal.CurrentRow.Index);


                // cargamos las variables con los datos del dgv
                tarifa1albaran = Convert.ToDecimal(dgvTemporal[6, fila].Value);
                tarifa2albaran = Convert.ToDecimal(dgvTemporal[8, fila].Value);
                laboralalbaran = Convert.ToDecimal(dgvTemporal[11, fila].Value);
                tipoivaalbaran = Convert.ToDecimal(dgvTemporal[1, fila].Value);

                // realizamos lo scalculos
                basealbaran = (tarifa1albaran + tarifa2albaran + laboralalbaran);
                ivaalbaran = ((tarifa1albaran + laboralalbaran) * tipoivaalbaran)/100;

                totalalbaran = basealbaran + ivaalbaran;

                // cargamos los datos e el dgv
                dgvTemporal[12, fila].Value = basealbaran;
                dgvTemporal[13, fila].Value = ivaalbaran;
                dgvTemporal[14, fila].Value = totalalbaran;
            }



            // realizamos esto si modificamos la tarifa 2 (SUPLIDOS)
            if (dgvTemporal.Columns[e.ColumnIndex].Name == "albtarifa2DataGridViewTextBoxColumn")
            {
                fila = Convert.ToInt32(dgvTemporal.CurrentRow.Index);


                // cargamos las variables con los datos del dgv
                tarifa1albaran = Convert.ToDecimal(dgvTemporal[6, fila].Value);
                tarifa2albaran = Convert.ToDecimal(dgvTemporal[8, fila].Value);
                laboralalbaran = Convert.ToDecimal(dgvTemporal[11, fila].Value);
                tipoivaalbaran = Convert.ToDecimal(dgvTemporal[1, fila].Value);

                // realizamos lo scalculos
                basealbaran = (tarifa1albaran + tarifa2albaran + laboralalbaran);
                ivaalbaran = ((tarifa1albaran + laboralalbaran) * tipoivaalbaran) / 100;

                totalalbaran = basealbaran + ivaalbaran;

                // cargamos los datos e el dgv
                dgvTemporal[12, fila].Value = basealbaran;
                dgvTemporal[13, fila].Value = ivaalbaran;
                dgvTemporal[14, fila].Value = totalalbaran;
            }


            // realizamos esto si modificamos los empleados o el precio por emleado
            if ((dgvTemporal.Columns[e.ColumnIndex].Name == "albempleadosDataGridViewTextBoxColumn") ||
                    (dgvTemporal.Columns[e.ColumnIndex].Name == "albpvpempleadosDataGridViewTextBoxColumn"))
            {
                fila = Convert.ToInt32(dgvTemporal.CurrentRow.Index);

                // cargamos las variables con los datos del dgv
                tarifa1albaran = Convert.ToDecimal(dgvTemporal[6, fila].Value);
                tarifa2albaran = Convert.ToDecimal(dgvTemporal[8, fila].Value);
                tipoivaalbaran = Convert.ToDecimal(dgvTemporal[1, fila].Value);
                empleadosalbaran = Convert.ToInt32(dgvTemporal[9, fila].Value);
                precioempleadoalbaran = Convert.ToDecimal(dgvTemporal[10, fila].Value);

                // realizamos lo scalculos
                laboralalbaran = empleadosalbaran * precioempleadoalbaran;
                basealbaran = (tarifa1albaran + tarifa2albaran + laboralalbaran);
                ivaalbaran = ((tarifa1albaran + laboralalbaran) * tipoivaalbaran) / 100;
                totalalbaran = basealbaran + ivaalbaran;

                // cargamos los datos e el dgv
                dgvTemporal[12, fila].Value = basealbaran;
                dgvTemporal[13, fila].Value = ivaalbaran;
                dgvTemporal[14, fila].Value = totalalbaran;
                dgvTemporal[11, fila].Value = laboralalbaran;

            }



            }

        private void añadir_Click(object sender, EventArgs e)
        {

            // hace visible el panel de busqueda y ordena por numero de cliente
            panel3.Visible = true;
            var nuevocliente = bd.Clientes.OrderBy(y => y.nombrecliente);
            dataGridView2.DataSource = nuevocliente.ToList();


        }


 

        private void facturar_Click(object sender, EventArgs e)
        {
            

            generar.Enabled = false;
            añadir.Enabled = false;
            eliminar.Enabled = false;
            imprimir.Enabled = true;
            facturar.Enabled = false;
            //mostramos el detagrib
            dataGridView1.Visible = true;
           




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
                datosapasar.temptipoiva = Convert.ToDecimal(row.Cells[1].Value);
                datosapasar.tempcod = Convert.ToDecimal(row.Cells[2].Value);
                datosapasar.tempfecha = Convert.ToString(row.Cells[3].Value);
                datosapasar.tempnombre = Convert.ToString(row.Cells[4].Value);
                datosapasar.tempconcepto1 = Convert.ToString(row.Cells[5].Value);
                datosapasar.temptarifa = Convert.ToDecimal(row.Cells[6].Value);
                datosapasar.tempconcepto2 = Convert.ToString(row.Cells[7].Value);
                datosapasar.temptarifa2 = Convert.ToDecimal(row.Cells[8].Value);
                datosapasar.tempempleados = Convert.ToDecimal(row.Cells[9].Value);
                datosapasar.temppvempleados = Convert.ToDecimal(row.Cells[10].Value);
                datosapasar.templaboral = Convert.ToDecimal(row.Cells[11].Value);
                datosapasar.tempbase = Convert.ToDecimal(row.Cells[12].Value);
                datosapasar.tempiva = Convert.ToDecimal(row.Cells[13].Value);
                datosapasar.temptotal = Convert.ToDecimal(row.Cells[14].Value);
                datosapasar.temppormail = Convert.ToBoolean(row.Cells[15].Value);
                datosapasar.tempdoiciliado = Convert.ToBoolean(row.Cells[16].Value);
                datosapasar.tempcif = Convert.ToString(row.Cells[17].Value);
                datosapasar.tempdireccion = Convert.ToString(row.Cells[18].Value);
                datosapasar.templocalidad = Convert.ToString(row.Cells[19].Value);
                datosapasar.tempprovincia = Convert.ToString(row.Cells[20].Value);
                datosapasar.tempcp = Convert.ToString(row.Cells[21].Value);
                datosapasar.tempmail = Convert.ToString(row.Cells[22].Value);
                datosapasar.tempiban1 = Convert.ToString(row.Cells[23].Value);
                datosapasar.tempiban2 = Convert.ToString(row.Cells[24].Value);
                datosapasar.tempiban3 = Convert.ToString(row.Cells[25].Value);
                datosapasar.tempiban4 = Convert.ToString(row.Cells[26].Value);
                datosapasar.tempiban5 = Convert.ToString(row.Cells[27].Value);
                datosapasar.tempiban6 = Convert.ToString(row.Cells[28].Value);
                datosapasar.tempparadomiciliar = Convert.ToBoolean(row.Cells[31].Value);
                datosapasar.tempparaimprimir = Convert.ToBoolean(row.Cells[32].Value);
                datosapasar.tempparacontabilizar = Convert.ToBoolean(row.Cells[33].Value);





                lista.Add(datosapasar);

            }
            
            dataGridView1.DataSource = lista.ToList();

            //ahora vamos a pasar los datos a la tabla de factura.

            //**** calculamos el valor de la coluna numerador
            //var ultimonumerador = bd.Facturas.OrderByDescending(x => x.factcontador).First().factcontador;


            try
            {
                decimal totalbaseremesa = 0;
                decimal totalivaremesa = 0;
                decimal totaltotalremesa = 0;
                string numeroremesa = "";
                string fecharemesa = "";
               int totaldocumentos = 0;


                List<Facturas> facturasAGuardar = new List<Facturas>();

                //            List<datoslistadoreme> alistar = new List<datoslistadoreme>();

                foreach (var temp in lista)
                {
                    datoslistadoreme mylistado = new datoslistadoreme();
                    Facturas myFactura = new Facturas();


                    myFactura.factbase1 = temp.tempbase;
                    myFactura.factnumerofact = temp.tempnumerofactura;
                    mylistado.listnumerofactura = temp.tempnumerofactura.ToString();

                    myFactura.factremesa = temp.tempremesa;
                    myFactura.factfecha = temp.tempfecha;
                    myFactura.factcodcliente = temp.tempcod;
                    myFactura.factnombre = temp.tempnombre;
                    mylistado.listnombre = temp.tempnombre;

                    myFactura.factdireccion = temp.tempdireccion;
                    myFactura.factlocalidad = temp.templocalidad;
                    myFactura.factprovincia = temp.tempprovincia;
                    myFactura.factcp = temp.tempcp;
                    myFactura.factnif = temp.tempcif;
                    myFactura.factiban1 = temp.tempiban1;
                    myFactura.factiban2 = temp.tempiban2;
                    myFactura.factiban3 = temp.tempiban3;
                    myFactura.factiban4 = temp.tempiban4;
                    myFactura.factiban5 = temp.tempiban5;
                    myFactura.factiban6 = temp.tempiban6;
                    myFactura.factconcepto1 = temp.tempconcepto1;
                    mylistado.listconcepto1 = temp.tempconcepto1;

                    myFactura.factbase1 = temp.temptarifa;
                    mylistado.listbase = temp.tempbase;

                    myFactura.factconcepto2 = temp.tempconcepto2;
                    myFactura.factbase2 = temp.temptarifa2;
                    mylistado.listsuplidos = temp.temptarifa2;

                    myFactura.factemleados = temp.tempempleados;
                    myFactura.factprecioempleado = temp.temppvempleados;
                    myFactura.factbaseempleado = temp.templaboral;
                    myFactura.facttipoiva = temp.temptipoiva;
                    myFactura.factimporteiva = temp.tempiva;
                    mylistado.listiva = temp.tempiva;

                    myFactura.facttotalfactura = temp.temptotal;
                    mylistado.listtotal = temp.temptotal;

                    myFactura.factpara_imprimir = true;
                    myFactura.factimpresa = false;

                    if (temp.temppormail == true)
                    {
                        myFactura.factpara_imprimir = false;
                    }
                    myFactura.factpormail = temp.temppormail;
                    myFactura.factmail = temp.tempmail;

                    myFactura.factparacontabilizar = temp.tempparacontabilizar;
                    myFactura.factcontabilizada = false;
                    myFactura.factparadomiciliar = temp.tempparadomiciliar;
                    myFactura.factdomiciliada = false;

                    totalbaseremesa = totalbaseremesa + temp.tempbase;


                    totalivaremesa = totalivaremesa + temp.tempiva;
                    totaltotalremesa = totaltotalremesa + temp.temptotal;

                    numeroremesa = temp.tempremesa;
                    fecharemesa = temp.tempfecha;
                    mylistado.listfecha = temp.tempfecha; ;


                    mylistado.listnombreemisor = bd.Propios.First().minombre;
                    // mylistado.listtotalremesa = totaltotalremesa;
                    mylistado.listnumeroremesa = numeroremesa;

                    facturasAGuardar.Add(myFactura);
                    alistar.Add(mylistado);
                }
                    // pasamos los datos a la tabla facturacion y remesa
                    bd.Facturas.AddRange(facturasAGuardar);
                    bd.SaveChanges();
                

            var pasoremesa = new Resilla();
                pasoremesa.remesanumero = numeroremesa;
                

                pasoremesa.remesafecha = fecharemesa;
                pasoremesa.remesatotal = Convert.ToDecimal( totaltotalremesa);
                // pasoremesa.remesaimpresa = false;
                pasoremesa.remesacontabilizada = false;



                // pasamos los datos a remesa
                bd.Resilla.Add(pasoremesa);

                //grabamos el total de la remesa en la clase a listar
                alistar.ToList().ForEach(x => x.listtotalremesa = totaltotalremesa);
                totaldocumentos = alistar.Count;
                alistar.ToList().ForEach(x => x.listtotaldocumentos  = totaldocumentos );
               


               


                //ahora vamos a introducir el total de la remesa en las facturas.

                // Filtramos la tabla facuras por el numero de remesa
                var facturasfiltradas = bd.Facturas.Where(x => x.factremesa == numeroremesa);
                //Modificamos el campo
                facturasfiltradas.ToList().ForEach(f => f.facttotalremesa = totaltotalremesa);


                // Guardamos los cambios
                bd.SaveChanges();



                //desasctivamos los botones de generar, añadir y borrar
                añadir.Enabled = false;
                generar.Enabled = false;
                eliminar.Enabled = false;


                // cargamos la pantalla de listados de remesas
                Form2 form = new Form2(alistar);
                form.Show();


            }

            catch (Exception exp)
            {
                MessageBox.Show("Error" + exp.Message);
            }

       }









        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int fila = Convert.ToInt32(dataGridView2.CurrentRow.Index);
            decimal esteclienod = Convert.ToDecimal(dataGridView2[1, fila].Value);


            var porcodigo2 = bd.Clientes.Where(x => x.codcliente == esteclienod).ToList();


            dataGridView2.DataSource = porcodigo2.ToList();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            var busqueda = from c in bd.Clientes select c;
            busqueda = busqueda.Where(c => c.nombrecliente.Contains(textBox2.Text)).OrderBy(x => x.nombrecliente);

            dataGridView2.DataSource = busqueda.ToList();

        }

        private void textBox2_Enter_1(object sender, EventArgs e)
        {
            // ordena por nombre de cliente
            var nuevocliente = bd.Clientes.OrderBy(y => y.nombrecliente);
            dataGridView2.DataSource = nuevocliente.ToList();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)

            {
                albaranesclientes datosapasar = new albaranesclientes();
                datosapasar.albcod = Convert.ToDecimal(row.Cells[1].Value);
                datosapasar.albnombre = Convert.ToString(row.Cells[2].Value);
                datosapasar.albcif = Convert.ToString(row.Cells[3].Value);
                datosapasar.albdireccion = Convert.ToString(row.Cells[4].Value);
                datosapasar.alblocalidad = Convert.ToString(row.Cells[5].Value);
                datosapasar.albprovincia = Convert.ToString(row.Cells[6].Value);
                datosapasar.albcp = Convert.ToString(row.Cells[7].Value);
                datosapasar.albmail = Convert.ToString(row.Cells[12].Value);
                datosapasar.albpormail = Convert.ToBoolean(row.Cells[13].Value);
                datosapasar.albdomiciliado = Convert.ToBoolean(row.Cells[16].Value);
                datosapasar.albiban1 = Convert.ToString(row.Cells[19].Value);
                datosapasar.albiban2 = Convert.ToString(row.Cells[20].Value);
                datosapasar.albiban3 = Convert.ToString(row.Cells[21].Value);
                datosapasar.albiban4 = Convert.ToString(row.Cells[15].Value);
                datosapasar.albiban5 = Convert.ToString(row.Cells[22].Value);
                datosapasar.albiban6 = Convert.ToString(row.Cells[26].Value);
                datosapasar.albempleados = Convert.ToInt64(row.Cells[25].Value);
                datosapasar.albpvpempleados = Convert.ToDecimal(row.Cells[51].Value);
                datosapasar.albtarifa = Convert.ToDecimal(row.Cells[28].Value);
                datosapasar.albfecha = Globales.fechafactura.ToString("dd/MM/yyy");
                datosapasar.albmes = Globales.mesfactura;
                datosapasar.albconcepto1 = "Honorarios Correspondiente al mes de " + Globales.mesfactura.ToString();
                datosapasar.albconcepto2 = null;
                datosapasar.albtarifa2 = 0;
                datosapasar.albtipoiva = Globales.tipoiva;
                datosapasar.alblaboral = Convert.ToDecimal((Convert.ToInt64(row.Cells[25].Value)) * (Convert.ToDecimal(row.Cells[51].Value)));
                datosapasar.albbase = Convert.ToDecimal(Convert.ToDecimal(row.Cells[28].Value)) +
                   ((Convert.ToInt64(row.Cells[25].Value)) * (Convert.ToDecimal(row.Cells[51].Value)));

                datosapasar.albiva = Convert.ToDecimal(((Convert.ToDecimal(row.Cells[28].Value)) +
                   ((Convert.ToInt64(row.Cells[25].Value)) * (Convert.ToDecimal(row.Cells[51].Value)))) * Globales.tipoiva / 100);

                datosapasar.albtotal = Convert.ToDecimal(Convert.ToDecimal(row.Cells[28].Value)) +
                   ((Convert.ToInt64(row.Cells[25].Value)) * (Convert.ToDecimal(row.Cells[51].Value)) +
                   Convert.ToDecimal(((Convert.ToDecimal(row.Cells[28].Value)) +
                   ((Convert.ToInt64(row.Cells[25].Value)) * (Convert.ToDecimal(row.Cells[51].Value)))) * Globales.tipoiva / 100));

                datosapasar.albparadomiciliar = Convert.ToBoolean(row.Cells[16].Value);
                datosapasar.albparacontabilizar = Convert.ToBoolean(row.Cells[18].Value);



                albaranes.Add(datosapasar);
            }
            panel3.Visible = false;

            dgvTemporal.DataSource =  albaranes.OrderBy(x => x.albnombre).ToList();

            label14.Text = albaranes.Count.ToString();
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void eliminar_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Va a proceder a eliminar el registro seleccionado.\n                     Desea Eliminar el registro?"
                                 , "Eliminar Registro.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) 
            {
                Globales.modificar = Convert.ToInt16(dgvTemporal.CurrentRow.Cells[2].Value);

                try
                {
                    dgvTemporal.DataSource = albaranes.Remove(albaranes.First(x => x.albcod == Globales.modificar));
                   
                    dgvTemporal.DataSource = albaranes.OrderBy(x=> x.albnombre). ToList();

                    label14.Text = albaranes.Count.ToString();


                }
                catch (Exception exp)
                {

                    MessageBox.Show("Error" + exp.Message);

                }

            }
        }
    }
    
}
