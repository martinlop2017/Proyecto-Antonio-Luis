using System;
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
                // sacamos la ruta de salida del archivo
                var rutas = bd.Cuentas.First();
                //marchamos la ruta de salida y el nomnre del archivo
                string rutasalida = rutas.RutaDiario.ToString(); //.Replace(" ", "");
                string rutaCompleta = (rutasalida + @"\miarchivo.txt");
                string nivel = rutas.NumDigitos;
                int cuentanivel = Convert.ToInt32(rutas.CtaCliente);
                string cuentabase = rutas.CtaPrestaciones.ToString();
                string cuentaiva = rutas.IvaGeneral.ToString();
                string cuentabanco = rutas.CtaBanco.ToString();
                string cuentasuplido = rutas.CtaSuplido.ToString();


                //filtramos la tabla por contabilizados sea igual a falso.
                var apasar = bd.Facturas.Where(x => x.factparacontabilizar == true && x.factcontabilizada == false).ToList();

                // si no existen datos por pasar
                if (apasar.Count == 0)
                {

                    MessageBox.Show("No existen documentos por contabilizar.", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                else
                {
                    string fechaentera = apasar.First().factfecha.ToString();
                    string dia = fechaentera.Substring(0, 2);
                    string mes = fechaentera.Substring(3, 2);
                    string ano = fechaentera.Substring(6, 4);

                    string fecha = ano + mes + dia;
                    decimal sumatoriaremesa = 0;

                    //carga los valores en la barra de progreso
                    int contador = 100 / apasar.Count;
                    progressBar1.Step = contador;
                    panel2.Visible = true;

                    progressBar1.Maximum = apasar.Count;

                    using (System.IO.StreamWriter nuevalinea = new System.IO.StreamWriter(rutaCompleta))

                    {
                        foreach (var temp in apasar)
                        {
                            //avanza la barra de progreso
                            progressBar1.Value = progressBar1.Value + 1;

                            string cuenta = Convert.ToString(cuentanivel + temp.factcodcliente);
                            string debe = Convert.ToString(temp.facttotalfactura);

                            debe = debe.Replace(",", ".");
                            string ivaapagar = Convert.ToString(temp.factimporteiva);
                            ivaapagar = ivaapagar.Replace(",", ".");
                            string bases = Convert.ToString(temp.factbase1.Value  + temp.factbaseempleado.Value);
                            bases = bases.Replace(",", ".");

                            string basesuplida = Convert.ToString(temp.factbase2.Value);
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

                            

                                // LINEA 3, pas los suplidos
                            if (temp.factbase2 != 0)
                            {
                                nuevalinea.WriteLine(
                                "1".PadLeft(6, ' ')
                                + fecha
                                + cuentasuplido.PadRight(12, ' ')
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
                                + basesuplida.PadLeft(16, ' ')
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
                            + "0.00".PadLeft(16, ' ')
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


                    //marcamos lo s registros como contabilizados
                    foreach (var temp in apasar)
                    {
                        temp.factcontabilizada = true;
                    }
                    bd.SaveChanges();

                    MessageBox.Show("Archivo generado satisfactoriamente.");
                        Close();

                }

            }
            catch (OleDbException exp)
            {
                MessageBox.Show("Error" + exp.Message);
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Contaplus_Load(object sender, EventArgs e)
        {

        }
    }
}
