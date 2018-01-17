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

                // cargamos estas variables con los datos actuales
                ano = DateTime.Now.ToString("yyyy");
                mes = DateTime.Now.ToString("MM");
                dia = DateTime.Now.ToString("dd");
                hora = DateTime.Now.ToString("HH");
                minuto = DateTime.Now.ToString("mm");
                segundo = DateTime.Now.ToString("ss");


           



            //Variables y listas donde vamos a cargar las tablas
            Propios pasarpropios = new Propios();


            XmlTextWriter writer;
            writer = new XmlTextWriter("C:\\Equipo Martin\\Programacion\\archivo prueba\\ejemplocbs.xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();

            writer.WriteStartElement("Document", "urn:iso:std:iso:20022:tech:xsd:pain.008.001.02");

            // introducimos la cabecera sacandos los datos de "pasarpropios2donde cargo la base "Propios"
            writer.WriteStartElement("CstmrDrctDbtInitn");

            writer.WriteStartElement("GrpHdr");

            //introducimos la referencia identificativa del fichero
            //lleva "PRE+Fecha(AñoMEsDia)+Hora(hhmmss)+((mes de facturacion)+(10000000000000))+Cif Presentador + 

            referencia = "PRE" + ano + mes + dia + hora + minuto + segundo;
            label1.Text = referencia;
            writer.WriteElementString("MsgId", "2018011113255000000");




            writer.WriteElementString("CreDtTm", "2018-01-11T12:26:06Z");
            writer.WriteElementString("NbOfTxs", "1");
            writer.WriteElementString("CtrlSum", "1.4");

            writer.WriteStartElement("InitgPty");
            writer.WriteElementString("Nm", "MARTIN LOPEZ");

            writer.WriteStartElement("Id");

            writer.WriteStartElement("OrgId");

            writer.WriteStartElement("Othr");

            writer.WriteElementString("Id", "ES8600144207587T");

            writer.WriteStartElement("SchmeNm");

            writer.WriteElementString("Prtry", "SEPA");

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteStartElement("PmtInf");
            writer.WriteElementString("PmtInfId", "B21156054 2018-08-23 RCUR 1");
            writer.WriteElementString("PmtMtd", "DD");
            writer.WriteElementString("NbOfTxs", "1");
            writer.WriteElementString("CtrlSum", "1.40");

            writer.WriteStartElement("PmtTpInf");


            writer.WriteStartElement("SvcLvl");
            writer.WriteElementString("Cd", "SEPA");
            writer.WriteEndElement();

            writer.WriteStartElement("LclInstrm");
            writer.WriteElementString("Cd", "CORE");
            writer.WriteEndElement();

            writer.WriteElementString("SeqTp", "RCUR");
            writer.WriteEndElement();

            writer.WriteElementString("ReqdColltnDt", "2018-08-23");

            writer.WriteStartElement("Cdtr");
            writer.WriteElementString("Nm", "HNOS FELIPE S.L.");
            writer.WriteElementString("PstlAdr", "");
            writer.WriteEndElement();

            writer.WriteStartElement("CdtrAcct");

            writer.WriteStartElement("Id");
            writer.WriteElementString("IBAN", "ES5821002703970210075120");
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteStartElement("CdtrAgt");
            writer.WriteStartElement("FinInstnId");
            writer.WriteElementString("BIC", "CAIXESBB");
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteElementString("ChrgBr", "SLEV");

            writer.WriteStartElement("CdtrSchmeId");
            writer.WriteStartElement("Id");
            writer.WriteStartElement("PrvtId");
            writer.WriteStartElement("Othr");
            writer.WriteElementString("Id", "ES29002b21156054");
            writer.WriteStartElement("SchmeNm");
            writer.WriteElementString("Prtry", "SEPA");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteStartElement("DrctDbtTxInf");
            writer.WriteStartElement("PmtId");
            writer.WriteElementString("EndToEndId", "FACTURA A25");
            writer.WriteEndElement();


            writer.WriteStartElement("InstdAmt");
            writer.WriteAttributeString("Ccy", "EUR");
            writer.WriteString("1.40");
            writer.WriteEndElement();


            writer.WriteStartElement("DrctDbtTx");
            writer.WriteStartElement("MndtRltdInf");
            writer.WriteElementString("MndtId", "43000125");
            writer.WriteElementString("DtOfSgntr", "201/-01-11");
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteStartElement("DbtrAgt");
            writer.WriteElementString("FinInstnId", "");
            writer.WriteEndElement();

            writer.WriteStartElement("Dbtr");
            writer.WriteElementString("Nm", "CLIENTE1");
            writer.WriteEndElement();

            writer.WriteStartElement("DbtrAcct");
            writer.WriteStartElement("Id");
            writer.WriteElementString("IBAN", "ES9602388108440600454315");
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteStartElement("RmtInf");
            writer.WriteElementString("Ustrd", "FACTURA MENSUAL");
            writer.WriteEndElement();


            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();







        }

        private void button2_Click(object sender, EventArgs e)
        {
           


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }   
    }

}
