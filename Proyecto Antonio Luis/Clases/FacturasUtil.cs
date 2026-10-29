using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using BaseDatos;
using Microsoft.Reporting.WinForms;

namespace Proyecto_Antonio_Luis.Clases
{
    /// <summary>Una línea de factura mientras se edita (antes de grabarla).</summary>
    public class LineaFactura
    {
        public decimal Cantidad { get; set; }
        public string Concepto { get; set; }
        public decimal Precio { get; set; }
        /// <summary>True = suplido / provisión de fondos (sin IVA).</summary>
        public bool Suplido { get; set; }
        public decimal TipoIva { get; set; }
        public decimal TipoRecargo { get; set; }

        public decimal Importe
        {
            get { return Math.Round(Cantidad * Precio, 2, MidpointRounding.AwayFromZero); }
        }
    }

    /// <summary>Base y cuotas de un tipo de IVA.</summary>
    public class DesgloseIva
    {
        public decimal TipoIva { get; set; }
        public decimal TipoRecargo { get; set; }
        public decimal Base { get; set; }
        public decimal CuotaIva { get; set; }
        public decimal CuotaRecargo { get; set; }
    }

    /// <summary>Totales de una factura.</summary>
    public class TotalesFactura
    {
        public List<DesgloseIva> Desglose { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal CuotaIva { get; set; }
        public decimal CuotaRecargo { get; set; }
        /// <summary>Suplidos / provisión de fondos (base no sujeta).</summary>
        public decimal Suplidos { get; set; }
        public decimal Retencion { get; set; }

        /// <summary>Base + IVA + recargo.</summary>
        public decimal TotalFactura
        {
            get { return BaseImponible + CuotaIva + CuotaRecargo; }
        }

        /// <summary>Lo que paga el cliente: total factura − retención + suplidos.</summary>
        public decimal TotalAPagar
        {
            get { return TotalFactura - Retencion + Suplidos; }
        }
    }

    /// <summary>Datos del cliente que se copian en la factura.</summary>
    public class DatosClienteFactura
    {
        /// <summary>Código del cliente, o null si es un cliente ocasional.</summary>
        public decimal? Codigo { get; set; }
        public string Nombre { get; set; }
        public string Nif { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string CodigoPostal { get; set; }
        public string Mail { get; set; }
        public bool PorMail { get; set; }
        public string Iban { get; set; }
        public bool Domiciliar { get; set; }
        public bool Contabilizar { get; set; }
        public bool RecargoEquivalencia { get; set; }
    }

    /// <summary>
    /// Numeración, cálculo, grabación e impresión de facturas.
    ///
    /// Series: M = facturación mensual, D = facturas directas, R = rectificativas.
    /// Cada serie numera desde 1 cada año (ejercicio). Las facturas no se
    /// borran ni se modifican una vez emitidas.
    /// </summary>
    public static class FacturasUtil
    {
        public const string SerieMensual = "M";
        public const string SerieDirecta = "D";
        public const string SerieRectificativa = "R";

        /// <summary>Código que se usaba para los clientes no dados de alta.</summary>
        public const decimal CodigoClienteOcasional = 9999999999m;

        private static readonly CultureInfo Es = new CultureInfo("es-ES");

        // =====================================================================
        //  Numeración
        // =====================================================================

        /// <summary>Número completo para mostrar e imprimir: D-2026/0007.</summary>
        public static string Numero(string serie, int? ejercicio, decimal? numero)
        {
            string n = numero.HasValue ? numero.Value.ToString("0000") : "?";
            if (string.IsNullOrWhiteSpace(serie) || !ejercicio.HasValue)
            {
                return n;
            }
            return serie.Trim() + "-" + ejercicio.Value + "/" + n;
        }

        public static string Numero(Facturas f)
        {
            return Numero(f.factserie, f.factejercicio, f.factnumerofact);
        }

        /// <summary>Número válido para un nombre de fichero: D-2026-0007.</summary>
        public static string NumeroFichero(Facturas f)
        {
            return Numero(f).Replace("/", "-");
        }

        /// <summary>Siguiente número libre de una serie en un año.</summary>
        public static decimal SiguienteNumero(AdministracionAntonioEntities bd, string serie, int ejercicio)
        {
            decimal? ultimo = bd.Facturas
                .Where(f => f.factserie == serie && f.factejercicio == ejercicio)
                .Max(f => f.factnumerofact);
            return (ultimo ?? 0) + 1;
        }

        // =====================================================================
        //  Cálculo
        // =====================================================================

        public static TotalesFactura Calcular(IEnumerable<LineaFactura> lineas)
        {
            var lista = lineas.ToList();
            var desglose = lista
                .Where(l => !l.Suplido)
                .GroupBy(l => new { l.TipoIva, l.TipoRecargo })
                .OrderByDescending(g => g.Key.TipoIva)
                .Select(g =>
                {
                    decimal b = g.Sum(l => l.Importe);
                    return new DesgloseIva
                    {
                        TipoIva = g.Key.TipoIva,
                        TipoRecargo = g.Key.TipoRecargo,
                        Base = b,
                        CuotaIva = Math.Round(b * g.Key.TipoIva / 100, 2, MidpointRounding.AwayFromZero),
                        CuotaRecargo = Math.Round(b * g.Key.TipoRecargo / 100, 2, MidpointRounding.AwayFromZero)
                    };
                })
                .ToList();

            return new TotalesFactura
            {
                Desglose = desglose,
                BaseImponible = desglose.Sum(d => d.Base),
                CuotaIva = desglose.Sum(d => d.CuotaIva),
                CuotaRecargo = desglose.Sum(d => d.CuotaRecargo),
                Suplidos = lista.Where(l => l.Suplido).Sum(l => l.Importe),
                Retencion = 0   // fase 2 de retenciones (con la facturación mensual y la contabilidad)
            };
        }

        /// <summary>Tipo de recargo de equivalencia que corresponde a un tipo de IVA (tabla Iva).</summary>
        public static decimal RecargoDeTipo(AdministracionAntonioEntities bd, decimal tipoIva)
        {
            var iva = bd.Iva.AsNoTracking().FirstOrDefault(i => i.ivaporciento == tipoIva);
            return iva != null && iva.ivarecargo.HasValue ? iva.ivarecargo.Value : 0;
        }

        // =====================================================================
        //  Grabar una factura directa (serie D)
        // =====================================================================

        /// <summary>
        /// Graba una factura directa con sus líneas y devuelve su identificador
        /// (factcontador). El número se asigna aquí, dentro de una transacción.
        /// </summary>
        public static decimal GrabarDirecta(DatosClienteFactura cliente, DateTime fecha, IList<LineaFactura> lineas)
        {
            var totales = Calcular(lineas);
            int ejercicio = fecha.Year;

            using (var bd = new AdministracionAntonioEntities())
            using (var transaccion = bd.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                var f = new Facturas();

                f.factserie = SerieDirecta;
                f.factorigen = SerieDirecta;
                f.factejercicio = ejercicio;
                f.factnumerofact = SiguienteNumero(bd, SerieDirecta, ejercicio);
                f.factfechadoc = fecha.Date;
                f.factfecha = fecha.ToString("dd/MM/yyyy");
                f.factestado = "Emitida";
                f.factremesa = "Directa " + Numero(SerieDirecta, ejercicio, f.factnumerofact);

                // Cliente (copia de sus datos en la factura)
                f.factcodcliente = cliente.Codigo ?? CodigoClienteOcasional;
                f.factnombre = ClientesUtil.Recortar(cliente.Nombre, 150);
                f.factnif = ClientesUtil.Recortar(cliente.Nif, 20);
                f.factdireccion = ClientesUtil.Recortar(cliente.Direccion, 150);
                f.factlocalidad = ClientesUtil.Recortar(cliente.Localidad, 100);
                f.factprovincia = ClientesUtil.Recortar(cliente.Provincia, 100);
                f.factcp = ClientesUtil.Recortar(cliente.CodigoPostal, 20);
                f.factmail = ClientesUtil.Recortar(cliente.Mail, 100);
                f.factpormail = cliente.PorMail;
                ClientesUtil.PonerIbanFactura(f, cliente.Iban);

                // Importes nuevos
                f.factbaseimponible = totales.BaseImponible;
                f.factimporterecargo = totales.CuotaRecargo;
                f.factretencion = 0;
                f.factretencionporc = 0;

                // Importes en las columnas antiguas, para que remesas y Contaplus
                // sigan funcionando hasta que se adapten (pasos 4 y 5):
                //   base1 = base imponible, base2 = suplidos, IVA = IVA + recargo,
                //   total = lo que paga el cliente.
                var primeraConIva = lineas.FirstOrDefault(l => !l.Suplido);
                var primerSuplido = lineas.FirstOrDefault(l => l.Suplido);
                f.factconcepto1 = ClientesUtil.Recortar(primeraConIva != null ? primeraConIva.Concepto : "", 150);
                f.factbase1 = totales.BaseImponible;
                f.factconcepto2 = ClientesUtil.Recortar(primerSuplido != null ? primerSuplido.Concepto : "", 150);
                f.factbase2 = totales.Suplidos;
                f.factemleados = 0;
                f.factprecioempleado = 0;
                f.factbaseempleado = 0;
                f.facttipoiva = totales.Desglose.Count > 0 ? totales.Desglose[0].TipoIva : 0;
                f.factimporteiva = totales.CuotaIva + totales.CuotaRecargo;
                f.facttotalfactura = totales.TotalAPagar;

                // Estado
                f.factpara_imprimir = !cliente.PorMail;
                f.factimpresa = false;
                f.factparacontabilizar = cliente.Contabilizar;
                f.factcontabilizada = false;
                f.factparadomiciliar = false;   // las facturas directas se cobran en efectivo
                f.factdomiciliada = false;

                bd.Facturas.Add(f);
                bd.SaveChanges();

                int orden = 1;
                foreach (var l in lineas)
                {
                    bd.FacturaLineas.Add(new FacturaLineas
                    {
                        factcontador = f.factcontador,
                        orden = orden++,
                        concepto = ClientesUtil.Recortar(l.Concepto, 250),
                        cantidad = l.Cantidad,
                        precio = l.Precio,
                        importe = l.Importe,
                        sujetoiva = !l.Suplido,
                        tipoiva = l.Suplido ? (decimal?)null : l.TipoIva,
                        tiporecargo = l.Suplido ? 0 : l.TipoRecargo
                    });
                }
                bd.SaveChanges();
                transaccion.Commit();
                return f.factcontador;
            }
        }

        // =====================================================================
        //  Leer una factura grabada (para verla o imprimirla)
        // =====================================================================

        /// <summary>
        /// Líneas de una factura. Si no tiene líneas guardadas (facturas mensuales
        /// hechas antes del cambio), se montan a partir de sus importes.
        /// </summary>
        public static List<LineaFactura> LineasDe(AdministracionAntonioEntities bd, Facturas f)
        {
            var guardadas = bd.FacturaLineas.AsNoTracking()
                .Where(l => l.factcontador == f.factcontador)
                .OrderBy(l => l.orden)
                .ToList();

            decimal tipoFactura = f.facttipoiva ?? 0;

            if (guardadas.Count > 0)
            {
                return guardadas.Select(l => new LineaFactura
                {
                    Cantidad = l.cantidad,
                    Concepto = l.concepto,
                    Precio = l.cantidad != 0 && l.importe != l.precio * l.cantidad ? l.importe / l.cantidad : l.precio,
                    Suplido = !l.sujetoiva,
                    TipoIva = l.sujetoiva ? (l.tipoiva ?? tipoFactura) : 0,
                    TipoRecargo = l.tiporecargo ?? 0
                }).ToList();
            }

            var lineas = new List<LineaFactura>();
            if ((f.factbase1 ?? 0) != 0)
                lineas.Add(new LineaFactura { Cantidad = 1, Concepto = Limpio(f.factconcepto1, "Honorarios"), Precio = f.factbase1.Value, TipoIva = tipoFactura });
            if ((f.factbaseempleado ?? 0) != 0)
                lineas.Add(new LineaFactura
                {
                    Cantidad = (f.factemleados ?? 0) == 0 ? 1 : f.factemleados.Value,
                    Concepto = "Nóminas",
                    Precio = (f.factemleados ?? 0) == 0 ? f.factbaseempleado.Value : (f.factprecioempleado ?? 0),
                    TipoIva = tipoFactura
                });
            if ((f.factbase2 ?? 0) != 0)
                lineas.Add(new LineaFactura { Cantidad = 1, Concepto = Limpio(f.factconcepto2, "Suplidos"), Precio = f.factbase2.Value, Suplido = true });
            return lineas;
        }

        // =====================================================================
        //  Imprimir (PDF)
        // =====================================================================

        /// <summary>
        /// Genera el PDF de la factura en la carpeta del cliente
        /// (C:\ByMartin\Clientes\&lt;nombre&gt;\Facturacion&lt;año&gt;) y la marca como impresa.
        /// Devuelve la ruta del PDF.
        /// </summary>
        public static string GenerarPdf(decimal factcontador, bool abrir)
        {
            using (var bd = new AdministracionAntonioEntities())
            {
                var f = bd.Facturas.Find(factcontador);
                if (f == null)
                {
                    throw new InvalidOperationException("La factura no existe.");
                }

                var lineas = LineasDe(bd, f);
                var totales = Calcular(lineas);
                var mios = ClientesUtil.BuscarMisDatos(bd);

                var cabecera = new FacturaImpresion
                {
                    EmisorNombre = mios != null ? Limpio(mios.minombre, "") : "",
                    EmisorNif = mios != null ? "NIF: " + Limpio(mios.micif, "") : "",
                    EmisorDireccion = mios != null ? Limpio(mios.midireccion, "") : "",
                    EmisorPoblacion = mios != null ? Unir(" - ", Limpio(mios.micp, ""), Limpio(mios.mipoblacion, ""), Parentesis(mios.miprovincia)) : "",
                    EmisorContacto = mios != null ? Unir(" - ", Prefijo("Tlf. ", mios.mitelefono1), Limpio(mios.mimail, "")) : "",
                    Logo = LogoPng(mios),

                    Numero = Numero(f),
                    Fecha = f.factfechadoc.HasValue ? f.factfechadoc.Value.ToString("dd/MM/yyyy") : Limpio(f.factfecha, ""),

                    ClienteNombre = Limpio(f.factnombre, ""),
                    ClienteNif = Prefijo("NIF: ", f.factnif),
                    ClienteDireccion = Limpio(f.factdireccion, ""),
                    ClientePoblacion = Unir(" - ", Limpio(f.factcp, ""), Limpio(f.factlocalidad, ""), Parentesis(f.factprovincia)),

                    BaseImponible = totales.BaseImponible,
                    CuotaIva = totales.CuotaIva,
                    CuotaRecargo = totales.CuotaRecargo,
                    TotalFactura = totales.TotalFactura,
                    Retencion = f.factretencion ?? 0,
                    Suplidos = totales.Suplidos,
                    TotalAPagar = totales.TotalFactura - (f.factretencion ?? 0) + totales.Suplidos,

                    FormaPago = FormaPago(f, mios)
                };

                var lineasImp = lineas.Select(l => new LineaImpresion
                {
                    Cantidad = l.Cantidad,
                    Concepto = l.Concepto,
                    Precio = l.Precio,
                    Iva = l.Suplido ? "Suplido" : l.TipoIva.ToString("0.##", Es) + " %",
                    Importe = l.Importe
                }).ToList();

                var desgloseImp = totales.Desglose.Select(d => new DesgloseImpresion
                {
                    Base = d.Base,
                    TipoIva = d.TipoIva,
                    CuotaIva = d.CuotaIva,
                    TipoRecargo = d.TipoRecargo,
                    CuotaRecargo = d.CuotaRecargo
                }).ToList();

                var totalesImp = new List<TotalImpresion>();
                totalesImp.Add(new TotalImpresion { Concepto = "Base imponible", Importe = cabecera.BaseImponible });
                totalesImp.Add(new TotalImpresion { Concepto = "IVA", Importe = cabecera.CuotaIva });
                if (cabecera.CuotaRecargo != 0)
                    totalesImp.Add(new TotalImpresion { Concepto = "Recargo de equivalencia", Importe = cabecera.CuotaRecargo });
                if (cabecera.Retencion != 0 || cabecera.Suplidos != 0)
                    totalesImp.Add(new TotalImpresion { Concepto = "Total factura", Importe = cabecera.TotalFactura });
                if (cabecera.Retencion != 0)
                    totalesImp.Add(new TotalImpresion { Concepto = "Retención IRPF", Importe = -cabecera.Retencion });
                if (cabecera.Suplidos != 0)
                    totalesImp.Add(new TotalImpresion { Concepto = "Suplidos (provisión de fondos)", Importe = cabecera.Suplidos });
                totalesImp.Add(new TotalImpresion { Concepto = "TOTAL A PAGAR", Importe = cabecera.TotalAPagar, Destacado = true });

                byte[] pdf;
                using (var informe = new LocalReport())
                {
                    informe.ReportEmbeddedResource = "Proyecto_Antonio_Luis.Formularios.ReportFactura.rdlc";
                    informe.DataSources.Add(new ReportDataSource("Factura", new List<FacturaImpresion> { cabecera }));
                    informe.DataSources.Add(new ReportDataSource("Lineas", lineasImp));
                    informe.DataSources.Add(new ReportDataSource("Desglose", desgloseImp));
                    informe.DataSources.Add(new ReportDataSource("Totales", totalesImp));
                    pdf = informe.Render("PDF");
                }

                int año = f.factejercicio ?? (f.factfechadoc.HasValue ? f.factfechadoc.Value.Year : DateTime.Today.Year);
                string carpeta = Path.Combine(ClientesUtil.CarpetaCliente(f.factnombre), "Facturacion" + año);
                Directory.CreateDirectory(carpeta);
                string ruta = Path.Combine(carpeta, "Factura " + NumeroFichero(f) + ".pdf");
                File.WriteAllBytes(ruta, pdf);

                f.factimpresa = true;
                bd.SaveChanges();

                if (abrir)
                {
                    Process.Start(ruta);
                }
                return ruta;
            }
        }

        private static string FormaPago(Facturas f, Propios mios)
        {
            string ibanCliente = ClientesUtil.IbanFactura(f);
            if (f.factparadomiciliar == true && ibanCliente.Length > 4)
            {
                return "Domiciliación bancaria en la cuenta terminada en " + ibanCliente.Substring(ibanCliente.Length - 4);
            }
            if ((f.factserie ?? "").Trim() == SerieDirecta)
            {
                return "Pago en efectivo";
            }
            string miIban = ClientesUtil.IbanPropio(mios);
            return miIban.Length > 0
                ? "Transferencia a la cuenta " + ClientesUtil.FormatearIban(miIban)
                : "";
        }

        /// <summary>Logo de Mis Datos (o el del programa) convertido a PNG para el informe.</summary>
        private static byte[] LogoPng(Propios mios)
        {
            try
            {
                Image imagen = null;
                if (mios != null && mios.milogoimagen != null && mios.milogoimagen.Length > 0)
                {
                    using (var flujo = new MemoryStream(mios.milogoimagen))
                    using (var original = Image.FromStream(flujo))
                    {
                        imagen = new Bitmap(original);
                    }
                }
                if (imagen == null)
                {
                    imagen = Properties.Resources.Logo_Antonio_Luis;
                }
                using (imagen)
                using (var salida = new MemoryStream())
                {
                    imagen.Save(salida, ImageFormat.Png);
                    return salida.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }

        // =====================================================================
        //  Utilidades de texto
        // =====================================================================

        private static string Limpio(string texto, string siVacio)
        {
            string t = (texto ?? "").Trim();
            return t.Length == 0 ? siVacio : t;
        }

        private static string Prefijo(string prefijo, string texto)
        {
            string t = (texto ?? "").Trim();
            return t.Length == 0 ? "" : prefijo + t;
        }

        private static string Parentesis(string texto)
        {
            string t = (texto ?? "").Trim();
            return t.Length == 0 ? "" : "(" + t + ")";
        }

        private static string Unir(string separador, params string[] partes)
        {
            return string.Join(separador, partes.Where(p => !string.IsNullOrWhiteSpace(p)));
        }
    }
}
