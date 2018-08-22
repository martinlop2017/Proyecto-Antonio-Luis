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
    public partial class MenuPrincipal : Form
    {
        AdministracionAntonioEntities bd;

        public MenuPrincipal()
        {
            bd = new AdministracionAntonioEntities();
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            //Al Iniciar Carga la fecha y la hora

            FechaInicio.Text = "    Fecha : " + DateTime.Now.ToString("dd/MM/yyyy") + "   -   Hora: " + DateTime.Now.ToLongTimeString() + "  ";
            timer1.Start();

            //FILTRAMOS PARA MOSTRAR LOS BOTONES DE ACCESO.
            var candado = bd.Ususarios.Where(x => x.nombre == Globales.llamadas && x.activo == true);

            if (Globales.llamadas != "citroenc5")
            {

                if (candado.First().sistema == false)
                {
                    BotonSistema.Enabled = false;
                    BotonSistema.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Sistema_Apagado;
                }
                if (candado.First().misdatos == false)
                {
                    BotonPropios.Enabled = false;
                    BotonPropios.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Propios_Apagado;
                }
                if (candado.First().usuarios == false)
                {
                    BotonUsuarios.Enabled = false;
                    BotonUsuarios.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Ususarios_Apagado;
                }
                if (candado.First().impuestos == false)
                {
                    BotonImpuestos.Enabled = false;
                    BotonImpuestos.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Impuetos_Apagado;
                }
                if (candado.First().rutas == false)
                {
                    BotonRutas.Enabled = false;
                    BotonRutas.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Ruta_Apagado;
                }



                if (candado.First().clientes == false)
                {
                    BotonClientes.Enabled = false;
                    BotonClientes.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Clientes_Apagado;
                }
                if (candado.First().gclientes == false)
                {
                    BotonCliente.Enabled = false;
                    BotonCliente.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Clientes_Apagado1;
                }
                if (candado.First().Escaner == false)
                {
                    BotonEscaner.Enabled = false;
                    BotonEscaner.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Escaner_Apagado;
                }



                if (candado.First().facturas == false)
                {
                    BotonFacturas.Enabled = false;
                    BotonFacturas.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Facturas_Apagado;
                }
                if (candado.First().fmensual == false)
                {
                    BotonFactMensual.Enabled = false;
                    BotonFactMensual.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.FacturaMensual_Apagado;
                }
                if (candado.First().Escaner == false)
                {
                    BotonFactManual.Enabled = false;
                    BotonFactManual.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.FacturaManua_Apagadol;
                }


            }













        }

        private void timer1_Tick(object sender, EventArgs e)
        {   // actualiza la fecha y la hora cada segundo
            FechaInicio.Text = "    Fecha : " + DateTime.Now.ToString("dd/MM/yyyy") + "   -   Hora: " + DateTime.Now.ToLongTimeString() + "  ";
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

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            BotonSistema.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Sistema_Azul;
           
        }

        private void BotonSistema_MouseLeave(object sender, EventArgs e)
        {
            BotonSistema.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Sistema;
        }

        private void BotonClientes_MouseEnter(object sender, EventArgs e)
        {
            BotonClientes.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Clientes_Azul;
        }

        private void BotonClientes_MouseLeave(object sender, EventArgs e)
        {
            BotonClientes.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Clientes;
        }

        private void BotonFacturas_MouseEnter(object sender, EventArgs e)
        {
            BotonFacturas.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Facturas_Azul;
        }

        private void BotonFacturas_MouseLeave(object sender, EventArgs e)
        {
            BotonFacturas.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Facturas;
        }

        private void BotonCsb19_MouseEnter(object sender, EventArgs e)
        {
            BotonCsb19.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.CSB19_Azul;
        }

        private void BotonCsb19_MouseLeave(object sender, EventArgs e)
        {
            BotonCsb19.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.CSB19;
        }

        private void BotonContaplus_MouseEnter(object sender, EventArgs e)
        {
            BotonContaplus.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Contaplus_Azul;
        }

        private void BotonContaplus_MouseLeave(object sender, EventArgs e)
        {
            BotonContaplus.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Contaplus;
        }

        private void BotonListados_MouseEnter(object sender, EventArgs e)
        {
            BotonListados.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Listados_Azul;
        }

        private void BotonListados_MouseLeave(object sender, EventArgs e)
        {
            BotonListados.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Listados;
        }

        private void BotonMantenimiento_MouseEnter(object sender, EventArgs e)
        {
            BotonMantenimiento.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Mantenimiento_Azul;
        }

        private void BotonMantenimiento_MouseLeave(object sender, EventArgs e)
        {
            BotonMantenimiento.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Mantenimiento;
        }

        private void BotonAgenda_MouseEnter(object sender, EventArgs e)
        {
            BotonAgenda.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Agenda_Azul;
        }

        private void BotonAgenda_MouseLeave(object sender, EventArgs e)
        {
            BotonAgenda.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Agenda;
        }

        private void BotonAyuda_MouseEnter(object sender, EventArgs e)
        {
            BotonAyuda.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Ayuda_Azul;
        }

        private void BotonAyuda_MouseLeave(object sender, EventArgs e)
        {
            BotonAyuda.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Ayuda;
        }

        private void BotonPropios_MouseEnter(object sender, EventArgs e)
        {
            BotonPropios.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Propios_Azul;
        }

        private void BotonPropios_MouseLeave(object sender, EventArgs e)
        {
            BotonPropios.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Propios;
        }

        private void BotonImpuestos_MouseEnter(object sender, EventArgs e)
        {
            BotonImpuestos.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Impuetos_Azul;
        }

        private void BotonImpuestos_MouseLeave(object sender, EventArgs e)
        {
            BotonImpuestos.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Impuetos;
        }

        private void BotonRutas_MouseEnter(object sender, EventArgs e)
        {
            BotonRutas.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Ruta_Azul;
        }

        private void BotonRutas_MouseLeave(object sender, EventArgs e)
        {
            BotonRutas.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Ruta;
        }

        private void BotonUsuarios_MouseEnter(object sender, EventArgs e)
        {
            BotonUsuarios.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Ususarios_Azul;
        }

        private void BotonUsuarios_MouseLeave(object sender, EventArgs e)
        {
            BotonUsuarios.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Ususarios;
        }

        private void BotonCliente_MouseEnter(object sender, EventArgs e)
        {
            BotonCliente.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Clientes_Azul1;
        }

        private void BotonCliente_MouseLeave(object sender, EventArgs e)
        {
            BotonCliente.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Clientes1;
        }

        private void BotonEscaner_MouseEnter(object sender, EventArgs e)
        {
            BotonEscaner.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Escaner_Azul;
        }

        private void BotonEscaner_MouseLeave(object sender, EventArgs e)
        {
            BotonEscaner.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.Escaner;
        }

        private void BotonFactMensual_MouseEnter(object sender, EventArgs e)
        {
            BotonFactMensual.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.FacturaMensual_Azul;
        }

        private void BotonFactMensual_MouseLeave(object sender, EventArgs e)
        {
            BotonFactMensual.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.FacturaMensual;
        }

        private void BotonFactManual_MouseEnter(object sender, EventArgs e)
        {
            BotonFactManual.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.FacturaManual_Azul;
        }

        private void BotonFactManual_MouseLeave(object sender, EventArgs e)
        {
            BotonFactManual.BackgroundImage = Proyecto_Antonio_Luis.Properties.Resources.FacturaManual;
        }
        //************************************************************************************************************
        //************************************************************************************************************
        //************************************************************************************************************
        //*****************                                                                               ************
        //*****************       Termina el cambio de color los botones cuando los señala el raton       ************
        //*****************                                                                               ************
        //*****************                                                                               ************
        //************************************************************************************************************
        //************************************************************************************************************
        //************************************************************************************************************




        //============================================================================================================
        //============================================================================================================
        //============================================================================================================
        //=================                                                                               ============
        //=================                                                                               ============
        //=================      Aquí comineza las acciones al pulsar los distintos botones               ============
        //=================                                                                               ============
        //=================                                                                               ============
        //============================================================================================================
        //============================================================================================================
        //============================================================================================================

        private void BotonImpuestos_Click(object sender, EventArgs e)
        {
            // Abre Impuestos

            Impuestos form = new Impuestos();
            form.Show();
        }

        private void BotonSistema_Click(object sender, EventArgs e)
        {
            PanelSistema.Visible = true;
            PanelClientes.Visible = false;
            PanelFacturas.Visible = false;
        }

        private void BotonClientes_Click(object sender, EventArgs e)
        {
            PanelSistema.Visible = false;
            PanelClientes.Visible = true;
            PanelFacturas.Visible = false;
        }

        private void BotonFacturas_Click(object sender, EventArgs e)
        {
            PanelSistema.Visible = false;
            PanelClientes.Visible = false;
            PanelFacturas.Visible = true;
        }

        private void BotonCsb19_Click(object sender, EventArgs e)
        {
            PanelSistema.Visible = false;
            PanelClientes.Visible = false;
            PanelFacturas.Visible = false;

            GestionRemesas form = new GestionRemesas();
            form.Show();
        }

        private void BotonContaplus_Click(object sender, EventArgs e)
        {
            PanelSistema.Visible = false;
            PanelClientes.Visible = false;
            PanelFacturas.Visible = false;
            // Abre Contaplus
            Contaplus form = new Contaplus();
            form.Show();
        }

        private void BotonListados_Click(object sender, EventArgs e)
        {
            PanelSistema.Visible = false;
            PanelClientes.Visible = false;
            PanelFacturas.Visible = false;
        }

        private void BotonMantenimiento_Click(object sender, EventArgs e)
        {
            PanelSistema.Visible = false;
            PanelClientes.Visible = false;
            PanelFacturas.Visible = false;
        }

        private void BotonPropios_Click(object sender, EventArgs e)
        {
            // Abre Propios

            MisDatos form = new MisDatos();
            form.Show();
        }

        private void BotonRutas_Click(object sender, EventArgs e)
        {
            // Abre Rutas

            Rutas form = new Rutas();
            form.Show();
        }

        private void BotonUsuarios_Click(object sender, EventArgs e)
        {
            // Abre Gestion de Ususarios

            GestionUsuarios form = new GestionUsuarios();
            form.Show();
        }

        private void BotonCliente_Click(object sender, EventArgs e)
        {
            // Abre Gestion de Clientes

            GestionClientes form = new GestionClientes();
            form.Show();
        }

        private void BotonEscaner_Click(object sender, EventArgs e)
        {

        }

        private void BotonFactMensual_Click(object sender, EventArgs e)
        {
            Facturacion form = new Facturacion();
            form.Show();
        }

        private void BotonFactManual_Click(object sender, EventArgs e)
        {
            GestionFacturas form = new GestionFacturas();
            form.Show();

        }

        private void BotonAgenda_Click(object sender, EventArgs e)
        {
            PanelSistema.Visible = false;
            PanelClientes.Visible = false;
            PanelFacturas.Visible = false;
        }

        private void BotonAyuda_Click(object sender, EventArgs e)
        {
            PanelSistema.Visible = false;
            PanelClientes.Visible = false;
            PanelFacturas.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //============================================================================================================
        //============================================================================================================
        //============================================================================================================
        //=================                                                                               ============
        //=================                                                                               ============
        //=================      Aquí termina las acciones al pulsar los distintos botones               ============
        //=================                                                                               ============
        //=================                                                                               ============
        //============================================================================================================
        //============================================================================================================
        //============================================================================================================
    }
}