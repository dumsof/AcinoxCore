using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class CmrelacionPptoCtrl
    {
        public string LapsoDoc { get; set; }
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdPpto { get; set; }
        public string CoCcosto { get; set; }
        public string IdCcosto { get; set; }
        public string IdProyecto { get; set; }
        public string IdItem { get; set; }
        public string IdExtitm { get; set; }
        public string IdDocEmp { get; set; }
        public string IdDocCo { get; set; }
        public string IdDocTipo { get; set; }
        public string IdDocNro { get; set; }
        public string IdApuntaPadre { get; set; }
        public decimal? CantPpto { get; set; }
        public decimal? CostoPpto { get; set; }
    }
}
