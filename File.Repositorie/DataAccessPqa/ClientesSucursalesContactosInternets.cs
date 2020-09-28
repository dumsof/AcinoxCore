using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class ClientesSucursalesContactosInternets
    {
        public long IdClienteSucursalContactoInternet { get; set; }
        public long IdClienteSucursalContacto { get; set; }
        public long IdInternet { get; set; }
        public string CuentaDireccion { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiClienteSucursalContactoInternet { get; set; }
        public string EnviarInformacion { get; set; }
    }
}
