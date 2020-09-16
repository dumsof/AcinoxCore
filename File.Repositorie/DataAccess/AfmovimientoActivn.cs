using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class AfmovimientoActivn
    {
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string LapsoDoc { get; set; }
        public string IdActivo { get; set; }
        public string IdAdicion { get; set; }
        public decimal? CostoTotal { get; set; }
        public decimal? ComprasMes { get; set; }
        public decimal? GastosMes { get; set; }
        public decimal? CostoAdqui { get; set; }
        public decimal? DepreAcumHist { get; set; }
        public decimal? DepreAcumReva { get; set; }
        public decimal? Revalorizacion { get; set; }
        public decimal? Deterioro { get; set; }
        public decimal? CostoAdquiAj { get; set; }
        public decimal? DepreAcumHistAj { get; set; }
        public decimal? RevalorizAj { get; set; }
        public decimal? DepreAcumRevaAj { get; set; }
        public decimal? DeterioroAj { get; set; }
        public decimal? PeriodosDepre { get; set; }
        public decimal? PeriodosADepre { get; set; }
        public string FechaActivacion { get; set; }
        public string FechaGen { get; set; }
        public string IdGruconVn { get; set; }
        public string IdMetodo { get; set; }
        public decimal? PerPendientes { get; set; }
        public decimal? SalvamentoPorc { get; set; }
        public decimal? SalvamentoValor { get; set; }
        public decimal? UnidADepre { get; set; }
        public decimal? UnidDepre { get; set; }
        public decimal? UnidPdteDepre { get; set; }
        public decimal? UnidAjusDepre { get; set; }
        public decimal? CostoNeto { get; set; }
        public string CentroCostos { get; set; }
        public string GrupoActivo { get; set; }
        public string GrupoContable { get; set; }
        public string IdUbica { get; set; }
        public string IdProyecto { get; set; }
        public string CodRespons { get; set; }
        public decimal? DepreCostoApv { get; set; }
        public string CalculoApv { get; set; }
        public string CalculoApv1 { get; set; }
        public string MetodoApv { get; set; }
        public string EstadoAfvn { get; set; }
        public decimal? AfactivnDepreInic { get; set; }
        public decimal? AfactivnDepreAplic { get; set; }
    }
}
