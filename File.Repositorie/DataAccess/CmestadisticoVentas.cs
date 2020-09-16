using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class CmestadisticoVentas
    {
        public string LapsoDoc { get; set; }
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdTerc { get; set; }
        public string IdSuc { get; set; }
        public string IdVendedor { get; set; }
        public string IdItem { get; set; }
        public string IdExtItm { get; set; }
        public string IdConcepto { get; set; }
        public string IdMotivo { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? TotVenta { get; set; }
        public string IdLocal { get; set; }
        public decimal? Cantidad2 { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Volumen { get; set; }
        public string FechaGen { get; set; }
    }
}
