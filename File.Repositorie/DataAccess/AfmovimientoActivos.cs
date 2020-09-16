using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class AfmovimientoActivos
    {
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdCconiv4 { get; set; }
        public string IdUbica { get; set; }
        public string IdMetodo { get; set; }
        public string IdGrucon { get; set; }
        public string IdGrupo { get; set; }
        public string IdActivo { get; set; }
        public string IdAdicion { get; set; }
        public string IdTerc { get; set; }
        public string LapsoDoc { get; set; }
        public decimal? AfactivoCostoTotal { get; set; }
        public decimal? AfactivoComprasMes { get; set; }
        public decimal? AfactivoGastosMes { get; set; }
        public decimal? AfactivoCostoAdqui { get; set; }
        public decimal? AfactivoPaagCostoAdqui { get; set; }
        public decimal? AfactivoDepreAcumHist { get; set; }
        public decimal? AfactivoDepreAcumPaag { get; set; }
        public decimal? AfactivoAjustPaagDepre { get; set; }
        public decimal? AfactivoValorizacion { get; set; }
        public decimal? AfactivoProvision { get; set; }
        public decimal? AfactivoCostoAjustado { get; set; }
        public decimal? AfactivoDepreAjustada { get; set; }
        public string FechaGen { get; set; }
        public decimal? AfactivoPeriodosDepre { get; set; }
        public string AfactivoFechaAdqui { get; set; }
        public decimal? AfactivoPeriodosADepre { get; set; }
        public decimal? AfactivoPerPendientes { get; set; }
        public decimal? AfactivoSalvamentoPorc { get; set; }
        public decimal? AfactivoSalvamentoValor { get; set; }
        public decimal? AfactivoUnidADepre { get; set; }
        public decimal? AfactivoUnidDepre { get; set; }
        public decimal? AfactivoUnidPdteDepre { get; set; }
        public decimal? AfactivoUnidAjusDepre { get; set; }
        public decimal? AfactivoDepreInic { get; set; }
        public decimal? AfactivoDepreAplic { get; set; }
    }
}
