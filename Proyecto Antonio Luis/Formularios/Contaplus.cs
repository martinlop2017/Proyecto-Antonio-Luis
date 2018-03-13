﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using BaseDatos;
using Proyecto_Antonio_Luis.Clases;
using System.IO;


namespace Proyecto_Antonio_Luis.Formularios


{
    public partial class Contaplus : Form
    {
        AdministracionAntonioEntities bd;

        public Contaplus()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string cadena = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Equipo Martin\\Programacion\\Repositorio Remoto\\Proyecto Antonio Luis; Extended Properties = dBase IV; User ID =;Password=";
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = cadena;
                con.Open();

                string consulta = "Select * from clientes";
                OleDbDataAdapter adapter = new OleDbDataAdapter(consulta, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                con.Close();

                this.dataGridView1.DataSource = ds.Tables[0];








            }
            catch (OleDbException exp)
            {
                MessageBox.Show("Error" + exp.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<PasoClientes> lista = new List<PasoClientes>();



            foreach (DataGridViewRow row in dataGridView1.Rows)

            {
                PasoClientes datosapasar = new PasoClientes();

                datosapasar.nuevocodcliente = Convert.ToDecimal(row.Cells[0].Value);
                datosapasar.nuevonombrecliente = Convert.ToString(row.Cells[1].Value);
                datosapasar.nuevocifcliente = Convert.ToString(row.Cells[6].Value);
                datosapasar.nuevodirecioncliente = Convert.ToString(row.Cells[2].Value);
                datosapasar.nuevolocalidadcliente = Convert.ToString(row.Cells[3].Value);
                datosapasar.nuevoprovinciacliente = Convert.ToString(row.Cells[5].Value);
                datosapasar.nuevocod_postalcliente = Convert.ToString(row.Cells[4].Value);
                datosapasar.nuevotelefono1cliente = Convert.ToInt64(row.Cells[8].Value);
                datosapasar.nuevotelefono2cliente = Convert.ToDecimal(row.Cells[10].Value);
                datosapasar.nuevofaxcliente = Convert.ToDecimal(row.Cells[9].Value);
                datosapasar.nuevocontactocliente = Convert.ToString(row.Cells[11].Value);
                datosapasar.nuevomailcliente = Convert.ToString(row.Cells[12].Value);
                datosapasar.nuevoactivocliente = Convert.ToBoolean(row.Cells[15].Value);
                datosapasar.nuevodomiciliadocliente = Convert.ToBoolean(row.Cells[24].Value);
                datosapasar.nuevoiban1cliente = Convert.ToString(row.Cells[18].Value);
                datosapasar.nuevoiban2cliente = Convert.ToString(row.Cells[19].Value);
                datosapasar.nuevoiban3cliente = Convert.ToString(row.Cells[20].Value);
                datosapasar.nuevoiban4cliente = Convert.ToString(row.Cells[21].Value);
                datosapasar.nuevoiban5cliente = Convert.ToString(row.Cells[22].Value);
                datosapasar.nuevoiban6cliente = Convert.ToString(row.Cells[23].Value);
                datosapasar.nuevogrupocliente = Convert.ToString(row.Cells[7].Value);
                datosapasar.nuevoempleadoscliente = Convert.ToDecimal(row.Cells[49].Value);
                datosapasar.nuevofechaaltacliente = Convert.ToString(row.Cells[41].Value);
                datosapasar.nuevofechabajacliente = Convert.ToString(row.Cells[42].Value);
                datosapasar.nuevotarifacliente = Convert.ToDecimal(row.Cells[16].Value);
                datosapasar.nuevoavioncliente = Convert.ToString(row.Cells[27].Value);
                datosapasar.nuevomod100 = Convert.ToBoolean(row.Cells[46].Value);
                datosapasar.nuevomod111 = Convert.ToBoolean(row.Cells[28].Value);
                datosapasar.nuevomod115 = Convert.ToBoolean(row.Cells[33].Value);
                datosapasar.nuevomod123 = Convert.ToBoolean(row.Cells[35].Value);
                datosapasar.nuevomod130 = Convert.ToBoolean(row.Cells[44].Value);
                datosapasar.nuevomod131 = Convert.ToBoolean(row.Cells[45].Value);
                datosapasar.nuevomod180 = Convert.ToBoolean(row.Cells[34].Value);
                datosapasar.nuevomod190 = Convert.ToBoolean(row.Cells[29].Value);
                datosapasar.nuevomod193 = Convert.ToBoolean(row.Cells[36].Value);
                datosapasar.nuevomod200 = Convert.ToBoolean(row.Cells[38].Value);
                datosapasar.nuevomod202 = Convert.ToBoolean(row.Cells[37].Value);
                datosapasar.nuevomod303 = Convert.ToBoolean(row.Cells[30].Value);
                datosapasar.nuevomod309 = Convert.ToBoolean(row.Cells[32].Value);
                datosapasar.nuevomod349 = Convert.ToBoolean(row.Cells[31].Value);
                datosapasar.nuevomod390 = Convert.ToBoolean(row.Cells[40].Value);
                datosapasar.nuevomod751 = Convert.ToBoolean(row.Cells[47].Value);
                datosapasar.nuevomod752 = Convert.ToBoolean(row.Cells[48].Value);
                datosapasar.nuevointrastatcliente = Convert.ToBoolean(row.Cells[39].Value);
                datosapasar.nuevocomentariocliente = Convert.ToString(row.Cells[13].Value);
                // datosapasar.nuevorecargocliente = Convert.ToBoolean(row.Cells[48].Value);
                lista.Add(datosapasar);
            }

            dataGridView2.DataSource = lista.ToList();

            try
            {

                //ahora vamos a pasr los datos a la abala clientes

                List<Clientes> clientesaAGuardar = new List<Clientes>();


                foreach (var temp in lista)
                {
                    Clientes myCliente = new Clientes();

                    myCliente.codcliente = temp.nuevocodcliente;
                    myCliente.nombrecliente = temp.nuevonombrecliente;
                    myCliente.cifcliente = temp.nuevocifcliente;
                    myCliente.direcioncliente = temp.nuevodirecioncliente;
                    myCliente.localidacliente = temp.nuevodirecioncliente;
                    myCliente.provinciacliente = temp.nuevoprovinciacliente;
                    myCliente.cod_postalcliente = temp.nuevocod_postalcliente;
                    myCliente.telefono1cliente = temp.nuevotelefono1cliente;
                    myCliente.telefono2cliente = temp.nuevotelefono2cliente;
                    myCliente.faxcliente = temp.nuevofaxcliente;
                    myCliente.contactocliente = temp.nuevocontactocliente;
                    myCliente.mailcliente = temp.nuevomailcliente;
                    myCliente.activocliente = temp.nuevoactivocliente;
                    myCliente.domiciliadocliente = temp.nuevodomiciliadocliente;
                    myCliente.iban1cliente = temp.nuevoiban1cliente.ToString();
                    myCliente.iban2cliente = temp.nuevoiban2cliente.ToString();
                    myCliente.iban3cliente = temp.nuevoiban3cliente.ToString();
                    myCliente.iban4cliente = temp.nuevoiban4cliente.ToString();
                    myCliente.iban5cliente = temp.nuevoiban5cliente.ToString();
                    myCliente.iban6cliente = temp.nuevoiban6cliente.ToString();
                    myCliente.grupocliente = temp.nuevogrupocliente;
                    myCliente.empleadoscliente = temp.nuevoempleadoscliente;
                    //myCliente.fechaaltacliente = Convert.ToDateTime(temp.nuevofechaaltacliente);
                    //myCliente.fechabajacliente = Convert.ToDateTime(temp.nuevofechabajacliente);
                    myCliente.tarifacliente = temp.nuevotarifacliente;
                    myCliente.avioncliente = temp.nuevoavioncliente;
                    myCliente.mod100 = temp.nuevomod100;
                    myCliente.mod111 = temp.nuevomod111;
                    myCliente.mod115 = temp.nuevomod115;
                    myCliente.mod123 = temp.nuevomod123;
                    myCliente.mod130 = temp.nuevomod130;
                    myCliente.mod131 = temp.nuevomod131;
                    myCliente.mod180 = temp.nuevomod180;
                    myCliente.mod190 = temp.nuevomod190;
                    myCliente.mod193 = temp.nuevomod193;
                    myCliente.mod200 = temp.nuevomod200;
                    myCliente.mod202 = temp.nuevomod202;
                    myCliente.mod303 = temp.nuevomod303;
                    myCliente.mod309 = temp.nuevomod309;
                    myCliente.mod349 = temp.nuevomod349;
                    myCliente.mod390 = temp.nuevomod390;
                    myCliente.mod751 = temp.nuevomod751;
                    myCliente.mod752 = temp.nuevomod752;
                    myCliente.instrastatcliente = temp.nuevointrastatcliente;
                    myCliente.comentariocliente = temp.nuevocomentariocliente;
                    myCliente.altacliente = temp.nuevoaltacliente;
                    myCliente.bajacliente = temp.nuevobajacliente;
                    myCliente.pormailcliente = temp.nuevopormailcliente;
                    myCliente.contabilizarcliente = true;
                    myCliente.precioempleadocliente = 10;


                    clientesaAGuardar.Add(myCliente);

                }

                // pasamos los datos a la tabla facturacion y remesa
                bd.Clientes.AddRange(clientesaAGuardar);

                bd.SaveChanges();

            }
            catch (OleDbException exp)
            {
                MessageBox.Show("Error" + exp.Message);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // sacamos la ruta de salida del archivo
            var rutas = bd.Cuentas.First();
            //marchamos la ruta de salida y el nomnre del archivo
            string rutasalida = rutas.RutaDiario.ToString(); //.Replace(" ", "");
            string rutaCompleta = (rutasalida +@"\miarchivo.txt" );
            string nivel = rutas.NumDigitos;
            int cuentanivel = Convert.ToInt32( rutas.CtaCliente);
            string cuentabase = rutas.CtaPrestaciones.ToString();
            string cuentaiva = rutas.IvaGeneral.ToString();
            string cuentabanco = rutas.CtaBanco.ToString();
                        
            //filtramos la tabla por contabilizados sea igual a falso.
            var apasar = bd.Facturas.Where(x => x.factparacontabilizar == true && x.factcontabilizada == false).ToList();
            dataGridView1.DataSource = apasar;

  //          string totalremesa = apasar.First().facttotalremesa.ToString();
  //          totalremesa = totalremesa.Replace(",", ".");

            string fechaentera = apasar.First().factfecha.ToString();
            string dia = fechaentera.Substring( 0,2);
            string mes = fechaentera.Substring(3, 2);
            string ano = fechaentera.Substring(6, 4);

            string fecha = ano + mes + dia;
            decimal sumatoriaremesa = 0;
           


            using (System.IO.StreamWriter nuevalinea = new System.IO.StreamWriter(rutaCompleta))

            {
                foreach (var temp in apasar)
                {
                    string cuenta = Convert.ToString(cuentanivel + temp.factcodcliente);
                    string debe = Convert.ToString(temp.facttotalfactura);

                    debe = debe.Replace(",", ".");
                    string ivaapagar = Convert.ToString(temp.factimporteiva);
                    ivaapagar = ivaapagar.Replace(",", ".");
                    string bases = Convert.ToString(temp.factbase1.Value + temp.factbase2.Value + temp.factbaseempleado.Value);
                    bases = bases.Replace(",", ".");
                    string nombre = temp.factnombre;
                    nombre = nombre.Replace("   ", "");

                    sumatoriaremesa = sumatoriaremesa + temp.facttotalfactura.Value;
          
                    nuevalinea.WriteLine(
                // LINEA 1, PASO TOTAL DE LA FACTURA
                "1".PadLeft(6, ' ')
                + fecha
                + cuenta.PadRight(12, ' ')
                + " ".PadLeft(12, ' ')
                + "0.00".PadLeft(16, ' ')
                + ("N. Factura " + temp.factnumerofact.ToString()).PadRight(25, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(5, ' ')
                + "0.00".PadLeft(5, ' ')
                + " ".PadLeft(10, ' ')
                + " ".PadLeft(3, ' ')


                + " ".PadLeft(6, ' ')
                + " ".PadLeft(1, ' ')
                + "0".PadLeft(6, ' ')
                + "0".PadLeft(1, ' ')
                + "0".PadLeft(6, ' ')
                + "0.000000".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(1, ' ')
                + " ".PadLeft(1, ' ')
                + " ".PadLeft(4, ' ')
                + " ".PadLeft(5, ' ')
                + "0.00".PadLeft(16, ' ')


                + "2"
                + debe.PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + " "
                + " ".PadLeft(10, ' ')
                + " "
                + "0".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + "F"
                + " ".PadLeft(8, ' ')
                + "E"


                + " "
                + " ".PadLeft(6, ' ')
                + " "
                + " ".PadLeft(6, ' ')
                + " ".PadLeft(6, ' ')
                + "F"
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(5, ' ')
                + " ".PadLeft(10, ' ')
                + "0.00".PadLeft(5, ' ')
                + "0.00".PadLeft(5, ' ')
                + "0".PadLeft(6, ' ')


                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(100, ' ')
                + " ".PadLeft(50, ' ')
                + " ".PadLeft(50, ' ')
                + " "
                + "0".PadLeft(8, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(40, ' ')
                + "0"
                + " ".PadLeft(15, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(9, ' ')
                + "F"


                + " ".PadLeft(10, ' ')
                + "F"
                + "F"
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(12, ' ')
                + "0"
                + " ".PadLeft(40, ' ')
                + " "
                + " "
                + " "
                + "F"
                + "0".PadLeft(4, ' ')
                + " ".PadLeft(15, ' ')


                + " ".PadLeft(12, ' ')
                + " ".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(12, ' ')
                + " ".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "F"
                + " "
                + " ".PadLeft(25, ' ')
                + "0"


                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + "F"
                + " ".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(32, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(2, ' ')
                + " ".PadLeft(50, ' ')
                + " "
                + " "
                + " ".PadLeft(34, ' ')
                + "F"


                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(8, ' ')
                + "0".PadLeft(2, ' ')
                + "0.00".PadLeft(16, ' ')
                + "F"
                + "F"
                + "0".PadLeft(2, ' ')
                + " ".PadLeft(40, ' ')
                + "0"
                + "0".PadLeft(2, ' ')


                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "0.00".PadLeft(16, ' ')
                + "F"
                + "0"
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' '));

                nuevalinea.WriteLine(
                // LINEA 2, PASO BASE DE LA FACTURA
                "1".PadLeft(6, ' ')
                + fecha
                + cuentabase.PadRight(12, ' ')
                + " ".PadLeft(12, ' ')
                + "0.00".PadLeft(16, ' ')
                + ("N. Factura " + temp.factnumerofact.ToString()).PadRight(25, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(5, ' ')
                + "0.00".PadLeft(5, ' ')
                + " ".PadLeft(10, ' ')
                + " ".PadLeft(3, ' ')


                + " ".PadLeft(6, ' ')
                + " ".PadLeft(1, ' ')
                + "0".PadLeft(6, ' ')
                + "0".PadLeft(1, ' ')
                + "0".PadLeft(6, ' ')
                + "0.000000".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(1, ' ')
                + " ".PadLeft(1, ' ')
                + " ".PadLeft(4, ' ')
                + " ".PadLeft(5, ' ')
                + "0.00".PadLeft(16, ' ')


                + "2"
                + "0.00".PadLeft(16, ' ')
                + bases.PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + " "
                + " ".PadLeft(10, ' ')
                + " "
                + "0".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + "F"
                + " ".PadLeft(8, ' ')
                + "E"


                + " "
                + " ".PadLeft(6, ' ')
                + " "
                + " ".PadLeft(6, ' ')
                + " ".PadLeft(6, ' ')
                + "F"
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(5, ' ')
                + " ".PadLeft(10, ' ')
                + "0.00".PadLeft(5, ' ')
                + "0.00".PadLeft(5, ' ')
                + "0".PadLeft(6, ' ')


                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(100, ' ')
                + " ".PadLeft(50, ' ')
                + " ".PadLeft(50, ' ')
                + " "
                + "0".PadLeft(8, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(40, ' ')
                + "0"
                + " ".PadLeft(15, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(9, ' ')
                + "F"


                + " ".PadLeft(10, ' ')
                + "F"
                + "F"
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(12, ' ')
                + "0"
                + " ".PadLeft(40, ' ')
                + " "
                + " "
                + " "
                + "F"
                + "0".PadLeft(4, ' ')
                + " ".PadLeft(15, ' ')


                + " ".PadLeft(12, ' ')
                + " ".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(12, ' ')
                + " ".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "F"
                + " "
                + " ".PadLeft(25, ' ')
                + "0"


                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + "F"
                + " ".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(32, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(2, ' ')
                + " ".PadLeft(50, ' ')
                + " "
                + " "
                + " ".PadLeft(34, ' ')
                + "F"


                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(8, ' ')
                + "0".PadLeft(2, ' ')
                + "0.00".PadLeft(16, ' ')
                + "F"
                + "F"
                + "0".PadLeft(2, ' ')
                + " ".PadLeft(40, ' ')
                + "0"
                + "0".PadLeft(2, ' ')


                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "0.00".PadLeft(16, ' ')
                + "F"
                + "0"
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' '));


                nuevalinea.WriteLine(
                // LINEA 3, PASO BASE DE IVA
                "1".PadLeft(6, ' ')
                + fecha
                + cuentaiva.PadRight(12, ' ')
                + cuenta.PadRight(12, ' ')
                + "0.00".PadLeft(16, ' ')
                + ("N. Factura " + temp.factnumerofact.ToString()).PadRight(25, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + temp.facttipoiva.ToString().PadLeft(5, ' ')
                + "0.00".PadLeft(5, ' ')
                + " ".PadLeft(10, ' ')
                + " ".PadLeft(3, ' ')


                + " ".PadLeft(6, ' ')
                + " ".PadLeft(1, ' ')
                + "0".PadLeft(6, ' ')
                + "0".PadLeft(1, ' ')
                + "0".PadLeft(6, ' ')
                + "0.000000".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(1, ' ')
                + " ".PadLeft(1, ' ')
                + " ".PadLeft(4, ' ')
                + " ".PadLeft(5, ' ')
                + "0.00".PadLeft(16, ' ')


                + "2"
                + "0.00".PadLeft(16, ' ')
                + ivaapagar.PadLeft(16, ' ')
                + bases.PadLeft(16, ' ')
                + "F"
                + " ".PadLeft(10, ' ')
                + " "
                + "0".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + "F"
                + " ".PadLeft(8, ' ')
                + "E"


                + "F"
                + " ".PadLeft(6, ' ')
                + " "
                + " ".PadLeft(6, ' ')
                + " ".PadLeft(6, ' ')
                + "F"
                + " ".PadLeft(8, ' ')
                + fecha.PadLeft(8, ' ')
                + " ".PadLeft(5, ' ')
                + " ".PadLeft(10, ' ')
                + "0.00".PadLeft(5, ' ')
                + "0.00".PadLeft(5, ' ')
                + "0".PadLeft(6, ' ')


                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(100, ' ')
                + " ".PadLeft(50, ' ')
                + " ".PadLeft(50, ' ')
                + " "
                + "1".PadLeft(8, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(40, ' ')
                + "1"
                + temp.factnif.ToString().PadLeft(15, ' ')
                + nombre.PadLeft(40, ' ')
                + " ".PadLeft(9, ' ')
                + "F"
/*

                + " ".PadLeft(10, ' ')
                + "F"
                + "F"
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(12, ' ')
                + "0"
                + " ".PadLeft(40, ' ')
                + "E"
                + "G"
                + " ".PadLeft(40,' ')
                + "F"
                + "0".PadLeft(4, ' ')
                + " ".PadLeft(15, ' ')


                + " ".PadLeft(12, ' ')
                + " ".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(12, ' ')
                + " ".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "F"
                + " "
                + " ".PadLeft(25, ' ')
                + "0"

                
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + "F"
                + " ".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(32, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(2, ' ')
                + " ".PadLeft(50, ' ')
                + " "
                + " "
                + " ".PadLeft(34, ' ')
                + "F"


                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(8, ' ')
                + "0".PadLeft(2, ' ')
                + "0.00".PadLeft(16, ' ')
                + "F"
                + "F"
                + "0".PadLeft(2, ' ')
                + " ".PadLeft(40, ' ')
                + "0"
                + "0".PadLeft(2, ' ')


                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "0.00".PadLeft(16, ' ')
                + "F"
                + "0"
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
   */
                );



                    nuevalinea.WriteLine(
                    // LINEA 4, PASO COBRO CLIENTE
                    "1".PadLeft(6, ' ')
                    + fecha
                    + cuenta.PadRight(12, ' ')
                    + " ".PadLeft(12, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + "Cobro Remesa.".PadRight(25, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + "0".PadLeft(8, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + "0.00".PadLeft(5, ' ')
                    + "0.00".PadLeft(5, ' ')
                    + " ".PadLeft(10, ' ')
                    + " ".PadLeft(3, ' ')


                    + " ".PadLeft(6, ' ')
                    + " ".PadLeft(1, ' ')
                    + "0".PadLeft(6, ' ')
                    + "0".PadLeft(1, ' ')
                    + "0".PadLeft(6, ' ')
                    + "0.000000".PadLeft(16, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + " ".PadLeft(1, ' ')
                    + " ".PadLeft(1, ' ')
                    + " ".PadLeft(4, ' ')
                    + " ".PadLeft(5, ' ')
                    + "0.00".PadLeft(16, ' ')


                    + "2"
                    + "0.00".PadLeft(16,' ')
                    + debe.PadLeft(16, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + " "
                    + " ".PadLeft(10, ' ')
                    + " "
                    + "0".PadLeft(8, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + "F"
                    + " ".PadLeft(8, ' ')
                    + "E"


                    + " "
                    + " ".PadLeft(6, ' ')
                    + " "
                    + " ".PadLeft(6, ' ')
                    + " ".PadLeft(6, ' ')
                    + "F"
                    + " ".PadLeft(8, ' ')
                    + " ".PadLeft(8, ' ')
                    + " ".PadLeft(5, ' ')
                    + " ".PadLeft(10, ' ')
                    + "0.00".PadLeft(5, ' ')
                    + "0.00".PadLeft(5, ' ')
                    + "0".PadLeft(6, ' ')


                    + "0.00".PadLeft(16, ' ')
                    + " ".PadLeft(100, ' ')
                    + " ".PadLeft(50, ' ')
                    + " ".PadLeft(50, ' ')
                    + " "
                    + "0".PadLeft(8, ' ')
                    + " ".PadLeft(40, ' ')
                    + " ".PadLeft(40, ' ')
                    + "0"
                    + " ".PadLeft(15, ' ')
                    + " ".PadLeft(40, ' ')
                    + " ".PadLeft(9, ' ')
                    + "F"


                    + " ".PadLeft(10, ' ')
                    + "F"
                    + "F"
                    + "0.00".PadLeft(16, ' ')
                    + " ".PadLeft(12, ' ')
                    + "0"
                    + " ".PadLeft(40, ' ')
                    + " "
                    + " "
                    + " "
                    + "F"
                    + "0".PadLeft(4, ' ')
                    + " ".PadLeft(15, ' ')


                    + " ".PadLeft(12, ' ')
                    + " ".PadLeft(8, ' ')
                    + "0.00".PadLeft(16, ' ')
    /*                + " ".PadLeft(40, ' ')
                    + " ".PadLeft(12, ' ')
                    + " ".PadLeft(8, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + " ".PadLeft(40, ' ')
                    + "0".PadLeft(2, ' ')
                    + "F"
                    + " "
                    + " ".PadLeft(25, ' ')
                    + "0"


                    + "0".PadLeft(2, ' ')
                    + "0".PadLeft(2, ' ')
                    + "F"
                    + " ".PadLeft(8, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + " ".PadLeft(32, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + " ".PadLeft(2, ' ')
                    + " ".PadLeft(50, ' ')
                    + " "
                    + " "
                    + " ".PadLeft(34, ' ')
                    + "F"


                    + " ".PadLeft(40, ' ')
                    + "0".PadLeft(2, ' ')
                    + "0".PadLeft(2, ' ')
                    + " ".PadLeft(8, ' ')
                    + " ".PadLeft(8, ' ')
                    + "0".PadLeft(2, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + "F"
                    + "F"
                    + "0".PadLeft(2, ' ')
                    + " ".PadLeft(40, ' ')
                    + "0"
                    + "0".PadLeft(2, ' ')


                    + "0".PadLeft(2, ' ')
                    + "0".PadLeft(2, ' ')
                    + "0".PadLeft(2, ' ')
                    + " ".PadLeft(40, ' ')
                    + " ".PadLeft(40, ' ')
                    + "0".PadLeft(2, ' ')
                    + "0.00".PadLeft(16, ' ')
                    + "F"
                    + "0"
                    + " ".PadLeft(8, ' ')
                    + " ".PadLeft(40, ' ')
                    + "0".PadLeft(2, ' ')
                    + "0".PadLeft(2, ' '));
  */
                    );
                }

                string sumatoria1 = Convert.ToString(sumatoriaremesa);
                sumatoria1 = sumatoria1.Replace(",", ".");
                nuevalinea.WriteLine(
                // LINEA 5, PASO COBRO BANCO
                "1".PadLeft(6, ' ')
                + fecha
                + cuentabanco.PadRight(12, ' ')
                + " ".PadLeft(12, ' ')
                + "0.00".PadLeft(16, ' ')
                + "Cobro Remesa.".PadRight(25, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(5, ' ')
                + "0.00".PadLeft(5, ' ')
                + " ".PadLeft(10, ' ')
                + " ".PadLeft(3, ' ')


                + " ".PadLeft(6, ' ')
                + " ".PadLeft(1, ' ')
                + "0".PadLeft(6, ' ')
                + "0".PadLeft(1, ' ')
                + "0".PadLeft(6, ' ')
                + "0.000000".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(1, ' ')
                + " ".PadLeft(1, ' ')
                + " ".PadLeft(4, ' ')
                + " ".PadLeft(5, ' ')
                + "0.00".PadLeft(16, ' ')


                + "2"
                + sumatoria1.ToString().PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + " "
                + " ".PadLeft(10, ' ')
                + " "
                + "0".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + "0.00".PadLeft(16, ' ')
                + "F"
                + " ".PadLeft(8, ' ')
                + "E"


                + " "
                + " ".PadLeft(6, ' ')
                + " "
                + " ".PadLeft(6, ' ')
                + " ".PadLeft(6, ' ')
                + "F"
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(5, ' ')
                + " ".PadLeft(10, ' ')
                + "0.00".PadLeft(5, ' ')
                + "0.00".PadLeft(5, ' ')
                + "0".PadLeft(6, ' ')


                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(100, ' ')
                + " ".PadLeft(50, ' ')
                + " ".PadLeft(50, ' ')
                + " "
                + "0".PadLeft(8, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(40, ' ')
                + "0"
                + " ".PadLeft(15, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(9, ' ')
                + "F"


                + " ".PadLeft(10, ' ')
                + "F"
                + "F"
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(12, ' ')
                + "0"
                + " ".PadLeft(40, ' ')
                + " "
                + " "
                + " "
                + "F"
                + "0".PadLeft(4, ' ')
                + " ".PadLeft(15, ' ')


                + " ".PadLeft(12, ' ')
                + " ".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(12, ' ')
                + " ".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "F"
                + " "
                + " ".PadLeft(25, ' ')
                + "0"


                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + "F"
                + " ".PadLeft(8, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(32, ' ')
                + "0.00".PadLeft(16, ' ')
                + " ".PadLeft(2, ' ')
                + " ".PadLeft(50, ' ')
                + " "
                + " "
                + " ".PadLeft(34, ' ')
                + "F"


                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(8, ' ')
                + "0".PadLeft(2, ' ')
                + "0.00".PadLeft(16, ' ')
                + "F"
                + "F"
                + "0".PadLeft(2, ' ')
                + " ".PadLeft(40, ' ')
                + "0"
                + "0".PadLeft(2, ' ')


                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' ')
                + " ".PadLeft(40, ' ')
                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "0.00".PadLeft(16, ' ')
                + "F"
                + "0"
                + " ".PadLeft(8, ' ')
                + " ".PadLeft(40, ' ')
                + "0".PadLeft(2, ' ')
                + "0".PadLeft(2, ' '));



            }

        }

    }
}
