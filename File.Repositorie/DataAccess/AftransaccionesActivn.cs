using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class AftransaccionesActivn
    {
        public string IdCodigo { get; set; }
        public string IdAdicion { get; set; }
        public string IdFecha { get; set; }
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdTipo { get; set; }
        public string IdNro { get; set; }
        public string CoMov { get; set; }
        public string LapsoDcto { get; set; }
        public string Ccosto { get; set; }
        public string Detalle1 { get; set; }
        public string Detalle2 { get; set; }
        public string Responsable { get; set; }
        public string Cpto { get; set; }
        public string Motivo { get; set; }
        public decimal? CostoAdquic { get; set; }
        public decimal? DepreHist { get; set; }
        public decimal? PeriodosDepre { get; set; }
        public decimal? PeriodosSuspen { get; set; }
        public decimal? UnidadDepre { get; set; }
        public decimal? TasaFijaDepre { get; set; }
        public string FechaAvaluo { get; set; }
        public string FirmaAvaluo { get; set; }
        public decimal? ValorAvaluo { get; set; }
        public string EmpTrasladoSal { get; set; }
        public string CoTrasladoSal { get; set; }
        public string TipoTrasladoSal { get; set; }
        public string NroTrasladoSal { get; set; }
        public string NtdTrasladoSal { get; set; }
        public string FechaUltDepreAnt { get; set; }
        public string FechaUltAjusteAnt { get; set; }
        public string FechaUltAvaluoAnt { get; set; }
        public string EmpAvaluoAnt { get; set; }
        public string CoAvaluoAnt { get; set; }
        public string TipoAvaluoAnt { get; set; }
        public string NroAvaluoAnt { get; set; }
        public string NtdAvaluoAnt { get; set; }
        public string FirmaAvaluoAnt { get; set; }
        public decimal? ValorAvaluoAnt { get; set; }
        public string EstadoActivoAnt { get; set; }
        public string Ubica { get; set; }
        public decimal? PeriodosADepre { get; set; }
        public string Grucon { get; set; }
        public string Proyecto { get; set; }
    }
}
