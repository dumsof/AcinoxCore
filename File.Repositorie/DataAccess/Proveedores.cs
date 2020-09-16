using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class Proveedores
    {
        public string Codigo { get; set; }
        public string Sucursal { get; set; }
        public string Descripcion { get; set; }
        public string Nit { get; set; }
        public string NitDv { get; set; }
        public string TipoTercero { get; set; }
        public string TipoIdentifica { get; set; }
        public string Estado { get; set; }
        public string FechaCreacion { get; set; }
        public string CiudadCorresp { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Direccion3 { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Fax { get; set; }
        public string Barrio { get; set; }
        public string CodigoCiiu { get; set; }
        public string Email { get; set; }
        public string Establecimiento { get; set; }
        public string ProClase { get; set; }
        public string ProContacto { get; set; }
        public string ProCondPago { get; set; }
        public decimal? ProDGracia { get; set; }
        public decimal? ProCupoCre { get; set; }
        public string ProEstado { get; set; }
        public string ProObserva { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Nombres { get; set; }
        public string CiudadTercero { get; set; }
        public string IndLiqImptoC { get; set; }
        public string ProCalifica { get; set; }
        public string ProFormaPago { get; set; }
        public string TipoCuenta { get; set; }
        public string MetodoPago { get; set; }
        public string NroCtaBanco { get; set; }
        public string TitularCta { get; set; }
        public string CodBanco { get; set; }
        public string DescBanco { get; set; }
        public string IndRegimenSimp { get; set; }
        public decimal? DiasPpProv { get; set; }
        public decimal? DsctoPpProv { get; set; }
        public string PFechaUltPago { get; set; }
        public string PTotDiasAtras { get; set; }
        public string PNroPagoAtras { get; set; }
        public string PTotDiasPago { get; set; }
        public string PNroPagos { get; set; }
        public string PFecUltCompra { get; set; }
        public decimal? PComprasBrutas { get; set; }
        public string PNroCompras { get; set; }
        public string PNroDevol { get; set; }
        public string PFecUltMvto { get; set; }
        public string CodPostal { get; set; }
        public string GranContribP { get; set; }
        public string IndReterentaP { get; set; }
    }
}
