using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class NmcuotasPrestamos
    {
        public string IdTipoReg { get; set; }
        public string IdEmp { get; set; }
        public string IdEmpleado { get; set; }
        public string IdSuc { get; set; }
        public string IdNdc { get; set; }
        public string IdConcepto { get; set; }
        public string IdRegistro { get; set; }
        public string FechaPrestamo { get; set; }
        public decimal? Tasa { get; set; }
        public decimal? PlazoPrestamo { get; set; }
        public string ModoCuotaPrestamo { get; set; }
        public decimal? VlrCuota { get; set; }
        public decimal? DescuentaCadaNPerPrestamo { get; set; }
        public string FechaInteresDesdePrestamo { get; set; }
        public string FechaUltDescuentoPrestamo { get; set; }
        public decimal? NroCuotasExtrasPrestamo { get; set; }
        public decimal? VlrTotCuotasExtrasPrestamo { get; set; }
        public string IndDescuentoPeriodo1Cuota { get; set; }
        public string IndDescuentoPeriodo2Cuota { get; set; }
        public string IndDescuentoPeriodo3Cuota { get; set; }
        public string IndDescuentoPeriodo4Cuota { get; set; }
        public string IndDescuentoPeriodo5Cuota { get; set; }
        public decimal? VlrTopeMaximoCuota { get; set; }
        public decimal? VlrAcumuladoCuota { get; set; }
        public decimal? VlrAcumCuotasPrestamo { get; set; }
        public decimal? VlrAcumExtrasPrestamo { get; set; }
        public decimal? VlrAcumAbonosExtrPrestamo { get; set; }
        public decimal? VlrSaldo { get; set; }
        public string IndEstado { get; set; }
        public string Garantia { get; set; }
        public string Observaciones1 { get; set; }
        public string Observaciones2 { get; set; }
        public string IdEntidadAfc { get; set; }
        public string TipoCruce { get; set; }
        public string NumeroCruce { get; set; }
        public string Co { get; set; }
        public string Ccosto { get; set; }
        public string FechaPrestamoFin { get; set; }
        public string FechaInicioCuota { get; set; }
    }
}
