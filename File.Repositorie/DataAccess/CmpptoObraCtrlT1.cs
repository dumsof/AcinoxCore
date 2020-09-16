using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class CmpptoObraCtrlT1
    {
        public string LapsoDoc { get; set; }
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdPpto { get; set; }
        public string IdCcosto { get; set; }
        public string FechaDoc { get; set; }
        public string DescCcosto { get; set; }
        public decimal? CantPptoInv { get; set; }
        public decimal? CantPptoSer { get; set; }
        public decimal? VlrPptoInv { get; set; }
        public decimal? VlrPptoSer { get; set; }
        public decimal? CantRealInv { get; set; }
        public decimal? VlrRealInv { get; set; }
        public decimal? CantRealSer { get; set; }
        public decimal? VlrRealSer { get; set; }
        public decimal? CantPptoAvance { get; set; }
        public decimal? CantRealAvance { get; set; }
        public string Item { get; set; }
        public string DescItem { get; set; }
        public string NombreAvance { get; set; }
        public string FechaPrimerCons { get; set; }
        public string FechaUltimoCons { get; set; }
    }
}
