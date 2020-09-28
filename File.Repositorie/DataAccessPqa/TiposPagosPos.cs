using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class TiposPagosPos
    {
        public long IdTipoPago { get; set; }
        public string CodigoTipoPago { get; set; }
        public string NombreTipoPago { get; set; }
        public long IdMoneda { get; set; }
        public long? IdTipoCambio { get; set; }
        public string RegresaCambio { get; set; }
        public string PagoCredito { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiTipoPago { get; set; }
        public string SolicitarDetalleDenominacionesCorte { get; set; }
        public string SolicitarFolio { get; set; }
        public string SolicitarReferencia { get; set; }
        public string SolicitarNumeroCuentaPago { get; set; }
        public string AplicaSoloUnaTransaccion { get; set; }
        public string EsFlotilla { get; set; }
        public byte TipoDocumento { get; set; }
        public byte AplicaParaDevolucion { get; set; }
        public byte GeneraFolio { get; set; }
        public string EsApartado { get; set; }
        public byte TipoContable { get; set; }
        public byte Oblf { get; set; }
        public byte? TipoPagoInterno { get; set; }
        public byte Orden { get; set; }
        public string SolicitarSerie { get; set; }
        public byte? Clasificacion { get; set; }
        public byte? PagoEnLinea { get; set; }
        public long? IdBancoPagoEnLinea { get; set; }
    }
}
