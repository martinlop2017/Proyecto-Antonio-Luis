using System;
using System.Globalization;
using System.IO;
using System.Linq;
using BaseDatos;

namespace Proyecto_Antonio_Luis.Clases
{
    /// <summary>
    /// Utilidades compartidas para los clientes: carpetas de documentos,
    /// recorte de textos y numeración de códigos.
    /// </summary>
    public static class ClientesUtil
    {
        /// <summary>Carpeta raíz donde cada cliente tiene su carpeta de documentos.</summary>
        public const string CarpetaRaiz = @"C:\ByMartin\Clientes";

        /// <summary>Subcarpetas que se crean para cada cliente nuevo.</summary>
        public static readonly string[] Subcarpetas = { "Escrituras", "Fiscal", "Laboral", "Otros", "Facturacion" };

        /// <summary>
        /// Devuelve la ruta de la carpeta del cliente a partir de su nombre.
        /// Quita espacios sobrantes y cambia por '-' los caracteres que Windows
        /// no admite en nombres de carpeta (/ \ : * ? " &lt; &gt; |).
        /// Usar SIEMPRE esta función para que todos los formularios apunten a la misma carpeta.
        /// </summary>
        public static string CarpetaCliente(string nombre)
        {
            return Path.Combine(CarpetaRaiz, NombreCarpeta(nombre));
        }

        public static string NombreCarpeta(string nombre)
        {
            string limpio = (nombre ?? "").Trim();
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                limpio = limpio.Replace(c, '-');
            }
            // Windows no admite carpetas que terminen en punto o espacio
            limpio = limpio.TrimEnd('.', ' ');
            return limpio.Length == 0 ? "_SinNombre" : limpio;
        }

        /// <summary>Crea la carpeta del cliente y sus subcarpetas si no existen.</summary>
        public static void CrearCarpetas(string nombre)
        {
            string carpeta = CarpetaCliente(nombre);
            foreach (string sub in Subcarpetas)
            {
                Directory.CreateDirectory(Path.Combine(carpeta, sub));
            }
        }

        /// <summary>
        /// Quita espacios de los extremos y corta el texto a la longitud indicada.
        /// Útil para ficheros de banco o contabilidad con campos de ancho fijo.
        /// </summary>
        public static string Recortar(string texto, int longitudMaxima)
        {
            string t = (texto ?? "").Trim();
            return t.Length <= longitudMaxima ? t : t.Substring(0, longitudMaxima).TrimEnd();
        }

        /// <summary>
        /// Texto sin espacios en los extremos. Un campo vacío se guarda como ""
        /// (nunca null), igual que hacía el programa antes, para no romper
        /// ningún formulario que lea esos campos.
        /// </summary>
        public static string Texto(string texto)
        {
            return (texto ?? "").Trim();
        }

        /// <summary>
        /// Convierte un texto a decimal aceptando coma o punto como separador.
        /// Vacío = 0. Devuelve false si no es un número válido.
        /// </summary>
        public static bool LeerDecimal(string texto, out decimal valor)
        {
            string t = (texto ?? "").Trim().Replace(" ", "");
            if (t.Length == 0)
            {
                valor = 0;
                return true;
            }
            // Si hay coma, el punto se considera separador de miles (1.234,56)
            if (t.Contains(","))
            {
                t = t.Replace(".", "").Replace(",", ".");
            }
            return decimal.TryParse(t, NumberStyles.Number, CultureInfo.InvariantCulture, out valor);
        }

        // ------------------------------------------------------------------
        //  Numeración de códigos de cliente
        //  El código forma la subcuenta contable (CtaCliente + código), así que
        //  un código NUNCA se reutiliza aunque se borre el cliente. El último
        //  código usado se guarda en la tabla Contadores (ver script SQL).
        // ------------------------------------------------------------------

        private const string SqlMaximoUsado =
            "SELECT MAX(v) FROM (" +
            " SELECT valor AS v FROM dbo.Contadores WHERE nombre = N'Clientes'" +
            " UNION ALL SELECT ISNULL(MAX(codcliente), 0) FROM dbo.Clientes) t";

        /// <summary>Código que se le dará al próximo cliente (solo para mostrarlo).</summary>
        public static decimal SiguienteCodigoPrevisto(AdministracionAntonioEntities bd)
        {
            decimal maximo = bd.Database.SqlQuery<decimal?>(SqlMaximoUsado).FirstOrDefault() ?? 0;
            return maximo + 1;
        }

        /// <summary>
        /// Reserva y devuelve el siguiente código. Llamar dentro de la misma
        /// transacción en la que se graba el cliente, para que si falla el
        /// guardado no se gaste el número.
        /// </summary>
        public static decimal ReservarSiguienteCodigo(AdministracionAntonioEntities bd)
        {
            var resultado = bd.Database.SqlQuery<decimal>(
                "UPDATE dbo.Contadores SET valor = (" + SqlMaximoUsado + ") + 1 " +
                "OUTPUT inserted.valor WHERE nombre = N'Clientes'").ToList();

            if (resultado.Count == 0)
            {
                throw new InvalidOperationException(
                    "No existe el contador de clientes en la tabla Contadores.\n" +
                    "Ejecuta el script SQL\\2026-10-26_Clientes_ampliar_campos.sql.");
            }
            return resultado[0];
        }
    }
}
