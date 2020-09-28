using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class Cxccargos
    {
        public long IdCxccargo { get; set; }
        public long IdRuCxccargo { get; set; }
        public long? IdCxpabono { get; set; }
        public long IdEmpresaSucursal { get; set; }
        public long IdClienteSucursal { get; set; }
        public long? IdCategoriaCliente { get; set; }
        public long? IdContratoDetalle { get; set; }
        public long IdCacxc { get; set; }
        public string ConceptoCxc { get; set; }
        public string SerieDocumento { get; set; }
        public long NumeroDocumento { get; set; }
        public DateTime FechaDocumento { get; set; }
        public long DiasCredito { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public long IdMoneda { get; set; }
        public decimal ValorCambio { get; set; }
        public long IdZonaIva { get; set; }
        public long? IdTasaIva { get; set; }
        public decimal PorcentajeIva { get; set; }
        public string CondicionesPago { get; set; }
        public decimal Importe { get; set; }
        public decimal Iva { get; set; }
        public decimal Ieps { get; set; }
        public decimal RetencionIsr { get; set; }
        public decimal RetencionIva { get; set; }
        public decimal RetencionIeps { get; set; }
        public decimal Ttotal { get; set; }
        public DateTime? Saldada { get; set; }
        public string Observaciones { get; set; }
        public long? IdCxccargoCancelo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiCxccargo { get; set; }
        public byte? RespetarSucursal { get; set; }
        public byte Tipo { get; set; }
        public long? IdCfd { get; set; }
        public byte EsCancelacion { get; set; }
        public long? IdUsuarioVendedor { get; set; }
        public long? IdRuCxpcargo { get; set; }
        public decimal? Ish { get; set; }
        public decimal? PorcentajeIsh { get; set; }
        public byte? TipoAfectacionImpuesto { get; set; }
        public long? IdTasaImpuestoSobreHospedaje { get; set; }
        public long? IdCxccargoAnticipoDevolucion { get; set; }
        public byte? ProvisionIngresosPorRealizar { get; set; }
        public byte? GeneraComplemento { get; set; }
        public byte? TipoAnticipo { get; set; }
        public long? IdCfdauxiliar { get; set; }
        public long? IdCategoriaClienteAbonos { get; set; }
        public byte? CambiarContabilidad { get; set; }
        public string ErrorContabilidad { get; set; }
        public long? IdCuentaContableSaldoInicial { get; set; }
    }
}
