using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            //Al Iniciar Carga la fecha y la hora

            FechaInicio.Text = "    Fecha : " + DateTime.Now.ToString("dd/MM/yyyy") + "   -   Hora: " + DateTime.Now.ToLongTimeString() + "  ";
            timer1.Start();
            
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
        }

        private void BotonContaplus_Click(object sender, EventArgs e)
        {
            PanelSistema.Visible = false;
            PanelClientes.Visible = false;
            PanelFacturas.Visible = false;
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

        }

        private void BotonRutas_Click(object sender, EventArgs e)
        {

        }

        private void BotonUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void BotonCliente_Click(object sender, EventArgs e)
        {

        }

        private void BotonEscaner_Click(object sender, EventArgs e)
        {

        }

        private void BotonFactMensual_Click(object sender, EventArgs e)
        {

        }

        private void BotonFactManual_Click(object sender, EventArgs e)
        {

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