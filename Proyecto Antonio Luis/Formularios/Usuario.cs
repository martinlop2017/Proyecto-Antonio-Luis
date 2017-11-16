﻿using System;
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
                // muestra los datos del registro seleccionado.
                try
                {
                    //busca en la tabla la fila con el registro suminstrado
                    //y si lo carga los datos en el formulario

                    var amodificar = bd.Ususarios.SingleOrDefault(codusuario => codusuario.cod == Globales.modificar);
                    if (amodificar != null)
                    {
                        label1.Text = Convert.ToString(amodificar.cod);
                        textBox1.Text = amodificar.nombre;
                        maskedTextBox1.Text = amodificar.login;
                        maskedTextBox2.Text = amodificar.login;
                        textBox2.Text = amodificar.pregunta;
                        textBox3.Text = amodificar.respuesta;
                        comboBox1.Text = amodificar.grupo;
                        if (Convert.ToBoolean(amodificar.activo) == true)

                        {
                            radioButton1.Checked = true;
                        }
                        else
                        {
                            radioButton2.Checked = true;
                        }



                        if (amodificar.sistema == true)
                        {
                            arbol.Nodes[0].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[0].Checked = false;
                        }
                        if (amodificar.misdatos == true)
                        {
                            arbol.Nodes[0].Nodes[0].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[0].Nodes[1].Checked = false;
                        }
                        if (amodificar.usuarios == true)
                        {
                            arbol.Nodes[0].Nodes[1].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[0].Nodes[1].Checked = false;
                        }
                        if (amodificar.gusuarios == true)
                        {
                            arbol.Nodes[0].Nodes[1].Nodes[0].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[0].Nodes[1].Nodes[0].Checked = false;
                        }
                        if (amodificar.impuestos == true)
                        {
                            arbol.Nodes[0].Nodes[2].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[0].Nodes[2].Checked = false;
                        }



                        if (amodificar.clientes == true)
                        {
                            arbol.Nodes[1].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[1].Checked = false;
                        }
                        if (amodificar.gclientes == true)
                        {
                            arbol.Nodes[1].Nodes[0].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[1].Nodes[0].Checked = false;

                        }


                        if (amodificar.articulos == true)
                        {
                            arbol.Nodes[2].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[2].Checked = false;
                        }
                        if (amodificar.garticulos == true)
                        {
                            arbol.Nodes[2].Nodes[0].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[2].Nodes[0].Checked = false;
                        }


                        if (amodificar.albaranes == true)
                        {
                            arbol.Nodes[3].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[3].Checked = false;
                        }
                        if (amodificar.galbaranes == true)
                        {
                            arbol.Nodes[3].Nodes[0].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[3].Nodes[0].Checked = false;
                        }


                        if (amodificar.facturas == true)
                        {
                            arbol.Nodes[4].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[4].Checked = false;
                        }
                        if (amodificar.gfacturas == true)
                        {
                            arbol.Nodes[4].Nodes[0].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[4].Nodes[0].Checked = false;
                        }


                        if (amodificar.csb19 == true)
                        {
                            arbol.Nodes[5].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[5].Checked = false;
                        }


                        if (amodificar.contaplus == true)
                        {
                            arbol.Nodes[6].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[6].Checked = false;
                        }

                        if (amodificar.listados == true)
                        {
                            arbol.Nodes[7].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[7].Checked = false;
                        }


                        if (amodificar.copiaseguridad == true)
                        {
                            arbol.Nodes[8].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[8].Checked = false;
                        }

                        if (amodificar.agenda == true)
                        {
                            arbol.Nodes[9].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[9].Checked = true;
                        }


                        if (amodificar.avisos == true)
                        {
                            arbol.Nodes[10].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[10].Checked = false;
                        }

                        if (amodificar.gavisos == true)
                        {
                            arbol.Nodes[10].Nodes[0].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[10].Nodes[0].Checked = false;

                        }


                        if (amodificar.agenda == true)
                        {
                            arbol.Nodes[9].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[9].Checked = false;
                        }

                        if (amodificar.avisos == true)
                        {
                            arbol.Nodes[10].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[10].Checked = false;
                        }
                        if (amodificar.gavisos == true)
                        {
                            arbol.Nodes[10].Nodes[0].Checked = true;
                        }
                        else
                        {
                            arbol.Nodes[10].Nodes[0].Checked = false;
                        }

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No ha sido posible cargar los datos", "Error 202");

                }
            }



            if (Globales.llamadas == "1")
            {
                //**** calculamos el valor de la coluna numerador
                var ultimocod = bd.Ususarios.OrderByDescending(x => x.cod).First().cod;
                label1.Text = Convert.ToString(ultimocod+1);
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
                        nuevoUsuario.agenda = true;
                    }

                    if (arbol.Nodes[10].Checked == true)
                    {
                        nuevoUsuario.avisos = true;
                    }
                    if (arbol.Nodes[10].Nodes[0].Checked == true)
                    {
                        nuevoUsuario.gavisos = true;
                    }


                    bd.Ususarios.Add(nuevoUsuario);

                    //guardamos los cambios
                    bd.SaveChanges();



                }
                catch (Exception)
                {
                    MessageBox.Show("No ha sido posible grabar los datos", "Error 101");
                }

            }


            if (Globales.llamadas == "2")
            {


                try
                {
                    
                    //extraemos los datos correspondientes de la tabla en el objeto
                    var usuarioAmodificar = bd.Ususarios.SingleOrDefault(codusuario => codusuario.cod == Globales.modificar);

                    //modificamos los valores

                    usuarioAmodificar.nombre = textBox1.Text;
                    usuarioAmodificar.login = maskedTextBox1.Text;
                      usuarioAmodificar.pregunta = textBox2.Text;
                    usuarioAmodificar.respuesta = textBox3.Text;
                    usuarioAmodificar.grupo = comboBox1.Text;


                    if (radioButton1.Checked == true)
                    {
                        usuarioAmodificar.activo = "true";
                    }
                    else
                    {
                        usuarioAmodificar.activo = "false";
                    }

                  
                    if (arbol.Nodes[0].Checked == true)
                    {
                        usuarioAmodificar.sistema = true;
                    }
                    if (arbol.Nodes[0].Nodes[0].Checked == true)
                    {
                        usuarioAmodificar.misdatos = true;
                    }
                    if (arbol.Nodes[0].Nodes[1].Checked == true)
                    {
                        usuarioAmodificar.usuarios = true;
                    }
                    if (arbol.Nodes[0].Nodes[1].Nodes[0].Checked == true)
                    {
                        usuarioAmodificar.gusuarios = true;
                    }
                    if (arbol.Nodes[0].Nodes[2].Checked == true)
                    {
                        usuarioAmodificar.impuestos = true;
                    }



                    if (arbol.Nodes[1].Checked == true)
                    {
                        usuarioAmodificar.clientes = true;
                    }
                    if (arbol.Nodes[1].Nodes[0].Checked == true)
                    {
                        usuarioAmodificar.gclientes = true;
                    }


                    if (arbol.Nodes[2].Checked == true)
                    {
                        usuarioAmodificar.articulos = true;
                    }
                    if (arbol.Nodes[2].Nodes[0].Checked == true)
                    {
                        usuarioAmodificar.garticulos = true;
                    }


                    if (arbol.Nodes[3].Checked == true)
                    {
                        usuarioAmodificar.albaranes = true;
                    }
                    if (arbol.Nodes[3].Nodes[0].Checked == true)
                    {
                        usuarioAmodificar.galbaranes = true;
                    }


                    if (arbol.Nodes[4].Checked == true)
                    {
                        usuarioAmodificar.facturas = true;
                    }
                    if (arbol.Nodes[4].Nodes[0].Checked == true)
                    {
                        usuarioAmodificar.gfacturas = true;
                    }


                    if (arbol.Nodes[5].Checked == true)
                    {
                        usuarioAmodificar.csb19 = true;
                    }


                    if (arbol.Nodes[6].Checked == true)
                    {
                        usuarioAmodificar.contaplus = true;
                    }


                    if (arbol.Nodes[7].Checked == true)
                    {
                        usuarioAmodificar.listados = true;
                    }


                    if (arbol.Nodes[8].Checked == true)
                    {
                        usuarioAmodificar.copiaseguridad = true;
                    }


                    if (arbol.Nodes[9].Checked == true)
                    {
                        usuarioAmodificar.agenda = true;
                    }

                    if (arbol.Nodes[10].Checked == true)
                    {
                        usuarioAmodificar.avisos = true;
                    }
                    if (arbol.Nodes[10].Nodes[0].Checked == true)
                    {
                        usuarioAmodificar.gavisos = true;
                    }

                    //guardamos los cambios
                    bd.SaveChanges();


                }
                catch (Exception)
                {
                    MessageBox.Show("No ha sido posible grabar los datos", "Error 102");
                }

            }
            Close();
        }
        private void Usuario_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            maskedTextBox1.UseSystemPasswordChar = false;
            maskedTextBox2.UseSystemPasswordChar = false;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            maskedTextBox1.UseSystemPasswordChar = true;
            maskedTextBox2.UseSystemPasswordChar = true;
        }
    }
}
