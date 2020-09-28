using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class ClientesSucursales
    {
        public long IdClienteSucursal { get; set; }
        public long IdCliente { get; set; }
        public string NombreClienteSucursal { get; set; }
        public string Calle { get; set; }
        public string NumExterior { get; set; }
        public string NumInterior { get; set; }
        public long IdPais { get; set; }
        public long? IdCodigoPostal { get; set; }
        public string Colonia { get; set; }
        public long IdPaisEstado { get; set; }
        public string Municipio { get; set; }
        public string Localidad { get; set; }
        public long? IdZonaIva { get; set; }
        public string Referencia { get; set; }
        public string Activo { get; set; }
        public long? DiasPago { get; set; }
        public string ObservacionesDiaPago { get; set; }
        public long? DiasRecepcion { get; set; }
        public string ObservacionesDiaRecepcion { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiClienteSucursal { get; set; }
        public string CodigoRelacionLayout { get; set; }
        public byte? DefaultFacturacion { get; set; }
        public long? IdEmpresaSucursalNomina { get; set; }
        public string CodigoPostalIntegracion { get; set; }
        public long? IdLocalidadSat { get; set; }
        public long? IdMunicipioSat { get; set; }
        public long? IdColoniaSat { get; set; }
    }
}
