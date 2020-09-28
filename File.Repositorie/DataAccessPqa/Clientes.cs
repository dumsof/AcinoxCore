using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class Clientes
    {
        public long IdCliente { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombre { get; set; }
        public string NombreCliente { get; set; }
        public string NombreComercial { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public long IdNacionalidad { get; set; }
        public long DiasCredito { get; set; }
        public byte Status { get; set; }
        public byte[] Logo { get; set; }
        public byte[] Cedula { get; set; }
        public long? IdEmpresa { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid? UiCliente { get; set; }
        public byte? InformacionContactos { get; set; }
        public byte IncluirNombreSucursalEnFactura { get; set; }
        public byte EstructuraNomina { get; set; }
        public string PartidoPolitico { get; set; }
        public string NoIdentificado { get; set; }
        public long? IdFormatoImpresionEtiqueta { get; set; }
        public byte? CantidadImpresiones { get; set; }
        public long? IdActividadEconomica { get; set; }
        public long? IdTipoIdentificacion { get; set; }
        public string IdentificacionOtro { get; set; }
        public string NumeroIdentificacion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public long? IdPaisNacimiento { get; set; }
        public string Clasificacion { get; set; }
        public byte[] ImagenCliente { get; set; }
        public byte? RetieneIsn { get; set; }
        public string EnvioDocumentosFiscales { get; set; }
        public byte? GeneradoPor { get; set; }
        public byte? CambioRazonSocial { get; set; }
        public byte EsRevendedor { get; set; }
        public long? IdClienteRevendedor { get; set; }
        public long? IdClienteGrupo { get; set; }
        public byte? Modalidad { get; set; }
        public byte? ServicioTimbrado { get; set; }
        public long? IdCategoriaCliente { get; set; }
        public long? IdEmpresaSucursalAfacturar { get; set; }
        public long? IdClienteSucursalAfacturar { get; set; }
        public string MotivoSuspension { get; set; }
    }
}
