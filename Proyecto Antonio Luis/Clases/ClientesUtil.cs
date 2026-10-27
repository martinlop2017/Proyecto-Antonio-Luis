using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
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
        //  IBAN
        //  Desde el 27-10-2026 el IBAN se guarda completo (hasta 34 caracteres)
        //  en Clientes.ibancliente y Facturas.factiban. Las columnas antiguas de
        //  4 en 4 (iban1..iban6) se conservan y se siguen rellenando cuando el
        //  IBAN cabe en ellas (24 caracteres, como los españoles).
        // ------------------------------------------------------------------

        public const int IbanLongitudMaxima = 34;

        /// <summary>IBAN sin espacios ni guiones y en mayúsculas.</summary>
        public static string NormalizarIban(string iban)
        {
            var sb = new StringBuilder();
            foreach (char ch in (iban ?? ""))
            {
                if (char.IsLetterOrDigit(ch))
                {
                    sb.Append(char.ToUpperInvariant(ch));
                }
            }
            return sb.ToString();
        }

        /// <summary>IBAN en grupos de 4 para mostrarlo: ES12 3456 7890 ...</summary>
        public static string FormatearIban(string iban)
        {
            string limpio = NormalizarIban(iban);
            var sb = new StringBuilder();
            for (int i = 0; i < limpio.Length; i++)
            {
                if (i > 0 && i % 4 == 0) sb.Append(' ');
                sb.Append(limpio[i]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Comprueba un IBAN de cualquier país (ISO 13616): 2 letras de país,
        /// 2 dígitos de control, entre 15 y 34 caracteres y resto módulo 97 = 1.
        /// Los IBAN españoles deben tener exactamente 24 caracteres.
        /// </summary>
        public static bool IbanValido(string iban, out string motivo)
        {
            string t = NormalizarIban(iban);
            motivo = null;

            if (t.Length < 15 || t.Length > IbanLongitudMaxima)
            {
                motivo = "debe tener entre 15 y 34 caracteres (tiene " + t.Length + ")";
                return false;
            }
            if (!char.IsLetter(t[0]) || !char.IsLetter(t[1]) || !char.IsDigit(t[2]) || !char.IsDigit(t[3]))
            {
                motivo = "debe empezar por el código del país y dos dígitos (por ejemplo ES12)";
                return false;
            }
            if (t.StartsWith("ES") && t.Length != 24)
            {
                motivo = "un IBAN español tiene 24 caracteres (tiene " + t.Length + ")";
                return false;
            }

            // Se pasan los 4 primeros al final, las letras a números (A=10 ... Z=35)
            // y se calcula el resto entre 97 cifra a cifra.
            string reordenado = t.Substring(4) + t.Substring(0, 4);
            int resto = 0;
            foreach (char ch in reordenado)
            {
                string cifras = char.IsLetter(ch) ? (ch - 'A' + 10).ToString() : ch.ToString();
                foreach (char d in cifras)
                {
                    resto = (resto * 10 + (d - '0')) % 97;
                }
            }
            if (resto != 1)
            {
                motivo = "los dígitos de control no cuadran (revisa que no falte o sobre ningún número)";
                return false;
            }
            return true;
        }

        /// <summary>Une los 6 bloques antiguos de 4 caracteres.</summary>
        public static string IbanDeBloques(params string[] bloques)
        {
            return NormalizarIban(string.Concat(bloques ?? new string[0]));
        }

        /// <summary>
        /// Parte el IBAN en 6 bloques de 4 para las columnas antiguas.
        /// Si no cabe (más de 24 caracteres) devuelve los 6 bloques vacíos,
        /// para no guardar un IBAN cortado.
        /// </summary>
        public static string[] BloquesIban(string iban)
        {
            string t = NormalizarIban(iban);
            var bloques = new string[6];
            for (int i = 0; i < 6; i++)
            {
                int inicio = i * 4;
                bloques[i] = (t.Length > 24 || inicio >= t.Length)
                    ? ""
                    : t.Substring(inicio, Math.Min(4, t.Length - inicio));
            }
            return bloques;
        }

        /// <summary>IBAN del cliente: la columna nueva y, si está vacía, los bloques antiguos.</summary>
        public static string IbanCliente(Clientes c)
        {
            if (c == null) return "";
            string iban = NormalizarIban(c.ibancliente);
            return iban.Length > 0
                ? iban
                : IbanDeBloques(c.iban1cliente, c.iban2cliente, c.iban3cliente,
                                c.iban4cliente, c.iban5cliente, c.iban6cliente);
        }

        /// <summary>IBAN de la factura: la columna nueva y, si está vacía (facturas antiguas), los bloques.</summary>
        public static string IbanFactura(Facturas f)
        {
            if (f == null) return "";
            string iban = NormalizarIban(f.factiban);
            return iban.Length > 0
                ? iban
                : IbanDeBloques(f.factiban1, f.factiban2, f.factiban3,
                                f.factiban4, f.factiban5, f.factiban6);
        }

        /// <summary>Guarda el IBAN en la factura: columna nueva + bloques antiguos.</summary>
        public static void PonerIbanFactura(Facturas f, string iban)
        {
            string t = NormalizarIban(iban);
            string[] b = BloquesIban(t);
            f.factiban = t;
            f.factiban1 = b[0];
            f.factiban2 = b[1];
            f.factiban3 = b[2];
            f.factiban4 = b[3];
            f.factiban5 = b[4];
            f.factiban6 = b[5];
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
