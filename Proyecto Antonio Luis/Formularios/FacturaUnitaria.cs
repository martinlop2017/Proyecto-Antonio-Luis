using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Antonio_Luis.Clases;
using BaseDatos;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class FacturaUnitaria : Form
    {
        AdministracionAntonioEntities bd;
        List<albaranesclientes> nuevafactura = new List<albaranesclientes>();
        bool encontrado = false;
        string cliente;

        //*** variables para calcular las bases e ivas.
        decimal base0, base4, base10, base21, basesupl;
        bool iva0, iva10, iva4, iva21, supli = false;
        //**************************************
        //**************************************
        //  variable que controla si los datos del cliente los toma de la base cliente o del formulario
        bool clientenuevo;
        public FacturaUnitaria()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
            
        }

        private void FacturaUnitaria_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'administracionAntonioDataSet1.Iva' Puede moverla o quitarla según sea necesario.
            this.ivaTableAdapter.Fill(this.administracionAntonioDataSet1.Iva);
            //carga la tabla de clientes en el conbo
            dataGridView2.DataSource = bd.Clientes.ToList();

            //carga el numero de factura
            var numerofactura = bd.Facturas.OrderByDescending(x => x.factnumerofact).Take(1).FirstOrDefault();
            labelNumeroFactura.Text = (numerofactura.factnumerofact.Value + 1).ToString();
 



            //  comboBox1.DataSource = baseDeDatos.Ususarios.Where(user => user.activo == true).Select(user => user.nombre).ToList<string>();

        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            Globales.llamadas = "1";

            if (Globales.llamadas == "1")
            {
                var datoscliente = bd.Clientes.Where(x => x.nombrecliente == textBox13.Text).Take(1).FirstOrDefault();

                var nuevafactura = new Facturas();

               
                //si el cliente no existe en la tabla cliente toma los datos del formulario
                if (clientenuevo == true)
                {
                    
                    nuevafactura.factcodcliente = 9999999999;
                    nuevafactura.factnombre = textBox1.Text;
                    nuevafactura.factdireccion = textBox3.Text;
                    nuevafactura.factlocalidad = textBox4.Text;
                    nuevafactura.factprovincia = textBox5.Text;
                    nuevafactura.factcp = textBox6.Text;
                    nuevafactura.factnif = textBox2.Text;
                    
                    nuevafactura.factimpresa = false;
                    if (checkBox2.Checked == true)
                    {
                        nuevafactura.factparacontabilizar = true;
                    }
                    else
                    {
                        nuevafactura.factparacontabilizar = false;
                    }
                    nuevafactura.factcontabilizada = false;
                    if (checkBox3.Checked == true)
                    {
                        nuevafactura.factparadomiciliar = true;
                        nuevafactura.factiban1 = textBox7.Text;
                        nuevafactura.factiban2 = textBox8.Text;
                        nuevafactura.factiban3 = textBox9.Text;
                        nuevafactura.factiban4 = textBox10.Text;
                        nuevafactura.factiban5 = textBox11.Text;
                        nuevafactura.factiban6 = textBox12.Text;

                    }
                    else
                    {
                        nuevafactura.factparadomiciliar = false;
                    }
                    nuevafactura.factdomiciliada = false;
               
                }
                
                //si el cliente existe en la tabla de clientes
                if (clientenuevo == false)
                {
                    
                    nuevafactura.factcodcliente = datoscliente.codcliente;
                    nuevafactura.factnombre = datoscliente.nombrecliente;
                    nuevafactura.factdireccion = datoscliente.direcioncliente;
                    nuevafactura.factlocalidad = datoscliente.localidacliente;
                    nuevafactura.factprovincia = datoscliente.provinciacliente;
                    nuevafactura.factcp = datoscliente.cod_postalcliente;
                    nuevafactura.factnif = datoscliente.cifcliente;
                    nuevafactura.factiban1 = datoscliente.iban1cliente;
                    nuevafactura.factiban2 = datoscliente.iban2cliente;
                    nuevafactura.factiban3 = datoscliente.iban3cliente;
                    nuevafactura.factiban4 = datoscliente.iban4cliente;
                    nuevafactura.factiban5 = datoscliente.iban5cliente;
                    nuevafactura.factiban6 = datoscliente.iban6cliente;
                    nuevafactura.factimpresa = false;
                    nuevafactura.factparacontabilizar = datoscliente.contabilizarcliente;
                    nuevafactura.factcontabilizada = false;
                    nuevafactura.factparadomiciliar = datoscliente.domiciliadocliente;
                    nuevafactura.factdomiciliada = false;
                    

                }

                //estos son genericos no deneden de los clientes
                nuevafactura.factfecha = dateTimePickerFecha.Text;
                nuevafactura.factnumerofact = Convert.ToDecimal(labelNumeroFactura.Text);
                nuevafactura.factremesa = "Factura Directa " + labelNumeroFactura.Text;
                nuevafactura.factemleados = 0;
                nuevafactura.factprecioempleado = 0;
                nuevafactura.factpormail = false;
                nuevafactura.factmail = "";


                foreach (DataGridViewRow row in dataGridView1.Rows)

                {
                   
                            nuevafactura.factconcepto1 = Convert.ToString(row.Cells[3].Value); 
                            nuevafactura.factbase1 = Convert.ToDecimal (row.Cells[2].Value);
                  
                /*        if (dataGridView1.CurrentRow.Index.ToString() == "1")
                        {
                            nuevafactura.factconcepto2 = Convert.ToString(row.Cells[2]);
                        }
*/
                       

                   



                }

                    bd.Facturas.Add(nuevafactura);

                //guardamos los cambios
                bd.SaveChanges();
            }
        }



        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }

        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            textBox13.Text =  Convert.ToString(dataGridView2.CurrentRow.Cells[0].Value);
            dataGridView2.Visible = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {

            //**************************************************
            //***************************************************

            // nos aseguramos que se rellenen todos los datos

            if ((textBox1.Text=="")|| (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") ||
                    (textBox5.Text == "") || (textBox6.Text == "") )
            {
               MessageBox.Show("Debe completar los datos del cliente. ");

            }
            if (checkBox3.Checked == true)
            {
                if ((textBox7.Text == "") || (textBox8.Text == "") || (textBox9.Text == "") ||
                    (textBox10.Text == "") || (textBox11.Text == "") || (textBox12.Text == ""))
                {
                    MessageBox.Show("Debe rellenar los datos bancarios.");
                }
            }
            //******************************************************
            //******************************************************
            panel1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Rows.Count >= 4)
            {
                this.dataGridView1.AllowUserToAddRows = false;
                MessageBox.Show("El numero máximo de conceptos es tres.");
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            var busqueda = from c in bd.Clientes select c;
          //  busqueda = from c in bd.Clientes select c;
            busqueda = busqueda.OrderBy(c=> c.nombrecliente). Where(c => c.nombrecliente.Contains(textBox13.Text));
            dataGridView2.Visible = true;
            dataGridView2.DataSource = busqueda.ToList();
            



            //   comboBoxClientes.DataSource = busqueda.Select(x => x.nombrecliente).ToList<string>();

            if (busqueda.Count() == 0)
            {
                encontrado = false;
            }
            else
            {
                encontrado = true;
            }
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            // cuando sale del combo, si no ha encontrado el registro de clientes
            // pide que introduzcamos los datos.

            if (dataGridView2.RowCount == 0)
            {
                dataGridView2.Visible = false;
                panel1.Visible = true;
                textBox1.Text = textBox13.Text;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                clientenuevo = true;

            }
            else
            {
                panel1.Visible = false;
                clientenuevo = false;

            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox13.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[0].Value);
            dataGridView2.Visible = false;


        //    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void textBox13_Enter(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'administracionAntonioDataSet1.Iva' Puede moverla o quitarla según sea necesario.
            this.ivaTableAdapter.Fill(this.administracionAntonioDataSet1.Iva);
            //carga la tabla de clientes en el conbo
            dataGridView2.DataSource = bd.Clientes.ToList();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {



            //  creamos variables para los calculos y les damos valor
            decimal unidades, importe, total;
            // creamos la variable para acceder a la fila
            int fila;

            // realizamos esto si modificamos las unidades
            if ((dataGridView1.Columns[e.ColumnIndex].Name == "DataGridviewColumn1")||
                    (dataGridView1.Columns[e.ColumnIndex].Name == "DataGridviewColumn3")||
                    (dataGridView1.Columns[e.ColumnIndex].Name == "DataGridviewColumn4")||
                    (dataGridView1.Columns[e.ColumnIndex].Name == "Column6"))
            {
               fila = Convert.ToInt32(dataGridView1.CurrentRow.Index);
                // cargamos las variables con los datos del dgv
                unidades = Convert.ToDecimal(dataGridView1[2, fila].Value);
                importe = Convert.ToDecimal(dataGridView1[4, fila].Value);
                
                // realizamos lo scalculos
                total = unidades * importe;

                // cargamos los datos e el dgv
                dataGridView1[5, fila].Value = total;

            }



            // actualiza los totales.

            // recorre la tabla para actualizar los ivas

            base0 = 0; base4 = 0; base10 = 0; base21 = 0; basesupl = 0;


            foreach (DataGridViewRow row in dataGridView1.Rows)

            {
                string sup = Convert.ToString(row.Cells[1].Value);

                  if (sup == "True")
                {
                    basesupl = basesupl + Convert.ToDecimal(row.Cells[5].Value);
                }
                decimal tipo = Convert.ToDecimal(row.Cells[0].Value);
                if (tipo == 0)
                {
                    if (sup != "True")
                    {
                        base0 = base0 + Convert.ToDecimal(row.Cells[5].Value);
                    }
                
                }
                if (tipo == 4)
                {
                    if (sup != "True")
                    {
                        base4 = base4 + Convert.ToDecimal(row.Cells[5].Value);
                    }
                   
                }
                if (tipo == 10)
                {
                    if (sup != "True")
                    {
                        base10 = base10 + Convert.ToDecimal(row.Cells[5].Value);
                    }
                }
                if (tipo == 21)
                {
                    if (sup != "True")
                    {
                        base21 = base21 + Convert.ToDecimal(row.Cells[5].Value);
                    }
                }


                //muestras las bases y calcula los ivas

                bas1.Text = base0.ToString("C2");
                total1.Text = "0,00";

                bas2.Text = base4.ToString("C2");
                decimal x = (base4*4)/100;
                total2.Text = x.ToString("C2");

                bas3.Text = base10.ToString("C2");
                x = (base10 * 10) / 100;
                total3.Text = x.ToString("C2");

                bas4.Text = base21.ToString("C2");
                x = (base21 * 21) / 100;
                total4.Text = x.ToString("C2");

                //actualiza los totales de las facturas
                basenosujeta.Text = basesupl.ToString("C2");
                baseimponible.Text = (base0 + base4 + base10 + base21).ToString("C2");

                string a, b, c;
                a = total2.Text;
                a = a.Replace("€", "");
                b = total3.Text;
                b = b.Replace("€", "");
                c = total4.Text;
                c = c.Replace("€", "");
                
                x = Convert.ToDecimal(a)+ Convert.ToDecimal(b)+ Convert.ToDecimal(c);



                totaliva.Text = (x).ToString("C2");
                totalfactura.Text = (basesupl + (base0 + base4 + base10 + base21) + (x)).ToString("C2");
                



            }




        }


        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {  // Donde el numero "0" es el numero de tu columna 

            if ((dataGridView1.CurrentCell.ColumnIndex == 2)||
                    (dataGridView1.CurrentCell.ColumnIndex == 4))

            {

                if (e.KeyChar == (char)Keys.Back || char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Escape)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }


                if (e.KeyChar == (char)44 | e.KeyChar == (char)46) // Si es un . o una ,
                {

                    // Si no hay caracteres
                    // o
                    // Si ya hay un punto o una coma
                    // no dejamos poner la , o .

                    e.Handled = false;
                }

                if (e.KeyChar == (char)43 | e.KeyChar == (char)45)
                // Si es un + o un -
                {
                    e.Handled = false;
                }
            
                if (e.KeyChar == (char)46)
                {
                    e.KeyChar = (char) 44;
                }



            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                TextBox txt = e.Control as TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);

                    txt.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }
        }

    }

    }
