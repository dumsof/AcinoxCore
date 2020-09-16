using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class CgresumenVentasServicios
    {
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdTipdoc { get; set; }
        public string DocumentoFs { get; set; }
        public string FechaDcto { get; set; }
        public string IdTerc { get; set; }
        public string IdSuc { get; set; }
        public string DocAltEmp { get; set; }
        public string DocAltCo { get; set; }
        public string DocAltTip { get; set; }
        public string DocumentoAlt { get; set; }
        public string IdFPago { get; set; }
        public string IdVendedor { get; set; }
        public string IdServicio { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioUni { get; set; }
        public decimal? DsctoNetos { get; set; }
        public decimal? TotVenta { get; set; }
        public decimal? TotBruto { get; set; }
        public decimal? ImpNetos { get; set; }
        public decimal? PrecioUniMe { get; set; }
        public decimal? DsctoNetosMe { get; set; }
        public decimal? TotVentaMe { get; set; }
        public decimal? ImpNetosMe { get; set; }
        public string Ccosto { get; set; }
        public string Proyecto { get; set; }
        public string CoMovimiento { get; set; }
        public string TerceroMov { get; set; }
        public string SucMov { get; set; }
        public decimal? PorcTasaIva { get; set; }
        public string Detalle1 { get; set; }
        public string Detalle2 { get; set; }
        public string Detalle3 { get; set; }
        public string Detalle4 { get; set; }
        public string Detalle5 { get; set; }
        public string DoFacturados { get; set; }
        public string FechaGen { get; set; }
        public string LapsoDoc { get; set; }
        public string IdCiudad { get; set; }
        public string IdGpoProyec { get; set; }
    }
}
