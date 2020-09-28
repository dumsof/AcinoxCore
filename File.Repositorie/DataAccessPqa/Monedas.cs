using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class Monedas
    {
        public long IdMoneda { get; set; }
        public string CodigoMoneda { get; set; }
        public string NombreMoneda { get; set; }
        public string SimboloMoneda { get; set; }
        public string NombreDocumento { get; set; }
        public string SimboloDocumento { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiMoneda { get; set; }
        public string CodigoSat { get; set; }
    }
}
