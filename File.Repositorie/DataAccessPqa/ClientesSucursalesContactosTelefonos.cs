using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class ClientesSucursalesContactosTelefonos
    {
        public long IdClienteSucursalContactoTelefono { get; set; }
        public long IdClienteSucursalContacto { get; set; }
        public long IdTelefono { get; set; }
        public long IdPais { get; set; }
        public string CodigoArea { get; set; }
        public string NumeroLocal { get; set; }
        public string Extension { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiClienteSucursalContactoTelefono { get; set; }
    }
}
