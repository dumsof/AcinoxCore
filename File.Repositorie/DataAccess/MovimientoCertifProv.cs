using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class MovimientoCertifProv
    {
        public string LapsoDoc { get; set; }
        public string IdTerc { get; set; }
        public string IdSuc { get; set; }
        public string FechaDcto { get; set; }
        public string IdEmp { get; set; }
        public string IdCoCc { get; set; }
        public string IdTipoCc { get; set; }
        public string IdNroCc { get; set; }
        public string IdNroInterno { get; set; }
        public string IdNroCp { get; set; }
        public string FechaCausacion { get; set; }
        public string IdTipoCertif { get; set; }
        public string FechaExpedi { get; set; }
        public string IdNroCpMod { get; set; }
        public string FechaCpMod { get; set; }
        public string IndTranform { get; set; }
        public string IndAdquirido { get; set; }
        public string FechaLimExpor { get; set; }
        public string IdNroEnvioMm { get; set; }
        public string Detalle1 { get; set; }
        public string Detalle2 { get; set; }
        public string Detalle3 { get; set; }
        public string Detalle4 { get; set; }
        public string IdItem { get; set; }
        public string IdExtItm { get; set; }
        public string IdUnidad { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioUni { get; set; }
        public decimal? VlrTotal { get; set; }
        public decimal? TasaIva { get; set; }
        public decimal? TasaRtefte { get; set; }
        public decimal? VlrIva { get; set; }
        public decimal? VlrRtefte { get; set; }
        public string FechaGen { get; set; }
    }
}
