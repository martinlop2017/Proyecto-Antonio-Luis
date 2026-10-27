using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BaseDatos;
using Proyecto_Antonio_Luis.Clases;

namespace Proyecto_Antonio_Luis.Formularios
{
    /// <summary>
    /// Ficha de cliente: alta (Globales.llamadas = "1") y
    /// modificación (Globales.llamadas = "2", con Globales.modificar = código de cliente).
    /// Devuelve DialogResult.OK si se ha grabado.
    /// </summary>
    public partial class Cliente : Form
    {
        private readonly AdministracionAntonioEntities bd;

        /// <summary>Cliente que se está modificando (null en un alta).</summary>
        private Clientes cliente;

        /// <summary>Nombre que tenía el cliente al abrir la ficha (para renombrar su carpeta).</summary>
        private string nombreOriginal;

        /// <summary>True mientras se rellenan los controles (para no lanzar avisos).</summary>
        private bool cargando = true;

        private bool EsAlta
        {
            get { return Globales.llamadas == "1"; }
        }

        public Cliente()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }

        // =====================================================================
        //  Carga del formulario
        // =====================================================================

        private void Clientes_Load(object sender, EventArgs e)
        {
            try
            {
                if (EsAlta)
                {
                    PrepararAlta();
                }
                else
                {
                    CargarCliente();
                }
                ActualizarCuadroIban();
                cargando = false;
            }
            catch (Exception ex)
            {
                MostrarError("No se han podido cargar los datos del cliente.", ex);
                BeginInvoke(new Action(Close));
            }
        }

        private void PrepararAlta()
        {
            label15.Text = "Nuevo cliente";
            // Código previsto; el definitivo se asigna al grabar
            label1.Text = ClientesUtil.SiguienteCodigoPrevisto(bd).ToString("0");
            textFechaAlta.Text = DateTime.Today.ToString("dd/MM/yyyy");
            checActivo.Checked = true;
        }

        private void CargarCliente()
        {
            decimal codigo = Globales.modificar;
            cliente = bd.Clientes.FirstOrDefault(x => x.codcliente == codigo);

            if (cliente == null)
            {
                MessageBox.Show("No se ha encontrado el cliente con código " + codigo + ".",
                    "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BeginInvoke(new Action(Close));
                return;
            }

            label15.Text = "Modificar cliente";
            if (cliente.activocliente != true)
            {
                label15.Text += cliente.fechabajacliente.HasValue
                    ? "  -  DE BAJA desde " + cliente.fechabajacliente.Value.ToString("dd/MM/yyyy")
                    : "  -  DE BAJA";
            }
            nombreOriginal = Limpio(cliente.nombrecliente);

            label1.Text = cliente.codcliente.HasValue ? cliente.codcliente.Value.ToString("0") : "";
            textMiNombre.Text = Limpio(cliente.nombrecliente);
            textMiCif.Text = Limpio(cliente.cifcliente);
            textMiDiereccion.Text = Limpio(cliente.direcioncliente);
            textMiPoblacion.Text = Limpio(cliente.localidacliente);
            textMiProvincia.Text = Limpio(cliente.provinciacliente);
            textMiCP.Text = Limpio(cliente.cod_postalcliente);
            textMiTLF1.Text = Limpio(cliente.telefono1cliente);
            textMiTLF2.Text = Limpio(cliente.telefono2cliente);
            textMiFax.Text = Limpio(cliente.faxcliente);
            textMiPersonaContacto.Text = Limpio(cliente.contactocliente);
            textMiMail.Text = Limpio(cliente.mailcliente);
            textObserva.Text = Limpio(cliente.comentariocliente);
            comboGrupo.Text = Limpio(cliente.grupocliente);

            checActivo.Checked = cliente.activocliente == true;
            checDomiciliacion.Checked = cliente.domiciliadocliente == true;
            checRE.Checked = cliente.recargo == true;
            checRetencion.Checked = cliente.retencioncliente == true;
            checContabilizar.Checked = cliente.contabilizarcliente == true;
            checpormail.Checked = cliente.pormailcliente == true;
            checIntrastat.Checked = cliente.instrastatcliente == true;

            textIban.Text = ClientesUtil.FormatearIban(ClientesUtil.IbanCliente(cliente));

            textTrabajadores.Text = cliente.empleadoscliente.HasValue ? cliente.empleadoscliente.Value.ToString("0") : "";
            textPreciotrabajador.Text = FormatoImporte(cliente.precioempleadocliente);
            textTarifa.Text = FormatoImporte(cliente.tarifacliente);
            textFechaAlta.Text = cliente.fechaaltacliente.HasValue
                ? cliente.fechaaltacliente.Value.ToString("dd/MM/yyyy")
                : "";

            chec100.Checked = cliente.mod100 == true;
            chec111.Checked = cliente.mod111 == true;
            chec115.Checked = cliente.mod115 == true;
            chec123.Checked = cliente.mod123 == true;
            chec130.Checked = cliente.mod130 == true;
            chec131.Checked = cliente.mod131 == true;
            chec180.Checked = cliente.mod180 == true;
            chec190.Checked = cliente.mod190 == true;
            chec193.Checked = cliente.mod193 == true;
            chec200.Checked = cliente.mod200 == true;
            chec202.Checked = cliente.mod202 == true;
            chec303.Checked = cliente.mod303 == true;
            chec309.Checked = cliente.mod309 == true;
            chec349.Checked = cliente.mod349 == true;
            chec390.Checked = cliente.mod390 == true;
            chec751.Checked = cliente.mod751 == true;
            chec752.Checked = cliente.mod752 == true;
        }

        // =====================================================================
        //  Botones
        // =====================================================================

        /// <summary>Grabar.</summary>
        private void button1_Click(object sender, EventArgs e)
        {
            DatosFormulario datos;
            if (!LeerYValidar(out datos))
            {
                return;
            }

            bool grabado = EsAlta ? GrabarAlta(datos) : GrabarModificacion(datos);
            if (!grabado)
            {
                return;
            }

            GestionarCarpetas(datos.Nombre);

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>Salir sin grabar.</summary>
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            bd.Dispose();
            base.OnFormClosed(e);
        }

        // =====================================================================
        //  Lectura y validación de los datos del formulario
        // =====================================================================

        /// <summary>Valores numéricos y de fecha ya convertidos.</summary>
        private class DatosFormulario
        {
            public string Nombre;
            public decimal Empleados;
            public decimal PrecioEmpleado;
            public decimal Tarifa;
            public DateTime? FechaAlta;
        }

        private bool LeerYValidar(out DatosFormulario datos)
        {
            datos = new DatosFormulario();
            var errores = new List<string>();
            Control primerError = null;

            Action<Control, string> error = (control, mensaje) =>
            {
                errores.Add(mensaje);
                if (primerError == null) primerError = control;
            };

            // Nombre (obligatorio)
            datos.Nombre = Limpio(textMiNombre.Text);
            if (datos.Nombre.Length == 0)
            {
                error(textMiNombre, "El nombre del cliente es obligatorio.");
            }

            // Números (vacío = 0)
            decimal empleados;
            if (!ClientesUtil.LeerDecimal(textTrabajadores.Text, out empleados) || empleados < 0 || empleados != Math.Floor(empleados))
                error(textTrabajadores, "Nº de trabajadores no válido.");
            datos.Empleados = empleados;

            decimal precio;
            if (!ClientesUtil.LeerDecimal(textPreciotrabajador.Text, out precio) || precio < 0)
                error(textPreciotrabajador, "Importe por empleado no válido.");
            datos.PrecioEmpleado = Math.Round(precio, 2);

            decimal tarifa;
            if (!ClientesUtil.LeerDecimal(textTarifa.Text, out tarifa) || tarifa < 0)
                error(textTarifa, "Tarifa no válida.");
            datos.Tarifa = Math.Round(tarifa, 2);

            // Fecha de alta (opcional)
            DateTime fecha;
            string textoFecha = textFechaAlta.Text.Replace("/", "").Trim();
            if (textoFecha.Length == 0)
            {
                datos.FechaAlta = null;
            }
            else if (DateTime.TryParseExact(textFechaAlta.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
            {
                datos.FechaAlta = fecha;
            }
            else
            {
                error(textFechaAlta, "La fecha de alta no es válida (dd/mm/aaaa).");
            }

            // Correo
            string mail = Limpio(textMiMail.Text);
            if (mail.Length > 0 && !CorreoValido(mail))
                error(textMiMail, "El email no es válido.");
            if (checpormail.Checked && mail.Length == 0)
                error(textMiMail, "Para enviar las facturas por email hay que indicar el email.");

            // IBAN
            string iban = ClientesUtil.NormalizarIban(textIban.Text);
            string motivoIban;
            if (checDomiciliacion.Checked && iban.Length == 0)
                error(textIban, "Para domiciliar hay que indicar la cuenta (IBAN).");
            else if (checDomiciliacion.Checked && iban.Length > 0 && !ClientesUtil.IbanValido(iban, out motivoIban))
                error(textIban, "La cuenta IBAN no es correcta: " + motivoIban + ".");

            if (errores.Count > 0)
            {
                MessageBox.Show("Revisa los siguientes datos:\n\n- " + string.Join("\n- ", errores),
                    "Datos del cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (primerError != null) primerError.Focus();
                return false;
            }

            // Mismo nombre que otro cliente: compartirían carpeta de documentos
            if (NombreRepetido(datos.Nombre) &&
                MessageBox.Show("Ya existe otro cliente con el nombre:\n\n" + datos.Nombre +
                                "\n\nLas facturas y documentos se guardan en una carpeta con el nombre del cliente, " +
                                "así que ambos compartirían carpeta.\n\n¿Grabar igualmente?",
                                "Nombre repetido", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                textMiNombre.Focus();
                return false;
            }
            return true;
        }

        private bool NombreRepetido(string nombre)
        {
            decimal? miCodigo = cliente == null ? (decimal?)null : cliente.codcliente;
            return bd.Clientes.Any(x => x.nombrecliente == nombre && x.codcliente != miCodigo);
        }

        // =====================================================================
        //  Grabación
        // =====================================================================

        private bool GrabarAlta(DatosFormulario datos)
        {
            var nuevo = new Clientes();
            PasarDatos(nuevo, datos);

            try
            {
                using (var transaccion = bd.Database.BeginTransaction())
                {
                    // El código se reserva aquí para que no se reutilice nunca
                    nuevo.codcliente = ClientesUtil.ReservarSiguienteCodigo(bd);
                    bd.Clientes.Add(nuevo);
                    bd.SaveChanges();
                    transaccion.Commit();
                }
            }
            catch (Exception ex)
            {
                bd.Entry(nuevo).State = System.Data.Entity.EntityState.Detached;
                MostrarError("No se ha podido dar de alta el cliente.", ex);
                return false;
            }

            Globales.modificar = Convert.ToInt32(nuevo.codcliente.Value);
            string codigoPrevisto = label1.Text;
            label1.Text = nuevo.codcliente.Value.ToString("0");
            if (codigoPrevisto != label1.Text)
            {
                MessageBox.Show("El cliente se ha grabado con el código " + label1.Text + ".",
                    "Nuevo cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return true;
        }

        private bool GrabarModificacion(DatosFormulario datos)
        {
            if (cliente == null)
            {
                return false;
            }

            PasarDatos(cliente, datos);
            try
            {
                bd.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MostrarError("No se han podido grabar los cambios del cliente.", ex);
                return false;
            }
        }

        /// <summary>Copia los datos del formulario a la entidad.</summary>
        private void PasarDatos(Clientes c, DatosFormulario datos)
        {
            c.nombrecliente = datos.Nombre;
            c.cifcliente = ClientesUtil.Texto(textMiCif.Text);
            c.direcioncliente = ClientesUtil.Texto(textMiDiereccion.Text);
            c.localidacliente = ClientesUtil.Texto(textMiPoblacion.Text);
            c.provinciacliente = ClientesUtil.Texto(textMiProvincia.Text);
            c.cod_postalcliente = ClientesUtil.Texto(textMiCP.Text);
            c.telefono1cliente = ClientesUtil.Texto(textMiTLF1.Text);
            c.telefono2cliente = ClientesUtil.Texto(textMiTLF2.Text);
            c.faxcliente = ClientesUtil.Texto(textMiFax.Text);
            c.contactocliente = ClientesUtil.Texto(textMiPersonaContacto.Text);
            c.mailcliente = ClientesUtil.Texto(textMiMail.Text);
            c.comentariocliente = ClientesUtil.Texto(textObserva.Text);
            c.grupocliente = ClientesUtil.Texto(comboGrupo.Text);

            c.empleadoscliente = datos.Empleados;
            c.precioempleadocliente = datos.PrecioEmpleado;
            c.tarifacliente = datos.Tarifa;
            c.fechaaltacliente = datos.FechaAlta;

            // Baja / reactivación. Un cliente de baja conserva todos sus datos;
            // solo deja de incluirse en la facturación mensual.
            bool estabaActivo = c.activocliente != false;
            if (checActivo.Checked)
            {
                c.bajacliente = false;
                c.fechabajacliente = null;
            }
            else
            {
                if (estabaActivo || !c.fechabajacliente.HasValue)
                {
                    c.fechabajacliente = DateTime.Today;
                }
                c.bajacliente = true;
            }
            c.activocliente = checActivo.Checked;
            c.domiciliadocliente = checDomiciliacion.Checked;
            c.recargo = checRE.Checked;
            c.retencioncliente = checRetencion.Checked;
            c.contabilizarcliente = checContabilizar.Checked;
            c.pormailcliente = checpormail.Checked;
            c.instrastatcliente = checIntrastat.Checked;

            // IBAN completo (hasta 34). Los bloques antiguos de 4 en 4 se siguen
            // rellenando si cabe, por compatibilidad; si no cabe, quedan vacíos.
            string iban = ClientesUtil.NormalizarIban(textIban.Text);
            string[] bloques = ClientesUtil.BloquesIban(iban);
            c.ibancliente = iban;
            c.iban1cliente = bloques[0];
            c.iban2cliente = bloques[1];
            c.iban3cliente = bloques[2];
            c.iban4cliente = bloques[3];
            c.iban5cliente = bloques[4];
            c.iban6cliente = bloques[5];

            c.mod100 = chec100.Checked;
            c.mod111 = chec111.Checked;
            c.mod115 = chec115.Checked;
            c.mod123 = chec123.Checked;
            c.mod130 = chec130.Checked;
            c.mod131 = chec131.Checked;
            c.mod180 = chec180.Checked;
            c.mod190 = chec190.Checked;
            c.mod193 = chec193.Checked;
            c.mod200 = chec200.Checked;
            c.mod202 = chec202.Checked;
            c.mod303 = chec303.Checked;
            c.mod309 = chec309.Checked;
            c.mod349 = chec349.Checked;
            c.mod390 = chec390.Checked;
            c.mod751 = chec751.Checked;
            c.mod752 = chec752.Checked;
        }

        // =====================================================================
        //  Carpetas de documentos (C:\ByMartin\Clientes\<nombre>)
        // =====================================================================

        private void GestionarCarpetas(string nombreNuevo)
        {
            try
            {
                string carpetaNueva = ClientesUtil.CarpetaCliente(nombreNuevo);

                // Si se ha cambiado el nombre, ofrecer renombrar la carpeta existente
                if (!EsAlta && !string.IsNullOrEmpty(nombreOriginal))
                {
                    string carpetaVieja = ClientesUtil.CarpetaCliente(nombreOriginal);
                    bool cambiaCarpeta = !string.Equals(carpetaVieja, carpetaNueva, StringComparison.OrdinalIgnoreCase);

                    if (cambiaCarpeta && Directory.Exists(carpetaVieja) && !Directory.Exists(carpetaNueva))
                    {
                        if (MessageBox.Show(
                                "Has cambiado el nombre del cliente.\n\n¿Renombrar también su carpeta de documentos?\n\n" +
                                carpetaVieja + "\n   →\n" + carpetaNueva,
                                "Carpeta del cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Directory.Move(carpetaVieja, carpetaNueva);
                        }
                    }
                }

                ClientesUtil.CrearCarpetas(nombreNuevo);
            }
            catch (Exception ex)
            {
                // El cliente ya está grabado: solo avisamos
                MostrarError("El cliente se ha grabado, pero no se ha podido preparar su carpeta de documentos.", ex);
            }
        }

        /// <summary>Aviso al dar de baja o reactivar un cliente.</summary>
        /// <summary>
        /// El IBAN solo se puede escribir si el cliente tiene domiciliación bancaria.
        /// Al desmarcar la domiciliación el cuadro queda en gris pero NO se borra:
        /// el IBAN guardado se conserva y reaparece al volver a marcarla.
        /// </summary>
        private void checDomiciliacion_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarCuadroIban();
            if (!cargando && checDomiciliacion.Checked)
            {
                textIban.Focus();
            }
        }

        private void ActualizarCuadroIban()
        {
            textIban.Enabled = checDomiciliacion.Checked;
            label14.Enabled = checDomiciliacion.Checked;
        }

        private void checActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (cargando)
            {
                return;
            }

            if (!checActivo.Checked)
            {
                MessageBox.Show(
                    "El cliente quedará DE BAJA al grabar (por ejemplo, baja temporal en Hacienda).\n\n" +
                    "- Se conservan todos sus datos.\n" +
                    "- No se le generarán facturas mensuales mientras esté de baja.\n" +
                    "- Para reactivarlo, vuelve a marcar \"Activo\".",
                    "Baja del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!EsAlta && cliente != null && cliente.activocliente != true)
            {
                MessageBox.Show("El cliente se reactivará al grabar y volverá a incluirse en la facturación mensual.",
                    "Reactivar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // =====================================================================
        //  Filtros de teclado
        // =====================================================================

        /// <summary>Solo dígitos (y teclas de control como Retroceso).</summary>
        private void SoloDigitos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>IBAN: letras, dígitos y espacios.</summary>
        private void textIban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        /// <summary>Al salir del IBAN se muestra en grupos de 4 para leerlo mejor.</summary>
        private void textIban_Leave(object sender, EventArgs e)
        {
            textIban.Text = ClientesUtil.FormatearIban(textIban.Text);
        }

        /// <summary>Teléfonos: dígitos, espacios y el prefijo +.</summary>
        private void Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        /// <summary>Importes: dígitos y una coma decimal (el punto se convierte en coma).</summary>
        private void Importe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                return;
            }

            var caja = sender as TextBox;
            // Solo una coma (sin contar el texto seleccionado, que se va a sustituir)
            if (e.KeyChar == ',' && caja != null &&
                !caja.Text.Remove(caja.SelectionStart, caja.SelectionLength).Contains(","))
            {
                return;
            }

            e.Handled = true;
        }

        // =====================================================================
        //  Utilidades
        // =====================================================================

        private static string Limpio(string texto)
        {
            return (texto ?? "").Trim();
        }

        private static string FormatoImporte(decimal? valor)
        {
            return valor.HasValue ? valor.Value.ToString("0.00", new CultureInfo("es-ES")) : "";
        }

        private static bool CorreoValido(string mail)
        {
            int arroba = mail.IndexOf('@');
            return arroba > 0
                && arroba == mail.LastIndexOf('@')
                && mail.IndexOf('.', arroba) > arroba + 1
                && !mail.EndsWith(".")
                && !mail.Contains(" ");
        }

        /// <summary>Muestra el error real (incluido el de SQL Server) en lugar de un mensaje genérico.</summary>
        private static void MostrarError(string mensaje, Exception ex)
        {
            string detalle;

            var validacion = ex as DbEntityValidationException;
            if (validacion != null)
            {
                detalle = string.Join("\n", validacion.EntityValidationErrors
                    .SelectMany(v => v.ValidationErrors)
                    .Select(v => "- " + v.PropertyName + ": " + v.ErrorMessage));
            }
            else
            {
                Exception interna = ex;
                while (interna.InnerException != null)
                {
                    interna = interna.InnerException;
                }
                detalle = interna.Message;

                if (detalle.Contains("retencion"))
                {
                    detalle += "\n\nFalta ejecutar el script SQL\\2026-10-27_Retenciones_IRPF.sql en la base de datos.";
                }
                if (detalle.Contains("ibancliente") || detalle.Contains("factiban"))
                {
                    detalle += "\n\nFalta ejecutar el script SQL\\2026-10-27_IBAN_campo_unico.sql en la base de datos.";
                }
                if (detalle.Contains("Contadores"))
                {
                    detalle += "\n\nFalta ejecutar el script SQL\\2026-10-26_Clientes_ampliar_campos.sql en la base de datos.";
                }
            }

            MessageBox.Show(mensaje + "\n\n" + detalle, "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
