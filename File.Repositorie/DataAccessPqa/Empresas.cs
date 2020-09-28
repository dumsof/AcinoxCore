using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class Empresas
    {
        public long IdEmpresa { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombre { get; set; }
        public string NombreEmpresa { get; set; }
        public string NombreComercial { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public long IdNacionalidad { get; set; }
        public string ConstNumActa { get; set; }
        public string ConstVolumen { get; set; }
        public string ConstLibro { get; set; }
        public string ConstNotarioNom { get; set; }
        public string ConstNotarioNum { get; set; }
        public string ConstNotarioUbica { get; set; }
        public string RepreNombre { get; set; }
        public string RepreRfc { get; set; }
        public string RepreNumActa { get; set; }
        public string RepreVolumen { get; set; }
        public string RepreLibro { get; set; }
        public string RepreNotarioNom { get; set; }
        public string RepreNotarioNum { get; set; }
        public string RepreNotarioUbica { get; set; }
        public DateTime? RepreFecha { get; set; }
        public byte[] RepreFirma { get; set; }
        public byte[] Logo { get; set; }
        public byte[] Icono { get; set; }
        public byte[] Fondo { get; set; }
        public byte[] Cedula { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiEmpresa { get; set; }
        public string RegimenFiscal { get; set; }
        public long? IdRegimenFiscal { get; set; }
        public long? IdPersonaRepresentante { get; set; }
        public string LogoRuta { get; set; }
        public byte? EsCallCenter { get; set; }
        public byte? EsPagadora { get; set; }
        public string CurprepresentanteLegal { get; set; }
        public string TiposInterfazEmpresa { get; set; }
    }
}
