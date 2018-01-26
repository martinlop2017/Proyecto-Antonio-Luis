
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
using System.Data.SqlClient;
//using Administracion_Antonio_Luis.Utils.Iva;




namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class Cliente : Form
    {

        AdministracionAntonioEntities bd;
        
        public Cliente()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            //si se llama desde añadir calcula automaticamnete el codigo
            if (Globales.llamadas == "1")
            {
                //calcula y muestra el codigo de cliente automaticamente
                var autocod = bd.Clientes.OrderByDescending(x => x.codcliente).Take(1).FirstOrDefault();
                if (autocod != null)
                {
                    int numero = Convert.ToInt16 ( autocod.codcliente + 1);
                    label1.Text = numero.ToString();
                }
                else
                {
                    label1.Text = "1";
                }
                
            }


            //si es llamada desde modificar carga los datos

                if (Globales.llamadas == "2")
            {
                // muestra los datos del registro seleccionado.
                try
                {
                    //busca en la tabla la fila con el registro suminstrado
                    //y si lo carga los datos en el formulario

                    var mostrar = bd.Clientes.SingleOrDefault(codcliente => codcliente.numerador == Globales.modificar);
                    if (mostrar != null)
                    {
                        label1.Text = mostrar.codcliente.ToString();
                        textMiNombre.Text = mostrar.nombrecliente;
                        textMiCif.Text = mostrar.cifcliente;
                        textMiDiereccion.Text = mostrar.direcioncliente;
                        textMiPoblacion.Text = mostrar.localidacliente;
                        textMiProvincia.Text = mostrar.provinciacliente;
                        textMiCP.Text = mostrar.cod_postalcliente;
                        textMiTLF1.Text = mostrar.telefono1cliente.ToString();
                        textMiTLF2.Text = mostrar.telefono2cliente.ToString();
                        textMiFax.Text = mostrar.faxcliente.ToString();
                        textMiPersonaContacto.Text = mostrar.contactocliente;
                        textMiMail.Text = mostrar.mailcliente;
                        if(mostrar.activocliente == true)
                        {
                            checActivo.Checked = true;
                        }
                        if (mostrar.domiciliadocliente == true)
                        {
                            checDomiciliacion.Checked = true;
                        }
                        if (mostrar.recargo == true)
                        {
                            checRE.Checked = true;
                        }
                        if (mostrar.contabilizarcliente == true)
                        {
                            checContabilizar.Checked = true;
                        }
                        if(mostrar.pormailcliente == true)
                        {
                            checpormail.Checked = true;
                        }
                        textCCC1.Text = mostrar.iban1cliente.ToString();
                        textCCC2.Text = mostrar.iban2cliente.ToString();
                        textCCC3.Text = mostrar.iban3cliente.ToString();
                        textCCC4.Text = mostrar.iban4cliente.ToString();
                        textCCC5.Text = mostrar.iban5cliente.ToString();
                        textCCC6.Text = mostrar.iban6cliente.ToString();
                        comboGrupo.Text = mostrar.grupocliente;
                        textTrabajadores.Text = mostrar.empleadoscliente.ToString();
                        textFechaAlta.Text = mostrar.fechaaltacliente.ToString();
                        textPreciotrabajador.Text = mostrar.precioempleadocliente.ToString();
                        textTarifa.Text = mostrar.tarifacliente.ToString();
                        if (mostrar.mod100 == true)
                        {
                            chec100.Checked = true;
                        }
                        if (mostrar.mod111 == true)
                        {
                            chec111.Checked = true;
                        }
                        if (mostrar.mod115 == true)
                        {
                            chec115.Checked = true;
                        }
                        if (mostrar.mod123 == true)
                        {
                            chec123.Checked = true;
                        }
                        if (mostrar.mod130 == true)
                        {
                            chec130.Checked = true;
                        }
                        if (mostrar.mod131 == true)
                        {
                            chec131.Checked = true;
                        }
                        if (mostrar.mod180 == true)
                        {
                            chec180.Checked = true;
                        }
                        if (mostrar.mod190 == true)
                        {
                            chec190.Checked = true;
                        }
                        if (mostrar.mod193 == true)
                        {
                            chec193.Checked = true;
                        }
                        if (mostrar.mod200 == true)
                        {
                            chec200.Checked = true;
                        }
                        if (mostrar.mod202 == true)
                        {
                            chec202.Checked = true;
                        }
                        if (mostrar.mod303 == true)
                        {
                            chec303.Checked = true;
                        }
                        if (mostrar.mod309 == true)
                        {
                            chec309.Checked = true;
                        }
                        if (mostrar.mod349 == true)
                        {
                            chec349.Checked = true;
                        }
                        if (mostrar.mod390 == true)
                        {
                            chec390.Checked = true;
                        }
                        if (mostrar.mod751 == true)
                        {
                            chec751.Checked = true;
                        }
                        if (mostrar.mod752 == true)
                        {
                            chec752.Checked = true;
                        }
                        if (mostrar.instrastatcliente == true)
                        {
                            checIntrastat.Checked = true;
                        }
                        textObserva.Text = mostrar.comentariocliente;


                    }
                }
                catch (Exception)
                {


                }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Globales.llamadas == "1")
            {
                try
                {
                    var nuevocliente = new Clientes();

                    //calcula y muestra el codigo de cliente automaticamente
                    var autokey = bd.Clientes.OrderByDescending(x => x.numerador).Take(1).FirstOrDefault();
                    if(autokey==null)
                    {
                        nuevocliente.numerador = 1;
                    }
                    else
                    {
                        nuevocliente.numerador = autokey.numerador + 1;
                    }
                    

                    nuevocliente.codcliente = Convert.ToDecimal(label1.Text);
                    nuevocliente.nombrecliente = textMiNombre.Text;
                    nuevocliente.cifcliente = textMiCif.Text;
                    nuevocliente.direcioncliente = textMiDiereccion.Text;
                    nuevocliente.localidacliente = textMiPoblacion.Text;
                    nuevocliente.provinciacliente = textMiProvincia.Text;
                    nuevocliente.cod_postalcliente = textMiCP.Text;
                    nuevocliente.telefono1cliente = Convert.ToInt64(textMiTLF1.Text);
                    nuevocliente.telefono2cliente = Convert.ToInt64(textMiTLF2.Text);
                    nuevocliente.faxcliente = Convert.ToInt64(textMiFax.Text);
                    nuevocliente.contactocliente = textMiPersonaContacto.Text;
                    nuevocliente.mailcliente = textMiMail.Text;
                    nuevocliente.grupocliente = comboGrupo.Text;
                    nuevocliente.empleadoscliente = Convert.ToInt64(textTrabajadores.Text);
                    nuevocliente.fechaaltacliente = Convert.ToDateTime(textFechaAlta.Text);
                    nuevocliente.precioempleadocliente = Convert.ToDecimal(textPreciotrabajador.Text);
                    
                    nuevocliente.tarifacliente = Convert.ToDecimal(textTarifa.Text);
                    if (checActivo.Checked == true)
                    {
                        nuevocliente.activocliente = true;
                    }
                    else
                    {
                        nuevocliente.activocliente = false;
                    }
                    if (checDomiciliacion.Checked == true)
                    {
                        nuevocliente.domiciliadocliente = true;
                    }
                    else
                    {
                        nuevocliente.domiciliadocliente = false;
                    }
                    if (checRE.Checked == true)
                    {
                        nuevocliente.recargo = true;
                    }
                    else
                    {
                        nuevocliente.recargo = false;
                    }
                    if (checContabilizar.Checked == true)
                    {
                        nuevocliente.contabilizarcliente = true;
                    }
                    else
                    {
                        nuevocliente.contabilizarcliente = false;
                    }

                    if (checpormail.Checked == true)
                    {
                        nuevocliente.pormailcliente = true;
                    }
                    else
                    {
                        nuevocliente.pormailcliente = false;
                    }
                    nuevocliente.iban1cliente = textCCC1.Text;
                    nuevocliente.iban2cliente = Convert.ToInt64(textCCC2.Text);
                    nuevocliente.iban3cliente = Convert.ToInt64(textCCC3.Text);
                    nuevocliente.iban4cliente = Convert.ToInt64(textCCC4.Text);
                    nuevocliente.iban5cliente = Convert.ToInt64(textCCC5.Text);
                    nuevocliente.iban6cliente = Convert.ToInt64(textCCC6.Text);


                    if (chec100.Checked == true)
                    {
                        nuevocliente.mod100 = true;
                    }
                    else
                    {
                        nuevocliente.mod100 = false;
                    }
                    if (chec111.Checked == true)
                    {
                        nuevocliente.mod111 = true;
                    }
                    else
                    {
                        nuevocliente.mod111 = false;
                    }
                    if (chec115.Checked == true)
                    {
                        nuevocliente.mod115 = true;
                    }
                    else
                    {
                        nuevocliente.mod115 = false;
                    }
                    if (chec123.Checked == true)
                    {
                        nuevocliente.mod123 = true;
                    }
                    else
                    {
                        nuevocliente.mod123 = false;
                    }
                    if (chec130.Checked == true)
                    {
                        nuevocliente.mod130 = true;
                    }
                    else
                    {
                        nuevocliente.mod130 = false;
                    }
                    if (chec131.Checked == true)
                    {
                        nuevocliente.mod131 = true;
                    }
                    else
                    {
                        nuevocliente.mod131 = false;
                    }
                    if (chec180.Checked == true)
                    {
                        nuevocliente.mod180 = true;
                    }
                    else
                    {
                        nuevocliente.mod180 = false;
                    }
                    if (chec190.Checked == true)
                    {
                        nuevocliente.mod190 = true;
                    }
                    else
                    {
                        nuevocliente.mod190 = false;
                    }
                    if (chec193.Checked == true)
                    {
                        nuevocliente.mod193 = true;
                    }
                    else
                    {
                        nuevocliente.mod193 = false;
                    }
                    if (chec200.Checked == true)
                    {
                        nuevocliente.mod200 = true;
                    }
                    else
                    {
                        nuevocliente.mod200 = false;
                    }
                    if (chec202.Checked == true)
                    {
                        nuevocliente.mod202 = true;
                    }
                    else
                    {
                        nuevocliente.mod202 = false;
                    }
                    if (chec303.Checked == true)
                    {
                        nuevocliente.mod303 = true;
                    }
                    else
                    {
                        nuevocliente.mod303 = false;
                    }
                    if (chec309.Checked == true)
                    {
                        nuevocliente.mod309 = true;
                    }
                    else
                    {
                        nuevocliente.mod309 = false;
                    }
                    if (chec349.Checked == true)
                    {
                        nuevocliente.mod349 = true;
                    }
                    else
                    {
                        nuevocliente.mod349 = false;
                    }
                    if (chec390.Checked == true)
                    {
                        nuevocliente.mod390 = true;
                    }
                    else
                    {
                        nuevocliente.mod390 = false;
                    }
                    if (chec751.Checked == true)
                    {
                        nuevocliente.mod751 = true;
                    }
                    else
                    {
                        nuevocliente.mod751 = false;
                    }
                    if (chec752.Checked == true)
                    {
                        nuevocliente.mod752 = true;
                    }
                    else
                    {
                        nuevocliente.mod752 = false;
                    }
                    if (checIntrastat.Checked == true)
                    {
                        nuevocliente.instrastatcliente = true;
                    }
                    else
                    {
                        nuevocliente.instrastatcliente = false;
                    }
                    nuevocliente.comentariocliente = textObserva.Text;

                    bd.Clientes.Add(nuevocliente);

                    //guardamos los cambios
                    bd.SaveChanges();
                    

                }
                catch
                {
                    MessageBox.Show("No ha sido posible grabar los datos", "Error 101", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            /// si see llama de modificar

            if (Globales.llamadas == "2")
            {
                try
                {
                    //busca en la tabla la fila con el registro suminstrado
                    //y si lo carga los datos en el formulario

                    var amodificar = bd.Clientes.SingleOrDefault(x => x.numerador == Globales.modificar);
                    if (amodificar != null)
                    {
                        amodificar.nombrecliente = textMiNombre.Text;
                        amodificar.cifcliente = textMiCif.Text;
                        amodificar.direcioncliente = textMiDiereccion.Text;
                        amodificar.localidacliente = textMiPoblacion.Text;
                        amodificar.provinciacliente = textMiProvincia.Text;
                        amodificar.cod_postalcliente = textMiCP.Text;
                        amodificar.telefono1cliente = Convert.ToInt64(textMiTLF1.Text);
                        amodificar.telefono2cliente = Convert.ToInt64(textMiTLF2.Text);
                        amodificar.faxcliente = Convert.ToInt64(textMiFax.Text);
                        amodificar.contactocliente = textMiPersonaContacto.Text;
                        amodificar.mailcliente = textMiMail.Text;
                        amodificar.grupocliente = comboGrupo.Text;
                        amodificar.empleadoscliente = Convert.ToInt64(textTrabajadores.Text);
                        amodificar.fechaaltacliente = Convert.ToDateTime(textFechaAlta.Text);
                        amodificar.precioempleadocliente = Convert.ToDecimal(textPreciotrabajador.Text);
                        amodificar.tarifacliente = Convert.ToDecimal(textTarifa.Text);
                        if (checActivo.Checked == true)
                        {
                            amodificar.activocliente = true;
                        }
                        else
                        {
                            amodificar.activocliente = false;
                        }
                        if (checDomiciliacion.Checked == true)
                        {
                            amodificar.domiciliadocliente = true;
                        }
                        else
                        {
                            amodificar.domiciliadocliente = false;
                        }
                        if (checRE.Checked == true)
                        {
                            amodificar.recargo = true;
                        }
                        else
                        {
                            amodificar.recargo = false;
                        }
                        if (checContabilizar.Checked == true)
                        {
                            amodificar.contabilizarcliente = true;
                        }
                        else
                        {
                            amodificar.contabilizarcliente = false;
                        }
                        if (checpormail.Checked == true)
                        {
                            amodificar.pormailcliente = true;
                        }
                        else
                        {
                            amodificar.pormailcliente = false;
                        }
                        amodificar.iban1cliente = textCCC1.Text;
                        amodificar.iban2cliente = Convert.ToInt64(textCCC2.Text);
                        amodificar.iban3cliente = Convert.ToInt64(textCCC3.Text);
                        amodificar.iban4cliente = Convert.ToInt64(textCCC4.Text);
                        amodificar.iban5cliente = Convert.ToInt64(textCCC5.Text);
                        amodificar.iban6cliente = Convert.ToInt64(textCCC6.Text);


                        if (chec100.Checked == true)
                        {
                            amodificar.mod100 = true;
                        }
                        else
                        {
                            amodificar.mod100 = false;
                        }
                        if (chec111.Checked == true)
                        {
                            amodificar.mod111 = true;
                        }
                        else
                        {
                            amodificar.mod111 = false;
                        }
                        if (chec115.Checked == true)
                        {
                            amodificar.mod115 = true;
                        }
                        else
                        {
                            amodificar.mod115 = false;
                        }
                        if (chec123.Checked == true)
                        {
                            amodificar.mod123 = true;
                        }
                        else
                        {
                            amodificar.mod123 = false;
                        }
                        if (chec130.Checked == true)
                        {
                            amodificar.mod130 = true;
                        }
                        else
                        {
                            amodificar.mod130 = false;
                        }
                        if (chec131.Checked == true)
                        {
                            amodificar.mod131 = true;
                        }
                        else
                        {
                            amodificar.mod131 = false;
                        }                  
                        if (chec180.Checked == true)
                        {
                            amodificar.mod180 = true;
                        }
                        else
                        {
                            amodificar.mod180 = false;
                        }
                        if (chec190.Checked == true)
                        {
                            amodificar.mod190 = true;
                        }
                        else
                        {
                            amodificar.mod190 = false;
                        }
                        if (chec193.Checked == true)
                        {
                            amodificar.mod193 = true;
                        }
                        else
                        {
                            amodificar.mod193 = false;
                        }
                        if (chec200.Checked == true)
                        {
                            amodificar.mod200 = true;
                        }
                        else
                        {
                            amodificar.mod200 = false;
                        }
                        if (chec202.Checked == true)
                        {
                            amodificar.mod202 = true;
                        }
                        else
                        {
                            amodificar.mod202 = false;
                        }
                        if (chec303.Checked == true)
                        {
                            amodificar.mod303 = true;
                        }
                        else
                        {
                            amodificar.mod303 = false;
                        }
                        if (chec309.Checked == true)
                        {
                            amodificar.mod309 = true;
                        }
                        else
                        {
                            amodificar.mod309 = false;
                        }
                        if (chec349.Checked == true)
                        {
                            amodificar.mod349 = true;
                        }
                        else
                        {
                            amodificar.mod349 = false;
                        }
                        if (chec390.Checked == true)
                        {
                            amodificar.mod390 = true;
                        }
                        else
                        {
                            amodificar.mod390 = false;
                        }
                        if (chec751.Checked == true)
                        {
                            amodificar.mod751 = true;
                        }
                        else
                        {
                            amodificar.mod751 = false;
                        }
                        if (chec752.Checked == true)
                        {
                            amodificar.mod752 = true;
                        }
                        else
                        {
                            amodificar.mod752 = false;
                        }
                        if (checIntrastat.Checked == true)
                        {
                            amodificar.instrastatcliente = true;
                        }
                        else
                        {
                            amodificar.instrastatcliente = false;
                        }
                        amodificar.comentariocliente = textObserva.Text;

                        //graba los datos
                        bd.SaveChanges();
                    }



                }
                catch
                {
                    MessageBox.Show("No ha sido posible grabar los datos", "Error 101", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

           
        }

        private void button5_Click(object sender, EventArgs e)
        {

            var autocod = bd.Clientes.OrderByDescending(x => x.codcliente).Take(1).FirstOrDefault();

            textMiNombre.Text = autocod.codcliente.ToString();
        }

        private void textMiTLF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // evita caracteres que no sean numericos

           if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }



        }

        private void textMiTLF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // evita caracteres que no sean numericos

            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textMiFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            // evita caracteres que no sean numericos

            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textTrabajadores_KeyPress(object sender, KeyPressEventArgs e)
        {
            // evita caracteres que no sean numericos

            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textCCC6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // evita caracteres que no sean numericos

            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textCCC5_TextChanged(object sender, EventArgs e)
        {




        }

        private void textCCC5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // evita caracteres que no sean numericos

            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textCCC4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // evita caracteres que no sean numericos

            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textCCC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // evita caracteres que no sean numericos

            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textCCC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // evita caracteres que no sean numericos

            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textTarifa_KeyPress(object sender, KeyPressEventArgs e)
        {

            // CAMBIA EL PUNTO POR LA COMA
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // EVITA QUE PODAMOS INTRODUCIR NADA QUE NO SEA NUMEREO Y PUNTUACION
            if ((!Char.IsDigit(e.KeyChar))&&(!Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void Cliente_MouseEnter(object sender, EventArgs e)
        {

        }

        private void textTarifa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
