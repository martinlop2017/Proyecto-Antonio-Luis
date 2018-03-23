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
using System.Xml;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class CBS19 : Form
    {
        AdministracionAntonioEntities bd;
        string mesrremesa; // lo usamos para extraer el numero deremesa de la linea seleccionada en el dgv

        public CBS19()
        {
            InitializeComponent();
            
            bd = new AdministracionAntonioEntities();
            
        }


        private void CBS19_Load(object sender, EventArgs e)
        {
          /*  // TODO: esta línea de código carga datos en la tabla 'administracionAntonioDataSet1.Resilla' Puede moverla o quitarla según sea necesario.
                        this.resillaTableAdapter.Fill(this.administracionAntonioDataSet1.Resilla);
            // TODO: esta línea de código carga datos en la tabla 'administracionAntonioDataSet1.Facturas' Puede moverla o quitarla según sea necesario.
            this.facturasTableAdapter.Fill(this.administracionAntonioDataSet1.Facturas);
*/
            //al cargar el form filtra la base de datos Remesas por contabilizada = false, y lo mostramos en el dgv
            var remesasacontabilizar = bd.Resilla.Where(x => x.remesacontabilizada == false).ToList();
                dgvremesas.DataSource = remesasacontabilizar;
                
           
            if ( remesasacontabilizar.Count == 0 )
            {

                MessageBox.Show("No existen remesas por generar.\nVerifique el directorio de salida.","Error 103", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            dgvfacturas.DataSource = null;

        }

        private void dgvremesas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cuando pulsamos en el dvg extraemos el numero de la remesa
            int fila = Convert.ToInt32(dgvremesas.CurrentRow.Index);
            mesrremesa = Convert.ToString(dgvremesas[1, fila].Value);

            //filtramos la base de datos de facturacion por el numero de remesa. y que contabilizado= false
            var facturasacontabilizar = bd.Facturas.Where(x => x.factremesa == mesrremesa && x.factparadomiciliar == true 
                                        &&x.factdomiciliada == false).ToList();
            dgvfacturas.Visible = true;
            dgvfacturas.DataSource = facturasacontabilizar;

            label3.Text = facturasacontabilizar.Count.ToString();



            buttonAceptar.Enabled = true;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            //Variables donde introduciremos algunos datos.
            string referencia;
            string ano, mes, dia, hora, minuto, segundo;
            //variable para almacenar el mes de la fcatura para la referencia
            string mesfact;

            // cargamos estas variables con los datos actuales
            ano = DateTime.Now.ToString("yyyy");
            mes = DateTime.Now.ToString("MM");
            dia = DateTime.Now.ToString("dd");
            hora = DateTime.Now.ToString("HH");
            minuto = DateTime.Now.ToString("mm");
            segundo = DateTime.Now.ToString("ss");

            //Extraemos las tablas filtradas
            //filtramos la base de datos de facturacion por el numero de remesa. y que contabilizado= false
            // y lo pasamos a una lista

            var listafacturas = bd.Facturas.Where(x => x.factremesa == mesrremesa && x.factdomiciliada == false &&
                                                  x.factparadomiciliar == true  ).ToList();
            var mesfactura = listafacturas.OrderByDescending(x => x.factfecha).FirstOrDefault();
            var remesasacontabilizar = bd.Resilla.Where(x => x.remesacontabilizada == false).ToList();
            var importeremesa = remesasacontabilizar.SingleOrDefault(x => x.remesanumero ==mesrremesa);
            //         var mesfactura = listafacturas.OrderByDescending(x => x.factremesa).FirstOrDefault();
            //         
            //         var listaremesas = bd.Remesas.Where(x => x.remesanumero == mesfactura.ToString() ).ToList();
            //         var importeremesa = listaremesas.OrderByDescending(x => x.remesatotal).FirstOrDefault(); 

            //iniciamos el proresbar
            int progres = listafacturas.Count + 2;
            progressBar1.Maximum = 100;
            int avance = 100 / progres;
            progressBar1.Value = 0;
            label4.Text = "0";
            panel1.Visible = true;

            var tempo = bd.Cuentas.OrderByDescending (X => X.RutaCSB19).FirstOrDefault();
            string ruta = tempo.RutaCSB19.ToString()+("\\");
            string ruta2 = importeremesa.remesanumero.ToString()+ano+(".xml");
            
            //quitamos los espacios
            ruta = ruta.Replace(" ", "");
            ruta2 = ruta2.Replace(" ", "");
            string paht = ruta + ruta2;

            XmlTextWriter writer;

            writer = new XmlTextWriter (paht, Encoding.UTF8);
           //   writer = new XmlTextWriter(ruta+"\\ejemplocbs.xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();

            writer.WriteStartElement("Document", "urn:iso:std:iso:20022:tech:xsd:pain.008.001.02");



            //*******************************************************************************************************
            //*******************************************************************************************************
            //****************                  C A B E C E R A                 *************************************
            //*******************************************************************************************************
            //*******************************************************************************************************
            //*******************************************************************************************************

            // introducimos la cabecera sacandos los datos de "pasarpropios2donde cargo la base "Propios"
            writer.WriteStartElement("CstmrDrctDbtInitn");

            writer.WriteStartElement("GrpHdr");

            //introducimos la referencia identificativa del fichero
            //lleva "PRE+Fecha(AñoMEsDia)+Hora(hhmmss)+((mes de facturacion)+(10000000000000))+Cif Presentador + 


            //sacamos el mes de la factura para añadir e la refrerencia
            mesfact = "00" + mesfactura.factfecha. ToString().Substring(3,2);

            //sacamos el cif del presentador
            var cifpresentador = bd.Propios.OrderByDescending(X => X.micif).FirstOrDefault();
            referencia = "PRE" + ano + mes + dia + hora + minuto + mesfact + cifpresentador.micif.ToString();
            writer.WriteElementString("MsgId", referencia);

            //Introducimos la fecha y hora de presentacion
            writer.WriteElementString("CreDtTm", (ano + "-" + mes + "-" + dia + "T" + hora + ":" + minuto + ":" + segundo));

            // Introducimos el numero de transaciones.
            writer.WriteElementString("NbOfTxs", listafacturas.Count.ToString());

            //Introducimos el total de la remesa.
            //filtramos la tabla Remesas por la fecha de factura.
            string totalaremesar = importeremesa.remesatotal.ToString();
            totalaremesar = totalaremesar.Replace(',', '.');
            writer.WriteElementString("CtrlSum", totalaremesar);

            //Introducimos El nombre del presentador
            writer.WriteStartElement("InitgPty");
            var nombrepresentador = bd.Propios.OrderByDescending(X => X.minombre).FirstOrDefault();
            writer.WriteElementString("Nm", nombrepresentador.minombre.ToString());

            //Introducimos el identificador bancario
            writer.WriteStartElement("Id");
            writer.WriteStartElement("OrgId");
            writer.WriteStartElement("Othr");

            string limpiaespacios = (nombrepresentador.miidentificadorbancario + nombrepresentador.micif).ToString();
            limpiaespacios = limpiaespacios.Replace(" " , "");
            writer.WriteElementString("Id", limpiaespacios);

            writer.WriteStartElement("SchmeNm");
            writer.WriteElementString("Prtry", "SEPA");

            //cierra los elementos de la cabecera
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();

            //Codigo Interno
            writer.WriteStartElement("PmtInf");
            string texto = (nombrepresentador.miidentificadorbancario.ToString() + cifpresentador.micif.ToString()
                                        + ano + mes + dia + mesfact);
            texto = texto.Replace(" ", "");
            writer.WriteElementString("PmtInfId", texto );
            //Numero Operaciones e Importe
            writer.WriteElementString("PmtMtd", "DD");
            writer.WriteElementString("BtchBookg", "true");
            writer.WriteElementString("NbOfTxs", listafacturas.Count.ToString());

            writer.WriteElementString("CtrlSum", totalaremesar.ToString());

            writer.WriteStartElement("PmtTpInf");

            //Estos datos son fijos
            writer.WriteStartElement("SvcLvl");
            writer.WriteElementString("Cd", "SEPA");
            writer.WriteEndElement();
            writer.WriteStartElement("LclInstrm");
            writer.WriteElementString("Cd", "CORE");
            writer.WriteEndElement();
            writer.WriteElementString("SeqTp", "RCUR");
            writer.WriteEndElement();

            //Fecha de ejecucion
            writer.WriteElementString("ReqdColltnDt", ano + "-" + mes + "-" + dia);

            //Datos del presentador/Cobrador
            writer.WriteStartElement("Cdtr");
            writer.WriteElementString("Nm", nombrepresentador.minombre);
            writer.WriteStartElement("PstlAdr");
            //Pais del presentador
            writer.WriteElementString("Ctry", "ES");
            //Direcion del presentador
            writer.WriteElementString("AdrLine", ".");
            writer.WriteElementString("AdrLine", "..");
            writer.WriteEndElement();
            writer.WriteEndElement();
            //Iban del presentador
            writer.WriteStartElement("CdtrAcct");
            //Datos bancarios presentador
            writer.WriteStartElement("Id");
            writer.WriteElementString("IBAN", nombrepresentador.miiban1 + nombrepresentador.miiban2 +
                nombrepresentador.miiban3 + nombrepresentador.miiban4 + nombrepresentador.miiban5 + nombrepresentador.miiban6);
            writer.WriteEndElement();
            writer.WriteElementString("Ccy", "EUR");
            
            writer.WriteEndElement();
            writer.WriteStartElement("CdtrAgt");
            writer.WriteStartElement("FinInstnId");
            writer.WriteElementString("BIC","NOTPROVIDED");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteElementString("ChrgBr", "SLEV");
            writer.WriteStartElement("CdtrSchmeId");
            writer.WriteStartElement("Id");
            writer.WriteStartElement("PrvtId");
            writer.WriteStartElement("Othr");
            texto = (nombrepresentador.miidentificadorbancario + nombrepresentador.micif);
            texto = texto.Replace(" ", "");
            writer.WriteElementString("Id", texto);
            writer.WriteStartElement("SchmeNm");
            writer.WriteElementString("Prtry", "SEPA");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();


            progressBar1.Value = progressBar1.Value + avance;
            label4.Text = progressBar1.Value.ToString(); 


            //*******************************************************************************************************
            //*******************************************************************************************************
            //*******************************************************************************************************
            //*******************************************************************************************************
            //*******************************************************************************************************
            //*******************************************************************************************************




            //=======================================================================================================            
            //=======================================================================================================            
            //=======================================================================================================            
            //===============          C A R G O S   F A C T U R A S           ======================================
            //=======================================================================================================
            //=======================================================================================================

            //INICIAMOS SEGUNDO BLOQUE.

            //Recorremos la tabla facturas para ir sacando los recibos.
            int contador = 1;

            foreach (var temp in listafacturas)

            {
                //cargamos los datos de cada recibo 
                writer.WriteStartElement("DrctDbtTxInf");
                writer.WriteStartElement("PmtId");
                //identificador de la transferencia (añomesdiahoraminutossegundosnumerofactura)
                writer.WriteElementString("EndToEndId", ano + mes + dia + hora + minuto + segundo + "00" + temp.factnumerofact);
                writer.WriteEndElement();
                writer.WriteStartElement("InstdAmt");
                //moneda de la operacion
                writer.WriteAttributeString("Ccy", "EUR");
                //importe de la factura
                //SUSTITUIMOS LA COMA POR UN PUNTO.
                String apagar = temp.facttotalfactura.ToString();
                apagar = apagar.Replace(",", ".");

                writer.WriteString(apagar);
                writer.WriteEndElement();
                //datos del revibo
                writer.WriteStartElement("DrctDbtTx");
                writer.WriteStartElement("MndtRltdInf");
                //introducimos el mandato ( contador + fecha dia+mes+año)
                writer.WriteElementString("MndtId", contador + dia + mes + ano);
                writer.WriteElementString("DtOfSgntr", "2011-01-11");
                writer.WriteElementString("AmdmntInd", "false");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("DbtrAgt");
                writer.WriteElementString("FinInstnId", "");
                writer.WriteEndElement();
                //Introduce el nombre del cliente
                writer.WriteStartElement("Dbtr");
                writer.WriteElementString("Nm", temp.factnombre);
                writer.WriteEndElement();

                writer.WriteStartElement("DbtrAcct");
                writer.WriteStartElement("Id");
                writer.WriteElementString("IBAN", temp.factiban1 + temp.factiban2 + temp.factiban3 + temp.factiban4 +
                                            temp.factiban5 + temp.factiban6);
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("RmtInf");
                writer.WriteElementString("Ustrd", "FACTURA N. " + temp.factnumerofact);
                writer.WriteEndElement();
                writer.WriteEndElement();



                contador++;

                progressBar1.Value = progressBar1.Value + avance;
                label4.Text = progressBar1.Value.ToString();
            }

            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();


            //damos las facturas como domiciliadas
            // Filtramos la tabla facuras por contabilizadas por las no contabilizadas
            var facturasfiltradas = bd.Facturas.Where(x => x.factdomiciliada == false);
            //Modificamos el campo
            facturasfiltradas.ToList().ForEach(f => f.factdomiciliada = true);


            //damos las remesas como domiciliadas
            // Filtramos la tabla facuras por contabilizadas por las no contabilizadas
            var remesasfiltradas = bd.Resilla.Where(x => x.remesacontabilizada == false);
            //Modificamos el campo
            remesasfiltradas.ToList().ForEach(f => f.remesacontabilizada = true);

            // Guardamos los cambios
            bd.SaveChanges();

            progressBar1.Value = progressBar1.Value + avance;
            label4.Text = progressBar1.Value.ToString();

            MessageBox.Show("Archivo generado satisfactoriamente.\nVerifique el directorio de salida.","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();

            Close();
        }

        private void dgvremesas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
      
            
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }
    }
}
