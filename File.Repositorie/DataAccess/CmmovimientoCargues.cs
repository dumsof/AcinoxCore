using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class CmmovimientoCargues
    {
        public string IdEmp { get; set; }
        public string LapsoDoc { get; set; }
        public string FechaDcto { get; set; }
        public string IdCoCargue { get; set; }
        public string IdNroCargue { get; set; }
        public string IdItem { get; set; }
        public string IdExtItm { get; set; }
        public string IdBodegaAuto { get; set; }
        public string IdUnidad { get; set; }
        public decimal? PrecioUni { get; set; }
        public decimal? PorcTasaIva { get; set; }
        public decimal? Vlriva { get; set; }
        public decimal? CantCargue { get; set; }
        public decimal? CantDescargue { get; set; }
        public decimal? CantFisico { get; set; }
        public decimal? CantCargueOtr { get; set; }
        public decimal? CantDescargueOtr { get; set; }
        public decimal? CantVenta { get; set; }
        public decimal? VlrCargue { get; set; }
        public decimal? VlrDescargue { get; set; }
        public decimal? VlrFisico { get; set; }
        public decimal? VlrCargueOtr { get; set; }
        public decimal? VlrDescargueOtr { get; set; }
        public decimal? VlrVenta { get; set; }
        public string FechaGen { get; set; }
    }
}
