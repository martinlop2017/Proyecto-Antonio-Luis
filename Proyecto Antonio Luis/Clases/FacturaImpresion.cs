namespace Proyecto_Antonio_Luis.Clases
{
    /// <summary>Datos de cabecera para el informe ReportFactura.rdlc (conjunto "Factura").</summary>
    public class FacturaImpresion
    {
        public string EmisorNombre { get; set; }
        public string EmisorNif { get; set; }
        public string EmisorDireccion { get; set; }
        public string EmisorPoblacion { get; set; }
        public string EmisorContacto { get; set; }
        public byte[] Logo { get; set; }

        public string Numero { get; set; }
        public string Fecha { get; set; }

        public string ClienteNombre { get; set; }
        public string ClienteNif { get; set; }
        public string ClienteDireccion { get; set; }
        public string ClientePoblacion { get; set; }

        public decimal BaseImponible { get; set; }
        public decimal CuotaIva { get; set; }
        public decimal CuotaRecargo { get; set; }
        public decimal TotalFactura { get; set; }
        public decimal Retencion { get; set; }
        public decimal Suplidos { get; set; }
        public decimal TotalAPagar { get; set; }

        public string FormaPago { get; set; }
    }

    /// <summary>Línea de factura para el informe (conjunto "Lineas").</summary>
    public class LineaImpresion
    {
        public decimal Cantidad { get; set; }
        public string Concepto { get; set; }
        public decimal Precio { get; set; }
        public string Iva { get; set; }
        public decimal Importe { get; set; }
    }

    /// <summary>Desglose por tipo de IVA para el informe (conjunto "Desglose").</summary>
    public class DesgloseImpresion
    {
        public decimal Base { get; set; }
        public decimal TipoIva { get; set; }
        public decimal CuotaIva { get; set; }
        public decimal TipoRecargo { get; set; }
        public decimal CuotaRecargo { get; set; }
    }

    /// <summary>Fila del cuadro de totales del informe (conjunto "Totales").</summary>
    public class TotalImpresion
    {
        public string Concepto { get; set; }
        public decimal Importe { get; set; }
        /// <summary>True para la fila "TOTAL A PAGAR" (en negrita).</summary>
        public bool Destacado { get; set; }
    }
}
