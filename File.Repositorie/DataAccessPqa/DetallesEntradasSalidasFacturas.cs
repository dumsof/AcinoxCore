using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class DetallesEntradasSalidasFacturas
    {
        public long IdEsdetalleFactura { get; set; }
        public long IdEsdetalle { get; set; }
        public long IdCfddetalle { get; set; }
        public decimal CantidadCfd { get; set; }
        public long? IdCfddetalleCliente { get; set; }
        public decimal? CantidadCliente { get; set; }
        public long? IdEsdetalleDevolucion { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiEsdetalleFactura { get; set; }
        public byte Tipo { get; set; }
        public byte ModoGeneracion { get; set; }
        public byte EsCancelacion { get; set; }
        public string Activo { get; set; }
        public long? IdVenta { get; set; }
        public byte? EsRefacturado { get; set; }
    }
}
