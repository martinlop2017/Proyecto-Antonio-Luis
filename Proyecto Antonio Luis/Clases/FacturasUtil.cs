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
        /// <summary>% de retención de IRPF a aplicar (0 = sin retención).</summary>
        public decimal PorcRetencion { get; set; }
    }

    /// <summary>Una factura de la facturación mensual, antes de grabarla.</summary>
    public class FacturaMensualNueva
    {
        public DatosClienteFactura Cliente { get; set; }
        public List<LineaFactura> Lineas { get; set; }
        /// <summary>Honorarios fiscales y contables (tarifa del cliente).</summary>
        public decimal Honorarios { get; set; }
        public decimal Empleados { get; set; }
        public decimal PrecioEmpleado { get; set; }
        public decimal Laboral { get; set; }
        public decimal Suplidos { get; set; }
        public string ConceptoSuplido { get; set; }
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

        /// <summary>
        /// Calcula base, IVA (por tipo), suplidos y retención de IRPF.
        /// La retención se aplica sobre la base imponible (los suplidos no retienen).
        /// </summary>
        public static TotalesFactura Calcular(IEnumerable<LineaFactura> lineas, decimal porcRetencion = 0)
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

            decimal baseImponible = desglose.Sum(d => d.Base);
            return new TotalesFactura
            {
                Desglose = desglose,
                BaseImponible = baseImponible,
                CuotaIva = desglose.Sum(d => d.CuotaIva),
                CuotaRecargo = desglose.Sum(d => d.CuotaRecargo),
                Suplidos = lista.Where(l => l.Suplido).Sum(l => l.Importe),
                Retencion = porcRetencion > 0
                    ? Math.Round(baseImponible * porcRetencion / 100, 2, MidpointRounding.AwayFromZero)
                    : 0
            };
        }

        /// <summary>
        /// % de retención de IRPF que se aplica a los clientes con "Retención IRPF":
        /// el marcado como "por defecto" en la tabla Retenciones (General, 15 %).
        /// </summary>
        public static decimal PorcentajeRetencion(AdministracionAntonioEntities bd)
        {
            var r = bd.Retenciones.AsNoTracking().FirstOrDefault(x => x.retpordefecto)
                 ?? bd.Retenciones.AsNoTracking().OrderBy(x => x.numerador).FirstOrDefault();
            return r != null ? r.retporciento : 15m;
        }

        // =====================================================================
        //  Grabar
        // =====================================================================

        /// <summary>
        /// Monta una factura con los datos comunes (cliente, importes, estado).
        /// No la añade a la base de datos.
        /// </summary>
        private static Facturas MontarFactura(string serie, int ejercicio, decimal numero, DateTime fecha,
            DatosClienteFactura cliente, IList<LineaFactura> lineas, TotalesFactura totales, decimal porcRetencion)
        {
            var f = new Facturas();

            f.factserie = serie;
            f.factorigen = serie;
            f.factejercicio = ejercicio;
            f.factnumerofact = numero;
            f.factfechadoc = fecha.Date;
            f.factfecha = fecha.ToString("dd/MM/yyyy");
            f.factestado = "Emitida";

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
            f.factretencionporc = totales.Retencion != 0 ? porcRetencion : 0;
            f.factretencion = totales.Retencion;

            // Importes en las columnas antiguas, para que remesas y Contaplus
            // sigan funcionando hasta que se adapten (pasos 4 y 5):
            //   base1 = base imponible, base2 = suplidos, IVA = IVA + recargo,
            //   total = lo que paga el cliente (con la retención ya descontada).
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
            f.factparadomiciliar = cliente.Domiciliar;
            f.factdomiciliada = false;
            return f;
        }

        private static void GrabarLineas(AdministracionAntonioEntities bd, decimal factcontador, IList<LineaFactura> lineas)
        {
            int orden = 1;
            foreach (var l in lineas)
            {
                bd.FacturaLineas.Add(new FacturaLineas
                {
                    factcontador = factcontador,
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
        }

        /// <summary>
        /// Graba una factura directa (serie D) con sus líneas y devuelve su
        /// identificador (factcontador). El número se asigna aquí, dentro de una
        /// transacción. Las facturas directas se cobran en efectivo: nunca se
        /// domicilian.
        /// </summary>
        public static decimal GrabarDirecta(DatosClienteFactura cliente, DateTime fecha, IList<LineaFactura> lineas)
        {
            var totales = Calcular(lineas, cliente.PorcRetencion);
            int ejercicio = fecha.Year;

            using (var bd = new AdministracionAntonioEntities())
            using (var transaccion = bd.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                cliente.Domiciliar = false;
                cliente.Iban = "";
                decimal numero = SiguienteNumero(bd, SerieDirecta, ejercicio);
                var f = MontarFactura(SerieDirecta, ejercicio, numero, fecha, cliente, lineas, totales, cliente.PorcRetencion);
                f.factremesa = "Directa " + Numero(SerieDirecta, ejercicio, numero);

                bd.Facturas.Add(f);
                bd.SaveChanges();
                GrabarLineas(bd, f.factcontador, lineas);
                bd.SaveChanges();
                transaccion.Commit();
                return f.factcontador;
            }
        }

        /// <summary>Clientes que ya tienen factura mensual en esa remesa.</summary>
        public static HashSet<decimal> ClientesYaFacturados(AdministracionAntonioEntities bd, string remesa)
        {
            return new HashSet<decimal>(bd.Facturas
                .Where(f => f.factserie == SerieMensual && f.factremesa == remesa && f.factcodcliente != null)
                .Select(f => f.factcodcliente.Value)
                .ToList());
        }

        /// <summary>
        /// Graba todas las facturas de la facturación mensual (serie M) en una sola
        /// transacción: o se graban todas, o ninguna. Las añade a la remesa del
        /// mes (la crea si no existe) y actualiza su total.
        /// Devuelve los identificadores (factcontador) de las facturas grabadas.
        /// </summary>
        public static List<decimal> GrabarMensual(string remesa, int añoRemesa, DateTime fecha, IList<FacturaMensualNueva> facturas)
        {
            int ejercicio = fecha.Year;
            var ids = new List<decimal>();

            using (var bd = new AdministracionAntonioEntities())
            using (var transaccion = bd.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                // Nadie puede tener ya factura en esta remesa
                var yaFacturados = ClientesYaFacturados(bd, remesa);
                var repetido = facturas.FirstOrDefault(x => x.Cliente.Codigo.HasValue && yaFacturados.Contains(x.Cliente.Codigo.Value));
                if (repetido != null)
                {
                    throw new InvalidOperationException(repetido.Cliente.Nombre.Trim() + " ya tiene factura en la remesa " + remesa + ".");
                }

                // Remesa del mes: se reutiliza si ya existe
                var r = bd.Resilla.FirstOrDefault(x => x.remesanumero == remesa);
                if (r == null)
                {
                    r = new Resilla
                    {
                        remesanumero = remesa,
                        remesafecha = fecha.ToString("dd/MM/yyyy"),
                        remesafechacargo = fecha.Date,
                        remesaejercicio = añoRemesa,
                        remesatotal = 0,
                        remesacontabilizada = false
                    };
                    bd.Resilla.Add(r);
                    bd.SaveChanges();
                }

                decimal numero = SiguienteNumero(bd, SerieMensual, ejercicio);
                var nuevas = new List<Facturas>();
                foreach (var x in facturas)
                {
                    var totales = Calcular(x.Lineas, x.Cliente.PorcRetencion);
                    var f = MontarFactura(SerieMensual, ejercicio, numero++, fecha, x.Cliente, x.Lineas, totales, x.Cliente.PorcRetencion);
                    f.factremesa = remesa;
                    f.factremesaid = r.remesanumerador;

                    // Columnas antiguas con el desglose de la mensual (Contaplus, remesas)
                    f.factbase1 = x.Honorarios;
                    f.factemleados = x.Empleados;
                    f.factprecioempleado = x.PrecioEmpleado;
                    f.factbaseempleado = x.Laboral;
                    f.factbase2 = x.Suplidos;
                    f.factconcepto2 = ClientesUtil.Recortar(x.Suplidos != 0 ? x.ConceptoSuplido : "", 150);

                    bd.Facturas.Add(f);
                    bd.SaveChanges();
                    GrabarLineas(bd, f.factcontador, x.Lineas);
                    nuevas.Add(f);
                    ids.Add(f.factcontador);
                }
                bd.SaveChanges();

                // Total de la remesa (todas sus facturas, también las de antes)
                decimal total = bd.Facturas.Where(f => f.factremesa == remesa && f.factserie == SerieMensual)
                    .Sum(f => (decimal?)f.facttotalfactura) ?? 0;
                r.remesatotal = total;
                foreach (var f in bd.Facturas.Where(f => f.factremesa == remesa && f.factserie == SerieMensual).ToList())
                {
                    f.facttotalremesa = total;
                }
                bd.SaveChanges();
                transaccion.Commit();
            }
            return ids;
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
                    totalesImp.Add(new TotalImpresion { Concepto = "Retención IRPF" + ((f.factretencionporc ?? 0) != 0 ? " (" + f.factretencionporc.Value.ToString("0.##", Es) + " %)" : ""), Importe = -cabecera.Retencion });
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
