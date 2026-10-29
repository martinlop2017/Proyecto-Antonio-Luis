using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BaseDatos;
using Proyecto_Antonio_Luis.Formularios;

namespace Proyecto_Antonio_Luis.Clases
{
    /// <summary>
    /// Envío de facturas por correo desde las pantallas (con avisos y resumen).
    /// </summary>
    public static class EnvioFacturas
    {
        /// <summary>
        /// De esas facturas, las que son de clientes "por mail" y no se han enviado todavía.
        /// </summary>
        public static List<decimal> PendientesDeEnviar(IEnumerable<decimal> ids)
        {
            var lista = ids.ToList();
            using (var bd = new AdministracionAntonioEntities())
            {
                return bd.Facturas.AsNoTracking()
                    .Where(f => lista.Contains(f.factcontador) && f.factpormail == true && f.factenviada != true)
                    .OrderBy(f => f.factnumerofact)
                    .Select(f => f.factcontador)
                    .ToList();
            }
        }

        /// <summary>
        /// Pregunta y envía. Devuelve cuántas se han enviado.
        /// </summary>
        public static int PreguntarYEnviar(IWin32Window ventana, IList<decimal> ids, string pregunta)
        {
            if (ids.Count == 0) return 0;

            ConfigCorreo config;
            using (var bd = new AdministracionAntonioEntities())
            {
                config = CorreoUtil.Leer(bd);
            }
            if (!config.Completa)
            {
                MessageBox.Show(ventana, "Hay " + ids.Count + (ids.Count == 1 ? " factura" : " facturas") +
                                " para enviar por correo, pero el correo de envío no está configurado.\n\n" +
                                "Configúralo en Mis Datos → \"Configurar correo de envío de facturas\" y después " +
                                "envíalas desde Gestión de facturas.",
                    "Envío por correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

            if (MessageBox.Show(ventana, pregunta, "Envío por correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return 0;
            }
            return Enviar(ventana, config, ids);
        }

        /// <summary>Envía las facturas una a una y muestra el resumen.</summary>
        public static int Enviar(IWin32Window ventana, ConfigCorreo config, IList<decimal> ids)
        {
            int enviadas = 0;
            var errores = new List<string>();
            var espera = new FormEsperar("Enviando las facturas por correo");
            var cursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                espera.Show(ventana);
                Application.DoEvents();
                foreach (var id in ids)
                {
                    try
                    {
                        CorreoUtil.EnviarFactura(config, id);
                        enviadas++;
                    }
                    catch (Exception ex)
                    {
                        errores.Add(Descripcion(id) + ": " + CorreoUtil.Explicar(ex));
                        // Si falla el servidor (no la dirección del cliente), no seguir intentándolo
                        if (ex is System.Net.Mail.SmtpException && enviadas == 0 && errores.Count >= 2) break;
                    }
                    Application.DoEvents();
                }
            }
            finally
            {
                espera.Close();
                Cursor.Current = cursor;
            }

            string resumen = enviadas + (enviadas == 1 ? " factura enviada" : " facturas enviadas") + " por correo.";
            if (errores.Count > 0)
            {
                resumen += "\n\nNo se han podido enviar:\n" + string.Join("\n", errores.Take(12)) +
                           (errores.Count > 12 ? "\n..." : "") +
                           "\n\nSe pueden volver a enviar desde Gestión de facturas.";
            }
            MessageBox.Show(ventana, resumen, "Envío por correo", MessageBoxButtons.OK,
                errores.Count > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            return enviadas;
        }

        private static string Descripcion(decimal id)
        {
            try
            {
                using (var bd = new AdministracionAntonioEntities())
                {
                    var f = bd.Facturas.Find(id);
                    return f == null ? id.ToString() : FacturasUtil.Numero(f) + " " + (f.factnombre ?? "").Trim();
                }
            }
            catch
            {
                return id.ToString();
            }
        }
    }
}
