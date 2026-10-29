using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using BaseDatos;

namespace Proyecto_Antonio_Luis.Clases
{
    /// <summary>Configuración del correo de salida (se guarda en Mis Datos, tabla Propios).</summary>
    public class ConfigCorreo
    {
        public string Servidor { get; set; }
        public int Puerto { get; set; }
        /// <summary>True = conexión cifrada (STARTTLS, normalmente puerto 587).</summary>
        public bool Cifrado { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Remitente { get; set; }
        public string NombreRemitente { get; set; }
        /// <summary>Dirección a la que se manda una copia oculta de cada envío (opcional).</summary>
        public string CopiaOculta { get; set; }
        public string Asunto { get; set; }
        public string Texto { get; set; }
        /// <summary>Pedir confirmación de lectura (el cliente puede no enviarla).</summary>
        public bool AcuseLectura { get; set; }
        /// <summary>Pedir aviso de entrega al servidor del cliente (no todos lo admiten).</summary>
        public bool AcuseEntrega { get; set; }

        /// <summary>Lo mínimo para poder enviar.</summary>
        public bool Completa
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Servidor) && Puerto > 0
                    && !string.IsNullOrWhiteSpace(Remitente);
            }
        }
    }

    /// <summary>
    /// Envío de facturas por correo con el servidor de correo del dominio
    /// propio (SMTP). La contraseña se guarda cifrada con la protección de
    /// datos de Windows (solo se puede leer en este ordenador).
    /// </summary>
    public static class CorreoUtil
    {
        public const string AsuntoPorDefecto = "Factura {numero} - {emisor}";

        public const string TextoPorDefecto =
            "Estimado/a cliente:\r\n\r\n" +
            "Le adjuntamos la factura {numero} de fecha {fecha} por importe de {total}.\r\n\r\n" +
            "Un saludo,\r\n{emisor}";

        private static readonly byte[] Entropia = Encoding.UTF8.GetBytes("eGESTION-Antonio-Luis-correo");
        private static readonly CultureInfo Es = new CultureInfo("es-ES");

        // =====================================================================
        //  Leer y guardar la configuración
        // =====================================================================

        public static ConfigCorreo Leer(AdministracionAntonioEntities bd)
        {
            var p = ClientesUtil.BuscarMisDatos(bd);
            if (p == null) return new ConfigCorreo { Puerto = 587, Cifrado = true, Asunto = AsuntoPorDefecto, Texto = TextoPorDefecto };
            return new ConfigCorreo
            {
                Servidor = (p.mismtpservidor ?? "").Trim(),
                Puerto = p.mismtppuerto ?? 587,
                Cifrado = p.mismtpcifrado ?? true,
                Usuario = (p.mismtpusuario ?? "").Trim(),
                Clave = Descifrar(p.mismtpclave),
                Remitente = (p.mimailremitente ?? "").Trim(),
                NombreRemitente = string.IsNullOrWhiteSpace(p.mimailnombre) ? (p.minombre ?? "").Trim() : p.mimailnombre.Trim(),
                CopiaOculta = (p.mimailcopia ?? "").Trim(),
                Asunto = string.IsNullOrWhiteSpace(p.mimailasunto) ? AsuntoPorDefecto : p.mimailasunto,
                Texto = string.IsNullOrWhiteSpace(p.mimailtexto) ? TextoPorDefecto : p.mimailtexto,
                AcuseLectura = p.mimailacuselectura == true,
                AcuseEntrega = p.mimailacuseentrega == true
            };
        }

        /// <summary>Guarda la configuración en Mis Datos. Devuelve false si todavía no hay Mis Datos.</summary>
        public static bool Guardar(AdministracionAntonioEntities bd, ConfigCorreo c)
        {
            var p = ClientesUtil.BuscarMisDatos(bd);
            if (p == null) return false;
            p.mismtpservidor = ClientesUtil.Recortar(c.Servidor, 150);
            p.mismtppuerto = c.Puerto;
            p.mismtpcifrado = c.Cifrado;
            p.mismtpusuario = ClientesUtil.Recortar(c.Usuario, 150);
            p.mismtpclave = Cifrar(c.Clave);
            p.mimailremitente = ClientesUtil.Recortar(c.Remitente, 150);
            p.mimailnombre = ClientesUtil.Recortar(c.NombreRemitente, 150);
            p.mimailcopia = ClientesUtil.Recortar(c.CopiaOculta, 150);
            p.mimailasunto = ClientesUtil.Recortar(c.Asunto, 250);
            p.mimailtexto = c.Texto ?? "";
            p.mimailacuselectura = c.AcuseLectura;
            p.mimailacuseentrega = c.AcuseEntrega;
            bd.SaveChanges();
            return true;
        }

        private static string Cifrar(string clave)
        {
            if (string.IsNullOrEmpty(clave)) return "";
            byte[] datos = ProtectedData.Protect(Encoding.UTF8.GetBytes(clave), Entropia, DataProtectionScope.LocalMachine);
            return Convert.ToBase64String(datos);
        }

        private static string Descifrar(string guardada)
        {
            if (string.IsNullOrWhiteSpace(guardada)) return "";
            try
            {
                byte[] datos = ProtectedData.Unprotect(Convert.FromBase64String(guardada.Trim()), Entropia, DataProtectionScope.LocalMachine);
                return Encoding.UTF8.GetString(datos);
            }
            catch
            {
                // Guardada en otro ordenador: hay que volver a escribirla
                return "";
            }
        }

        // =====================================================================
        //  Enviar
        // =====================================================================

        /// <summary>Direcciones de un campo de email (separadas por ; o ,).</summary>
        public static List<string> Direcciones(string texto)
        {
            return (texto ?? "")
                .Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(d => d.Trim())
                .Where(d => d.Length > 0)
                .ToList();
        }

        public static bool DireccionValida(string direccion)
        {
            try
            {
                var m = new MailAddress(direccion);
                return m.Address == direccion.Trim() && direccion.Contains(".");
            }
            catch
            {
                return false;
            }
        }

        private static SmtpClient Cliente(ConfigCorreo c)
        {
            // .NET 4.5.2 no activa TLS 1.2 por defecto y casi todos los servidores lo exigen
            ServicePointManager.SecurityProtocol |= (SecurityProtocolType)3072;   // Tls12

            var smtp = new SmtpClient(c.Servidor.Trim(), c.Puerto)
            {
                EnableSsl = c.Cifrado,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Timeout = 60000
            };
            if (!string.IsNullOrWhiteSpace(c.Usuario))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(c.Usuario.Trim(), c.Clave ?? "");
            }
            return smtp;
        }

        private static MailMessage Mensaje(ConfigCorreo c, IEnumerable<string> para, string asunto, string texto)
        {
            var m = new MailMessage
            {
                From = new MailAddress(c.Remitente.Trim(), (c.NombreRemitente ?? "").Trim(), Encoding.UTF8),
                Subject = asunto,
                SubjectEncoding = Encoding.UTF8,
                Body = texto,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = false
            };
            foreach (var d in para) m.To.Add(d);
            if (DireccionValida(c.CopiaOculta ?? "")) m.Bcc.Add(c.CopiaOculta.Trim());

            // Acuses de recibo: llegan al buzón del remitente
            if (c.AcuseLectura)
            {
                m.Headers.Add("Disposition-Notification-To", c.Remitente.Trim());
            }
            if (c.AcuseEntrega)
            {
                m.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess
                                              | DeliveryNotificationOptions.OnFailure
                                              | DeliveryNotificationOptions.Delay;
            }
            else
            {
                m.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            }
            return m;
        }

        /// <summary>Manda un correo de prueba para comprobar la configuración.</summary>
        public static void EnviarPrueba(ConfigCorreo c, string destino)
        {
            using (var smtp = Cliente(c))
            using (var m = Mensaje(c, new[] { destino },
                "Prueba de correo - eGESTION",
                "Este es un mensaje de prueba enviado desde eGESTION.\r\n\r\n" +
                "Si lo recibes, la configuración del correo es correcta y las facturas se podrán enviar."))
            {
                smtp.Send(m);
            }
        }

        /// <summary>
        /// Envía una factura en PDF al email del cliente y la marca como enviada.
        /// Si el PDF no existe, lo crea.
        /// </summary>
        public static void EnviarFactura(ConfigCorreo c, decimal factcontador)
        {
            Facturas f;
            string emisor;
            using (var bd = new AdministracionAntonioEntities())
            {
                f = bd.Facturas.AsNoTracking().FirstOrDefault(x => x.factcontador == factcontador);
                if (f == null) throw new InvalidOperationException("La factura no existe.");
                var mios = ClientesUtil.BuscarMisDatos(bd);
                emisor = mios != null ? (mios.minombre ?? "").Trim() : "";
            }

            var para = Direcciones(f.factmail);
            if (para.Count == 0) throw new InvalidOperationException("El cliente no tiene email.");
            var mal = para.FirstOrDefault(d => !DireccionValida(d));
            if (mal != null) throw new InvalidOperationException("El email \"" + mal + "\" no es válido.");

            string pdf = FacturasUtil.GenerarPdf(factcontador, false);

            var valores = new Dictionary<string, string>
            {
                { "{numero}", FacturasUtil.Numero(f) },
                { "{fecha}", f.factfechadoc.HasValue ? f.factfechadoc.Value.ToString("dd/MM/yyyy") : (f.factfecha ?? "").Trim() },
                { "{total}", (f.facttotalfactura ?? 0).ToString("N2", Es) + " €" },
                { "{cliente}", (f.factnombre ?? "").Trim() },
                { "{emisor}", emisor },
                { "{remesa}", (f.factremesa ?? "").Trim() }
            };
            string asunto = Rellenar(c.Asunto, valores);
            string texto = Rellenar(c.Texto, valores);

            using (var smtp = Cliente(c))
            using (var m = Mensaje(c, para, asunto, texto))
            using (var adjunto = new Attachment(pdf, "application/pdf"))
            {
                adjunto.Name = Path.GetFileName(pdf);
                m.Attachments.Add(adjunto);
                smtp.Send(m);
            }

            using (var bd = new AdministracionAntonioEntities())
            {
                var g = bd.Facturas.Find(factcontador);
                g.factenviada = true;
                g.factfechaenvio = DateTime.Now;
                bd.SaveChanges();
            }
        }

        private static string Rellenar(string plantilla, Dictionary<string, string> valores)
        {
            string r = plantilla ?? "";
            foreach (var v in valores) r = r.Replace(v.Key, v.Value);
            return r;
        }

        /// <summary>Mensaje de error comprensible a partir de una excepción del envío.</summary>
        public static string Explicar(Exception ex)
        {
            var interna = ex;
            while (interna.InnerException != null) interna = interna.InnerException;
            string texto = interna.Message;
            var smtp = ex as SmtpException;
            if (smtp != null && (smtp.StatusCode == SmtpStatusCode.MustIssueStartTlsFirst ||
                                 texto.IndexOf("5.7.0", StringComparison.Ordinal) >= 0))
            {
                texto += "\n(Prueba a marcar \"Conexión cifrada\".)";
            }
            if (texto.IndexOf("authentication", StringComparison.OrdinalIgnoreCase) >= 0 ||
                texto.IndexOf("5.7.8", StringComparison.Ordinal) >= 0 ||
                texto.IndexOf("535", StringComparison.Ordinal) >= 0)
            {
                texto += "\n(Revisa el usuario y la contraseña del correo.)";
            }
            return texto;
        }
    }
}
