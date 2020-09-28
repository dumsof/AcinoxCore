using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class ClientesCategoriasClientes
    {
        public long IdClienteCategoriaCliente { get; set; }
        public long IdEmpresa { get; set; }
        public long IdCliente { get; set; }
        public long IdCategoriaCliente { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public Guid UiClienteCategoriaCliente { get; set; }
        public long? IdEmpresaSucursal { get; set; }
    }
}
