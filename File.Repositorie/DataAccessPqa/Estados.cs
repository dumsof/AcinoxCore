using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class Estados
    {
        public long IdPaisEstado { get; set; }
        public long IdPais { get; set; }
        public string CodigoEstado { get; set; }
        public string NombreEstado { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiPaisEstado { get; set; }
        public string CodigoInesat { get; set; }
    }
}
