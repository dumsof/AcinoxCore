using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class CategoriasClientes
    {
        public long IdCategoriaCliente { get; set; }
        public long? IdEmpresa { get; set; }
        public string NombreCategoriaCliente { get; set; }
        public long IdPadre { get; set; }
        public bool EsHijo { get; set; }
        public string Activo { get; set; }
        public byte UsoCategoria { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiCategoriaCliente { get; set; }
    }
}
