using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class TiposPagosPosempresasSucursales
    {
        public long IdTipoPagoPosempresaSucursal { get; set; }
        public long IdEmpresa { get; set; }
        public long? IdEmpresaSucursal { get; set; }
        public long IdTipoPago { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiTipoPagoPosempresaSucursal { get; set; }
        public byte? AplicaTiempoCompartido { get; set; }
        public byte? EsContado { get; set; }
    }
}
