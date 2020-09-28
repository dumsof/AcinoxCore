using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class CondicionesPagos
    {
        public long IdCondicionPago { get; set; }
        public string NombreCondicionPago { get; set; }
        public short Dias { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiCondicionPago { get; set; }
    }
}
