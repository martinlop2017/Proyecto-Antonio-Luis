using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
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
            checContabilizar.Checked = cliente.contabilizarcliente == true;
            checpormail.Checked = cliente.pormailcliente == true;
            checIntrastat.Checked = cliente.instrastatcliente == true;

            textCCC1.Text = Limpio(cliente.iban1cliente);
            textCCC2.Text = Limpio(cliente.iban2cliente);
            textCCC3.Text = Limpio(cliente.iban3cliente);
            textCCC4.Text = Limpio(cliente.iban4cliente);
            textCCC5.Text = Limpio(cliente.iban5cliente);
            textCCC6.Text = Limpio(cliente.iban6cliente);

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
            string iban = IbanCompleto();
            if (checDomiciliacion.Checked && iban.Length == 0)
                error(textCCC1, "Para domiciliar hay que indicar la cuenta (IBAN).");
            else if (iban.Length > 0 && !IbanValido(iban))
                error(textCCC1, "La cuenta IBAN no es correcta (revisa los 24 caracteres: ES + 22 dígitos).");

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
            c.contabilizarcliente = checContabilizar.Checked;
            c.pormailcliente = checpormail.Checked;
            c.instrastatcliente = checIntrastat.Checked;

            // IBAN en 6 bloques de 4 (así lo usan facturas y remesas)
            string iban = IbanCompleto();
            c.iban1cliente = BloqueIban(iban, 0);
            c.iban2cliente = BloqueIban(iban, 1);
            c.iban3cliente = BloqueIban(iban, 2);
            c.iban4cliente = BloqueIban(iban, 3);
            c.iban5cliente = BloqueIban(iban, 4);
            c.iban6cliente = BloqueIban(iban, 5);

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

        private string IbanCompleto()
        {
            return (textCCC1.Text + textCCC2.Text + textCCC3.Text + textCCC4.Text + textCCC5.Text + textCCC6.Text)
                .Replace(" ", "").Trim().ToUpperInvariant();
        }

        private static string BloqueIban(string iban, int bloque)
        {
            int inicio = bloque * 4;
            if (inicio >= iban.Length) return "";
            return iban.Substring(inicio, Math.Min(4, iban.Length - inicio));
        }

        /// <summary>Comprueba un IBAN español (24 caracteres) con el dígito de control ISO 13616.</summary>
        private static bool IbanValido(string iban)
        {
            if (iban.Length != 24 || !iban.StartsWith("ES") || !iban.Substring(2).All(char.IsDigit))
            {
                return false;
            }

            // Se pasan las letras a números (A=10 ... Z=35) y se calcula el resto entre 97 por partes
            string reordenado = iban.Substring(4) + iban.Substring(0, 4);
            var numero = new StringBuilder();
            foreach (char ch in reordenado)
            {
                numero.Append(char.IsLetter(ch) ? (ch - 'A' + 10).ToString() : ch.ToString());
            }

            int resto = 0;
            foreach (char digito in numero.ToString())
            {
                resto = (resto * 10 + (digito - '0')) % 97;
            }
            return resto == 1;
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

                if (detalle.Contains("Contadores"))
                {
                    detalle += "\n\nFalta ejecutar el script SQL\\2026-10-26_Clientes_ampliar_campos.sql en la base de datos.";
                }
            }

            MessageBox.Show(mensaje + "\n\n" + detalle, "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
