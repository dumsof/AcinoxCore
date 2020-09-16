using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class MovimientoEntregas
    {
        public string LapsoDoc { get; set; }
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdTipo { get; set; }
        public string IdNroDoc { get; set; }
        public string IdEmpDocfc { get; set; }
        public string IdCoDocfc { get; set; }
        public string IdTipoDocfc { get; set; }
        public string IdNroDocDocfc { get; set; }
        public string FechaDoc { get; set; }
        public string IdTerc { get; set; }
        public string IdTercSuc { get; set; }
        public string IdDespachador { get; set; }
        public string DetalleDoc { get; set; }
        public string IdItem { get; set; }
        public string IdExtitm { get; set; }
        public string IdTalla { get; set; }
        public string UnimedCap { get; set; }
        public decimal? Cant1 { get; set; }
        public decimal? Cant2 { get; set; }
        public decimal? CantidadTalla { get; set; }
        public string DetalleItem { get; set; }
    }
}
