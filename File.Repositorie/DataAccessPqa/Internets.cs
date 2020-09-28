using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class Internets
    {
        public long IdInternet { get; set; }
        public string NombreInternet { get; set; }
        public byte Seleccionada { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiInternet { get; set; }
        public byte? Tipo { get; set; }
    }
}
