using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class CondicionesCreditosClientesEmpresas
    {
        public long IdCondicionCreditoClienteEmpresa { get; set; }
        public long IdCondicionCreditoCliente { get; set; }
        public long IdEmpresa { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiCondicionCreditoClienteEmpresa { get; set; }
    }
}
