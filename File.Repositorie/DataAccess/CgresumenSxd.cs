using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class CgresumenSxd
    {
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdCuenta { get; set; }
        public string IdTerc { get; set; }
        public string IdSuc { get; set; }
        public string IdTipoCru { get; set; }
        public string IdNroCru { get; set; }
        public string IdCuotaCru { get; set; }
        public string IdRango { get; set; }
        public string IdDiasVcto { get; set; }
        public string LapsoDoc { get; set; }
        public string IdFecha { get; set; }
        public string IdFechaVcto { get; set; }
        public string IdCcosto { get; set; }
        public string IdProyecto { get; set; }
        public decimal? SaldosTotCartera { get; set; }
        public decimal? SaldosTotCarteraMe { get; set; }
        public decimal? SaldosIni { get; set; }
        public decimal? SaldosDebMes { get; set; }
        public decimal? SaldosCreMes { get; set; }
        public decimal? VlrOriginal { get; set; }
        public string FechaGen { get; set; }
        public string IdGpoProyec { get; set; }
        public string PrefijoProv { get; set; }
        public string NumeroProv { get; set; }
        public string IdFechaContab { get; set; }
        public string AnoSxd { get; set; }
        public string FechaEstimada { get; set; }
        public decimal? ValorProgramado { get; set; }
        public string FechaRadic { get; set; }
        public decimal? ValorOriDoc { get; set; }
        public decimal? SaldosTotCarteraL2 { get; set; }
        public decimal? SaldosTotCarteraL2Me { get; set; }
        public decimal? SaldosIniL2 { get; set; }
        public decimal? SaldosDebMesL2 { get; set; }
        public decimal? SaldosCreMesL2 { get; set; }
        public decimal? VlrOriginalL2 { get; set; }
        public decimal? DiasGracia { get; set; }
        public string FechaCorte { get; set; }
        public decimal? ChequePosfec { get; set; }
    }
}
