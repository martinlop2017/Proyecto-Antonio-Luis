using System;
using System.Windows.Forms;
using BaseDatos;
using Proyecto_Antonio_Luis.Clases;

namespace Proyecto_Antonio_Luis.Formularios
{
    /// <summary>
    /// Configuración del correo con el que se envían las facturas
    /// (servidor SMTP del dominio propio). Se abre desde Mis Datos.
    /// </summary>
    public partial class ConfiguracionCorreo : Form
    {
        public ConfiguracionCorreo()
        {
            InitializeComponent();
        }

        private void ConfiguracionCorreo_Load(object sender, EventArgs e)
        {
            try
            {
                using (var bd = new AdministracionAntonioEntities())
                {
                    if (ClientesUtil.BuscarMisDatos(bd) == null)
                    {
                        MessageBox.Show("Primero hay que grabar Mis Datos.", "Correo de envío",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BeginInvoke(new Action(Close));
                        return;
                    }
                    var c = CorreoUtil.Leer(bd);
                    txtServidor.Text = c.Servidor;
                    numPuerto.Value = Math.Min(Math.Max(c.Puerto, 1), 65535);
                    checkCifrado.Checked = c.Cifrado;
                    txtUsuario.Text = c.Usuario;
                    txtClave.Text = c.Clave;
                    txtRemitente.Text = c.Remitente;
                    txtNombre.Text = c.NombreRemitente;
                    txtCopia.Text = c.CopiaOculta;
                    txtAsunto.Text = c.Asunto;
                    txtTexto.Text = (c.Texto ?? "").Replace("\r\n", "\n").Replace("\n", "\r\n");
                    checkAcuseLectura.Checked = c.AcuseLectura;
                    checkAcuseEntrega.Checked = c.AcuseEntrega;
                }
            }
            catch (Exception ex)
            {
                Error("No se ha podido leer la configuración del correo", ex);
            }
        }

        private ConfigCorreo DePantalla()
        {
            return new ConfigCorreo
            {
                Servidor = txtServidor.Text.Trim(),
                Puerto = (int)numPuerto.Value,
                Cifrado = checkCifrado.Checked,
                Usuario = txtUsuario.Text.Trim(),
                Clave = txtClave.Text,
                Remitente = txtRemitente.Text.Trim(),
                NombreRemitente = txtNombre.Text.Trim(),
                CopiaOculta = txtCopia.Text.Trim(),
                Asunto = txtAsunto.Text.Trim(),
                Texto = txtTexto.Text,
                AcuseLectura = checkAcuseLectura.Checked,
                AcuseEntrega = checkAcuseEntrega.Checked
            };
        }

        /// <summary>Comprueba los datos. Devuelve false (y avisa) si falta algo.</summary>
        private bool Validar(ConfigCorreo c)
        {
            if (c.Servidor.Length == 0)
            {
                Aviso("Escribe el servidor de correo (por ejemplo: mail.tudominio.es).");
                txtServidor.Focus();
                return false;
            }
            if (!CorreoUtil.DireccionValida(c.Remitente))
            {
                Aviso("Escribe un email remitente correcto (por ejemplo: facturas@tudominio.es).");
                txtRemitente.Focus();
                return false;
            }
            if (c.CopiaOculta.Length > 0 && !CorreoUtil.DireccionValida(c.CopiaOculta))
            {
                Aviso("El email de la copia oculta no es correcto. Déjalo vacío si no la quieres.");
                txtCopia.Focus();
                return false;
            }
            if (c.Asunto.Length == 0)
            {
                Aviso("Escribe el asunto del mensaje.");
                txtAsunto.Focus();
                return false;
            }
            if (c.Puerto == 465)
            {
                Aviso("El puerto 465 (SSL directo) no se puede usar desde el programa.\n" +
                      "Usa el puerto 587 con \"Conexión cifrada\" marcada: lo admiten casi todos los servidores.");
                numPuerto.Focus();
                return false;
            }
            return true;
        }

        private void buttonProbar_Click(object sender, EventArgs e)
        {
            var c = DePantalla();
            if (!Validar(c)) return;

            string destino = c.CopiaOculta.Length > 0 ? c.CopiaOculta : c.Remitente;
            if (MessageBox.Show("Se va a enviar un correo de prueba a:\n\n   " + destino + "\n\n¿Enviarlo?", "Correo de envío",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            Cursor = Cursors.WaitCursor;
            try
            {
                var copia = c.CopiaOculta;
                c.CopiaOculta = "";   // la prueba, solo una vez
                CorreoUtil.EnviarPrueba(c, destino);
                c.CopiaOculta = copia;
                Cursor = Cursors.Default;
                MessageBox.Show("Correo de prueba enviado a " + destino + ".\nComprueba que ha llegado (mira también en correo no deseado).",
                    "Correo de envío", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No se ha podido enviar el correo de prueba:\n\n" + CorreoUtil.Explicar(ex), "Correo de envío",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = DePantalla();
            if (!Validar(c)) return;
            try
            {
                using (var bd = new AdministracionAntonioEntities())
                {
                    if (!CorreoUtil.Guardar(bd, c))
                    {
                        Aviso("Primero hay que grabar Mis Datos.");
                        return;
                    }
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Error("No se ha podido guardar la configuración", ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static void Aviso(string texto)
        {
            MessageBox.Show(texto, "Correo de envío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static void Error(string texto, Exception ex)
        {
            var interna = ex;
            while (interna.InnerException != null) interna = interna.InnerException;
            MessageBox.Show(texto + ":\n\n" + interna.Message, "Correo de envío", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
