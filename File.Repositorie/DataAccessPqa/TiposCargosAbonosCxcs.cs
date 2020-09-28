using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class TiposCargosAbonosCxcs
    {
        public long IdCacxc { get; set; }
        public string TipoCacxc { get; set; }
        public string NombreCacxc { get; set; }
        public byte TipoDocumento { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiCacxc { get; set; }
        public string UsosCategorias { get; set; }
        public byte? EsAnticipo { get; set; }
    }
}
