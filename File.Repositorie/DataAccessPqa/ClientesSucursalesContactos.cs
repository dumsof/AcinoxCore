using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class ClientesSucursalesContactos
    {
        public long IdClienteSucursalContacto { get; set; }
        public long IdClienteSucursal { get; set; }
        public long IdTitulo { get; set; }
        public string NombreContacto { get; set; }
        public string PuestoContacto { get; set; }
        public string DepartamentoContacto { get; set; }
        public DateTime? FechaNacimientoContacto { get; set; }
        public byte[] FotoContacto { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiClienteSucursalContacto { get; set; }
        public long? IdEmpresa { get; set; }
    }
}
