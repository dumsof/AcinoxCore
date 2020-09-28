using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class Cxcabonos
    {
        public long IdRuCxcabono { get; set; }
        public long IdCxccargo { get; set; }
        public short Consecutivo { get; set; }
        public long IdCacxc { get; set; }
        public string ProcedenciaDocumento { get; set; }
        public string ConceptoCxc { get; set; }
        public DateTime FechaAbono { get; set; }
        public long IdMoneda { get; set; }
        public decimal ValorCambio { get; set; }
        public long IdZonaIva { get; set; }
        public long? IdTasaIva { get; set; }
        public decimal PorcentajeIva { get; set; }
        public decimal Importe { get; set; }
        public decimal Iva { get; set; }
        public decimal RetencionIsr { get; set; }
        public decimal RetencionIva { get; set; }
        public decimal Ttotal { get; set; }
        public string Observaciones { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiCxcabono { get; set; }
        public decimal RetencionIeps { get; set; }
        public decimal Ieps { get; set; }
        public long? IdCxccargoFactura { get; set; }
        public long? IdRuCxcabonoFactura { get; set; }
        public long? IdCfd { get; set; }
        public byte EsCancelacion { get; set; }
        public byte? Bloqueado { get; set; }
        public decimal? Ish { get; set; }
        public decimal? PorcentajeIsh { get; set; }
    }
}
