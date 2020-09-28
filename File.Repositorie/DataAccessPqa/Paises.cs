using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class Paises
    {
        public long IdPais { get; set; }
        public string CodigoPais { get; set; }
        public string NombrePais { get; set; }
        public string Nacionalidad { get; set; }
        public string ClaveTelefonica { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiPais { get; set; }
    }
}
