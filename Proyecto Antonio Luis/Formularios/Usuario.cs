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
    public partial class Usuario : Form
    {
        AdministracionAntonioEntities bd;

        public Usuario()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            if (Globales.llamadas == "2")
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Globales.llamadas == "1")
            {


                try
                {
                    //**** calculamos el valor de la coluna numerador
                    var ultimocod = bd.Ususarios.OrderByDescending(x => x.cod).First().cod;
                    
                    //****GRABA LOS DATOS EN LA TABLA
                    var nuevoUsuario = new Ususarios();

                    nuevoUsuario.cod = ultimocod + 1;
                    nuevoUsuario.nombre = textBox1.Text;
                    nuevoUsuario.login = maskedTextBox1.Text;
                    if (radioButton1.Checked == true)
                    {
                        nuevoUsuario.activo = "true";
                    }
                    else
                    {
                        nuevoUsuario.activo = "false";
                    }
                    nuevoUsuario.grupo = comboBox1.Text;
                    nuevoUsuario.pregunta = textBox2.Text;
                    nuevoUsuario.respuesta = textBox3.Text;
                    if (arbol.Nodes[0].Checked == true)
                    {
                        nuevoUsuario.sistema = true;
                    }
                    if (arbol.Nodes[0].Nodes[0].Checked == true)
                    {
                        nuevoUsuario.misdatos = true;
                    }
                    if (arbol.Nodes[0].Nodes[1].Checked == true)
                    {
                        nuevoUsuario.usuarios = true;
                    }
                    if (arbol.Nodes[0].Nodes[1].Nodes[0].Checked == true)
                    {
                        nuevoUsuario.gusuarios = true;
                    }
                       if (arbol.Nodes[0].Nodes[2].Checked == true)
                    {
                        nuevoUsuario.impuestos = true;
                    }



                    if (arbol.Nodes[1].Checked == true)
                    {
                        nuevoUsuario.clientes = true;
                    }
                    if (arbol.Nodes[1].Nodes[0].Checked == true)
                    {
                        nuevoUsuario.gclientes = true;
                    }


                    if (arbol.Nodes[2].Checked == true)
                    {
                        nuevoUsuario.articulos = true;
                    }
                    if (arbol.Nodes[2].Nodes[0].Checked == true)
                    {
                        nuevoUsuario.garticulos = true;
                    }


                    if (arbol.Nodes[3].Checked == true)
                    {
                        nuevoUsuario.albaranes = true;
                    }
                    if (arbol.Nodes[3].Nodes[0].Checked == true)
                    {
                        nuevoUsuario.galbaranes = true;
                    }


                    if (arbol.Nodes[4].Checked == true)
                    {
                        nuevoUsuario.facturas = true;
                    }
                    if (arbol.Nodes[4].Nodes[0].Checked == true)
                    {
                        nuevoUsuario.gfacturas = true;
                    }


                    if (arbol.Nodes[5].Checked == true)
                    {
                        nuevoUsuario.csb19 = true;
                    }


                    if (arbol.Nodes[6].Checked == true)
                    {
                        nuevoUsuario.contaplus = true;
                    }


                    if (arbol.Nodes[7].Checked == true)
                    {
                        nuevoUsuario.listados = true;
                    }


                    if (arbol.Nodes[8].Checked == true)
                    {
                        nuevoUsuario.copiaseguridad = true;
                    }


                    if (arbol.Nodes[9].Checked == true)
                    {
                        nuevoUsuario.agenda= true;
                    }

    
                    bd.Ususarios.Add(nuevoUsuario);

                    //guardamos los cambios
                    bd.SaveChanges();

                }
                catch (Exception exp)
                {
                    MessageBox.Show ("no funciona");
                }



            }
        }
    }
}
