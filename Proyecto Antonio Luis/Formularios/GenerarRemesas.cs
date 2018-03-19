﻿using System;
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
using System.Xml;
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
            

           



            //Variables y listas donde vamos a cargar las tablas
            Propios pasarpropios = new Propios();


            var listafacturas = bd.Facturas.Where(x => x.factdomiciliada == false && x.factparadomiciliar == true).ToList();

            dataGridView1.DataSource = listafacturas.ToList();
        

            var mesfactura = listafacturas.OrderByDescending(x => x.factfecha).FirstOrDefault();
            var listaremesas = bd.Resilla.Where(x => x.remesafecha == mesfactura.ToString()).ToList();
            var importeremesa = listaremesas.OrderByDescending(x => x.remesatotal).FirstOrDefault();
            




            XmlTextWriter writer;
            writer = new XmlTextWriter("C:\\Equipo Martin\\Programacion\\archivo prueba\\ejemplocbs.xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();

            writer.WriteStartElement("Document", "urn:iso:std:iso:20022:tech:xsd:pain.008.001.02");



//*******************************************************************************************************
//*******************************************************************************************************
//****************                  C A B E C E R A                 *************************************            //*******************************************************************************************************
//*******************************************************************************************************
//*******************************************************************************************************
// introducimos la cabecera sacandos los datos de "pasarpropios2donde cargo la base "Propios"
            writer.WriteStartElement("CstmrDrctDbtInitn");

            writer.WriteStartElement("GrpHdr");

            //introducimos la referencia identificativa del fichero
            //lleva "PRE+Fecha(AñoMEsDia)+Hora(hhmmss)+((mes de facturacion)+(10000000000000))+Cif Presentador + 

            //sacamos el mes de la factura para añadir e la refrerencia
                        mesfact = "00" + mesfactura.factfecha.ToString().Substring(3, 2);
            //sacamos el cif del presentador
                        var cifpresentador = bd.Propios.OrderByDescending(X => X.micif).FirstOrDefault();
                        referencia = "PRE" + ano + mes + dia + hora + minuto + segundo + mesfact+ cifpresentador.micif.ToString();
                        writer.WriteElementString("MsgId", referencia);

            //Introducimos la fecha y hora de presentacion
                        writer.WriteElementString("CreDtTm", (ano+"-"+mes+"-"+dia+"T"+hora+":"+minuto+":"+segundo));

            // Introducimos el numero de transaciones.
                        writer.WriteElementString("NbOfTxs", listafacturas.Count.ToString());

            //Introducimos el total de la remesa.
            //filtramos la tabla Remesas por la fecha de factura.
                        writer.WriteElementString("CtrlSum", importeremesa.remesatotal. ToString());

            //Introducimos El nombre del presentador
                        writer.WriteStartElement("InitgPty");
            var nombrepresentador = bd.Propios.OrderByDescending(X => X.minombre).FirstOrDefault();
                        writer.WriteElementString("Nm", nombrepresentador.minombre.ToString());

            //Introducimos el identificador bancario
            writer.WriteStartElement("Id");
            writer.WriteStartElement("OrgId");
            writer.WriteStartElement("Othr");

            writer.WriteElementString("Id", nombrepresentador.miidentificadorbancario+ nombrepresentador.micif );

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
            writer.WriteElementString("PmtInfId", nombrepresentador.miidentificadorbancario.ToString()+cifpresentador.micif.ToString()
                                        + ano+mes+dia+mesfact);
            //Numero Operaciones e Importe
            writer.WriteElementString("PmtMtd", "DD");
            writer.WriteElementString("BtchBookg", "true");
            writer.WriteElementString("NbOfTxs", listafacturas.Count.ToString());
            writer.WriteElementString("CtrlSum", importeremesa.remesatotal.ToString());

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
            writer.WriteElementString("ReqdColltnDt", ano+"-"+mes+"-"+dia);

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
            writer.WriteElementString("IBAN", nombrepresentador.miiban1+ nombrepresentador.miiban2+
                nombrepresentador.miiban3+ nombrepresentador.miiban4+ nombrepresentador.miiban5+ nombrepresentador.miiban6);
            writer.WriteElementString("Ccy", "EUR");
             writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("CdtrAgt");
            writer.WriteStartElement("FinInstnId");
            writer.WriteElementString("BIC", nombrepresentador.mibic);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteElementString("ChrgBr", "SLEV");
            writer.WriteStartElement("CdtrSchmeId");
            writer.WriteStartElement("Id");
            writer.WriteStartElement("PrvtId");
            writer.WriteStartElement("Othr");
            writer.WriteElementString("Id", nombrepresentador.miidentificadorbancario+nombrepresentador.micif);
            writer.WriteStartElement("SchmeNm");
            writer.WriteElementString("Prtry", "SEPA");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();





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
                writer.WriteElementString("EndToEndId", ano+mes+dia+hora+minuto+segundo+"00"+temp.factnumerofact);
                writer.WriteEndElement();
                writer.WriteStartElement("InstdAmt");
                //moneda de la operacion
                writer.WriteAttributeString("Ccy", "EUR");
                //importe de la factura
                writer.WriteString(temp.facttotalfactura.ToString());
                writer.WriteEndElement();
                //datos del revibo
                writer.WriteStartElement("DrctDbtTx");
                writer.WriteStartElement("MndtRltdInf");
                //introducimos el mandato ( contador + fecha dia+mes+año)
                writer.WriteElementString("MndtId", contador +dia+mes+ano);
                writer.WriteElementString("DtOfSgntr", "201/-01-11");
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
                writer.WriteElementString("IBAN", temp.factiban1+temp.factiban2+ temp.factiban3+ temp.factiban4+
                                            temp.factiban5+ temp.factiban6);
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("RmtInf");
                writer.WriteElementString("Ustrd", "FACTURA N. "+temp.factnumerofact);
                writer.WriteEndElement();
                writer.WriteEndElement();



                contador++;
            }

                writer.WriteEndDocument();
            writer.Flush();
            writer.Close();


            //damos las facturas como domiciliadas
            // Filtramos la tabla facuras por contabilizadas por las no contabilizadas
            var facturasfiltradas = bd.Facturas.Where(x => x.factdomiciliada ==false);
            //Modificamos el campo
            facturasfiltradas.ToList().ForEach ( f => f.factdomiciliada = true);


            //damos las remesas como domiciliadas
            // Filtramos la tabla facuras por contabilizadas por las no contabilizadas
            var remesasfiltradas = bd.Resilla .Where(x => x.remesacontabilizada == false);
            //Modificamos el campo
            remesasfiltradas.ToList().ForEach(f => f.remesacontabilizada = true);

            // Guardamos los cambios
            bd.SaveChanges();



            

                    label2.Text = "termino";



        }

        private void button2_Click(object sender, EventArgs e)
        {
            int fila = Convert.ToInt32(dataGridView1.CurrentRow.Index);
           caja.Text  = Convert.ToString(dataGridView1[0, fila].Value);


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void GenerarRemesas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'administracionAntonioDataSet.Remesas' Puede moverla o quitarla según sea necesario.
            this.remesasTableAdapter.Fill(this.administracionAntonioDataSet.Remesas);
            //filtramos la tabla de remesa por no contabilizada
            var remesaspendientes = bd.Resilla.Where(x => x.remesacontabilizada  == false).ToList();

            dataGridView1.DataSource = remesaspendientes;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
