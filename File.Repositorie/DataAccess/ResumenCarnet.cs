using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class ResumenCarnet
    {
        public string IdCarnet { get; set; }
        public string IdTerc { get; set; }
        public string IdSuc { get; set; }
        public decimal? PuntosDb { get; set; }
        public decimal? PuntosCr { get; set; }
        public decimal? PuntosComp { get; set; }
        public decimal? SaldoPuntos { get; set; }
    }
}
