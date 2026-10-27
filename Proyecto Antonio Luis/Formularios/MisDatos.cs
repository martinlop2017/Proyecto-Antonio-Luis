using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BaseDatos;
using Proyecto_Antonio_Luis.Clases;

namespace Proyecto_Antonio_Luis.Formularios
{
    /// <summary>
    /// Datos de la empresa emisora (tabla Propios, una sola fila).
    /// Se usan en las facturas y en la remesa SEPA.
    /// </summary>
    public partial class MisDatos : Form
    {
        private readonly AdministracionAntonioEntities bd;

        public MisDatos()
        {
            InitializeComponent();
            bd = new AdministracionAntonioEntities();
        }

        // =====================================================================
        //  Carga
        // =====================================================================

        private void Propios_Load(object sender, EventArgs e)
        {
            try
            {
                Propios mios = BuscarMisDatos();
                if (mios == null)
                {
                    // Instalación nueva: el formulario se abre vacío y al grabar se crean los datos
                    label15.Text = "Mis Datos (sin datos todavía)";
                    CargarLogo(null);   // logo del programa
                    return;
                }

                textBoxMiNombre.Text = Limpio(mios.minombre);
                textBoxMiCif.Text = Limpio(mios.micif);
                textBoxMiDiereccion.Text = Limpio(mios.midireccion);
                textBoxMiPoblacion.Text = Limpio(mios.mipoblacion);
                textBoxMiProvincia.Text = Limpio(mios.miprovincia);
                textBoxMiCP.Text = Limpio(mios.micp);
                textBoxMiTLF1.Text = Limpio(mios.mitelefono1);
                textBoxMiTLF2.Text = Limpio(mios.mitelefono2);
                textBoxMiFax.Text = Limpio(mios.mifax);
                textBoxMiPersonaContacto.Text = Limpio(mios.micontacto);
                textBoxMiMail.Text = Limpio(mios.mimail);
                textBoxIban.Text = ClientesUtil.FormatearIban(ClientesUtil.IbanPropio(mios));
                textboxidentificador.Text = Limpio(mios.miidentificadorbancario);
                textboxbic.Text = Limpio(mios.mibic);
                CargarLogo(mios);
            }
            catch (Exception ex)
            {
                MostrarError("No se han podido cargar tus datos.", ex);
            }
        }

        /// <summary>
        /// La fila de mis datos: la de numerador 1 y, si no existe, la primera que haya.
        /// Devuelve null si la tabla está vacía.
        /// </summary>
        private Propios BuscarMisDatos()
        {
            return ClientesUtil.BuscarMisDatos(bd);
        }

        // =====================================================================
        //  Grabar
        // =====================================================================

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            try
            {
                Propios mios = BuscarMisDatos();
                if (mios == null)
                {
                    mios = new Propios { numerador = 1 };
                    bd.Propios.Add(mios);
                }

                mios.minombre = Limpio(textBoxMiNombre.Text);
                mios.micif = Limpio(textBoxMiCif.Text);
                mios.midireccion = Limpio(textBoxMiDiereccion.Text);
                mios.mipoblacion = Limpio(textBoxMiPoblacion.Text);
                mios.miprovincia = Limpio(textBoxMiProvincia.Text);
                mios.micp = Limpio(textBoxMiCP.Text);
                mios.mitelefono1 = Limpio(textBoxMiTLF1.Text);
                mios.mitelefono2 = Limpio(textBoxMiTLF2.Text);
                mios.mifax = Limpio(textBoxMiFax.Text);
                mios.micontacto = Limpio(textBoxMiPersonaContacto.Text);
                mios.mimail = Limpio(textBoxMiMail.Text);
                mios.miidentificadorbancario = ClientesUtil.SoloAlfanumerico(textboxidentificador.Text);
                mios.mibic = ClientesUtil.SoloAlfanumerico(textboxbic.Text);
                // Logo: la imagen se guarda dentro de la tabla; la ruta solo como referencia
                if (logoCambiado)
                {
                    mios.milogoimagen = logoBytes;
                    mios.milogo = logoRuta;
                }

                // IBAN completo + los 6 bloques antiguos (si cabe), por compatibilidad
                string iban = ClientesUtil.NormalizarIban(textBoxIban.Text);
                string[] bloques = ClientesUtil.BloquesIban(iban);
                mios.miiban = iban;
                mios.miiban1 = bloques[0];
                mios.miiban2 = bloques[1];
                mios.miiban3 = bloques[2];
                mios.miiban4 = bloques[3];
                mios.miiban5 = bloques[4];
                mios.miiban6 = bloques[5];

                bd.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MostrarError("No se han podido grabar tus datos.", ex);
            }
        }

        private bool Validar()
        {
            var errores = new List<string>();
            var avisos = new List<string>();
            Control primerError = null;

            Action<Control, string> error = (control, mensaje) =>
            {
                errores.Add(mensaje);
                if (primerError == null) primerError = control;
            };

            string nombre = Limpio(textBoxMiNombre.Text);
            string nif = ClientesUtil.SoloAlfanumerico(textBoxMiCif.Text);
            string mail = Limpio(textBoxMiMail.Text);
            string iban = ClientesUtil.NormalizarIban(textBoxIban.Text);
            string identificador = ClientesUtil.SoloAlfanumerico(textboxidentificador.Text);
            string bic = ClientesUtil.SoloAlfanumerico(textboxbic.Text);

            if (nombre.Length == 0)
                error(textBoxMiNombre, "El nombre es obligatorio (sale en las facturas y en la remesa).");
            else if (nombre.Length > 70)
                avisos.Add("El nombre tiene " + nombre.Length + " caracteres; en la remesa SEPA se cortará a 70.");

            if (nif.Length == 0)
                error(textBoxMiCif, "El NIF/CIF es obligatorio (forma el identificador de acreedor SEPA).");

            if (mail.Length > 0 && !CorreoValido(mail))
                error(textBoxMiMail, "El email no es válido.");

            string motivoIban;
            if (iban.Length > 0 && !ClientesUtil.IbanValido(iban, out motivoIban))
                error(textBoxIban, "La cuenta IBAN no es correcta: " + motivoIban + ".");

            if (bic.Length > 0 && !ClientesUtil.BicValido(bic))
                error(textboxbic, "El BIC debe tener 8 u 11 caracteres (4 letras del banco, 2 del país y 2 o 5 más).");

            // Identificador de acreedor: ES + 2 dígitos de control + 3 de sufijo (normalmente 000).
            // Los dígitos de control dependen del NIF: si no cuadran, solo se avisa.
            if (identificador.Length > 0 && nif.Length > 0)
            {
                string digitos = ClientesUtil.DigitosControlAcreedor(nif);
                bool formatoOk = identificador.Length == 7 && identificador.StartsWith("ES")
                                 && char.IsDigit(identificador[2]) && char.IsDigit(identificador[3]);
                if (!formatoOk || identificador.Substring(2, 2) != digitos)
                {
                    string sufijo = identificador.Length == 7 ? identificador.Substring(4) : "000";
                    avisos.Add("El identificador SEPA \"" + identificador + "\" no cuadra con el NIF " + nif +
                               ". Según el NIF debería ser ES" + digitos + sufijo +
                               " (compruébalo con el banco).");
                }
            }

            if (errores.Count > 0)
            {
                MessageBox.Show("Revisa los siguientes datos:\n\n- " + string.Join("\n- ", errores),
                    "Mis datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (primerError != null) primerError.Focus();
                return false;
            }

            if (avisos.Count > 0)
            {
                return MessageBox.Show("Atención:\n\n- " + string.Join("\n- ", avisos) + "\n\n¿Grabar igualmente?",
                    "Mis datos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
            }
            return true;
        }

        // =====================================================================
        //  Salir
        // =====================================================================

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            QuitarLogo();
            bd.Dispose();
            base.OnFormClosed(e);
        }

        // =====================================================================
        //  Logo
        // =====================================================================

        /// <summary>Tamaño máximo del fichero del logo (para no cargar la base de datos).</summary>
        private const int LogoTamanoMaximo = 2 * 1024 * 1024;

        /// <summary>Imagen del logo tal como se guardará en la tabla (null = sin logo propio).</summary>
        private byte[] logoBytes;

        /// <summary>True si el logo ha cambiado y hay que guardarlo al grabar.</summary>
        private bool logoCambiado;

        /// <summary>Fichero del que se ha leído el logo (solo como referencia).</summary>
        private string logoRuta;

        /// <summary>Elegir un logo: se lee el fichero y se guardará DENTRO de la tabla al grabar.</summary>
        private void button3_Click(object sender, EventArgs e)
        {
            using (var buscar = new OpenFileDialog())
            {
                buscar.Title = "Elige el logo";
                buscar.Filter = "Imágenes|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Todos los archivos|*.*";
                if (buscar.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                byte[] bytes;
                string motivo;
                if (!LeerImagen(buscar.FileName, out bytes, out motivo))
                {
                    MessageBox.Show("No se puede usar ese fichero como logo: " + motivo + ".",
                        "Logo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                logoBytes = bytes;
                logoCambiado = true;
                logoRuta = buscar.FileName;
                textBox23.Text = buscar.FileName;
                MostrarLogo(logoBytes);
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            // La ruta solo es informativa: el logo se guarda en la tabla
        }

        /// <summary>
        /// Carga el logo al abrir el formulario:
        ///   1) la imagen guardada en la tabla;
        ///   2) si aún no hay imagen guardada pero la ruta antigua existe, la lee
        ///      de ahí y la guarda en la tabla al pulsar Grabar;
        ///   3) si no hay nada, muestra el logo que lleva el programa.
        /// </summary>
        private void CargarLogo(Propios mios)
        {
            logoBytes = null;
            logoCambiado = false;
            logoRuta = mios != null ? Limpio(mios.milogo) : "";

            if (mios != null && mios.milogoimagen != null && mios.milogoimagen.Length > 0)
            {
                logoBytes = mios.milogoimagen;
                textBox23.Text = Limpio(mios.milogo).Length > 0 ? Limpio(mios.milogo) : "(guardado en la base de datos)";
            }
            else if (mios != null)
            {
                byte[] bytes;
                string motivo;
                string ruta = Limpio(mios.milogo);
                if (ruta.Length > 0 && LeerImagen(ruta, out bytes, out motivo))
                {
                    logoBytes = bytes;
                    logoCambiado = true;   // se guardará en la tabla al grabar
                    logoRuta = ruta;
                    textBox23.Text = ruta + "  (pulsa Grabar para guardarlo en la base de datos)";
                }
                else
                {
                    textBox23.Text = "";
                }
            }

            MostrarLogo(logoBytes);
        }

        /// <summary>Lee un fichero de imagen comprobando que existe, que no es muy grande y que es una imagen.</summary>
        private static bool LeerImagen(string ruta, out byte[] bytes, out string motivo)
        {
            bytes = null;
            motivo = null;
            try
            {
                var info = new FileInfo(ruta);
                if (!info.Exists)
                {
                    motivo = "no existe";
                    return false;
                }
                if (info.Length > LogoTamanoMaximo)
                {
                    motivo = "ocupa " + (info.Length / 1024) + " KB y el máximo es " + (LogoTamanoMaximo / 1024) + " KB";
                    return false;
                }

                byte[] leidos = File.ReadAllBytes(ruta);
                using (var flujo = new MemoryStream(leidos))
                using (Image.FromStream(flujo))
                {
                    // Solo se comprueba que es una imagen válida
                }
                bytes = leidos;
                return true;
            }
            catch (Exception ex)
            {
                motivo = ex is ArgumentException ? "no es una imagen válida" : ex.Message;
                return false;
            }
        }

        /// <summary>Muestra el logo guardado o, si no hay, el que lleva el programa (el de las facturas).</summary>
        private void MostrarLogo(byte[] imagen)
        {
            QuitarLogo();
            if (imagen != null && imagen.Length > 0)
            {
                try
                {
                    using (var flujo = new MemoryStream(imagen))
                    using (var img = Image.FromStream(flujo))
                    {
                        panel1.BackgroundImage = new Bitmap(img);
                        return;
                    }
                }
                catch
                {
                    // Imagen dañada: se muestra el logo del programa
                }
            }
            panel1.BackgroundImage = Properties.Resources.Logo_Antonio_Luis;
        }

        private void QuitarLogo()
        {
            var anterior = panel1.BackgroundImage;
            panel1.BackgroundImage = null;
            if (anterior != null) anterior.Dispose();
        }

        // =====================================================================
        //  IBAN
        // =====================================================================

        private void textBoxIban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void textBoxIban_Leave(object sender, EventArgs e)
        {
            textBoxIban.Text = ClientesUtil.FormatearIban(textBoxIban.Text);
        }

        // =====================================================================
        //  Utilidades
        // =====================================================================

        private static string Limpio(string texto)
        {
            return (texto ?? "").Trim();
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
                if (detalle.Contains("milogoimagen"))
                {
                    detalle += "\n\nFalta ejecutar el script SQL\\2026-10-27_Propios_logo_en_tabla.sql en la base de datos.";
                }
                if (detalle.Contains("miiban"))
                {
                    detalle += "\n\nFalta ejecutar el script SQL\\2026-10-27_Propios_mis_datos.sql en la base de datos.";
                }
            }
            MessageBox.Show(mensaje + "\n\n" + detalle, "Mis datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
