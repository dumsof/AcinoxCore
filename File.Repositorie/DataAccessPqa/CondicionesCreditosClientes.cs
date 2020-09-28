using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class CondicionesCreditosClientes
    {
        public long IdCondicionCreditoCliente { get; set; }
        public long? IdEmpresa { get; set; }
        public long IdCliente { get; set; }
        public decimal LimiteCredito { get; set; }
        public long IdMoneda { get; set; }
        public long DiasCredito { get; set; }
        public byte CriterioCredito { get; set; }
        public short NumeroDocumentosLimite { get; set; }
        public byte CreditoBloqueado { get; set; }
        public byte PermitirAumentoCreditoPorVenta { get; set; }
        public short? DiaCorte { get; set; }
        public decimal CargoPorMora { get; set; }
        public decimal PorcentajeMora { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiCondicionCreditoCliente { get; set; }
        public long? IdCacxc { get; set; }
        public long? FolioCredito { get; set; }
        public long? IdClienteSucursal { get; set; }
    }
}
