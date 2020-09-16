using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class CmmediosRecaudo
    {
        public string LapsoDoc { get; set; }
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdTipdoc { get; set; }
        public string DocumentoFc { get; set; }
        public string IndModo { get; set; }
        public string MedioDesc { get; set; }
        public decimal? VlrRecaudo { get; set; }
        public string MedioRefer { get; set; }
        public string FechaFc { get; set; }
    }
}
