using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class MovimientoActivos
    {
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdGpocco { get; set; }
        public string IdCconiv1 { get; set; }
        public string IdCconiv2 { get; set; }
        public string IdCconiv3 { get; set; }
        public string IdCconiv4 { get; set; }
        public string IdUbica { get; set; }
        public string IdMetodo { get; set; }
        public string IdGrucon { get; set; }
        public string IdGrupo1 { get; set; }
        public string IdGrupo2 { get; set; }
        public string IdGrupo3 { get; set; }
        public string IdGrupo4 { get; set; }
        public string IdGrupo { get; set; }
        public string IdActivo { get; set; }
        public string IdAdicion { get; set; }
        public string IdTerc { get; set; }
        public string IdSuc { get; set; }
        public string LapsoDoc { get; set; }
        public decimal? AfactivoCostoTotal { get; set; }
        public decimal? AfactivoComprasMes { get; set; }
        public decimal? AfactivoGastosMes { get; set; }
        public decimal? AfactivoCostoAdqui { get; set; }
        public decimal? AfactivoPaagCostoAdqui { get; set; }
        public decimal? AfactivoDepreAcumHist { get; set; }
        public decimal? AfactivoDepreAcumPaag { get; set; }
        public decimal? AfactivoAjustPaagDepre { get; set; }
        public decimal? AfactivoProvision { get; set; }
        public decimal? AfactivoValorizacion { get; set; }
        public decimal? AfactivoCostoAjustado { get; set; }
        public decimal? AfactivoDepreAjustada { get; set; }
        public string FechaGen { get; set; }
        public decimal? PeriodosADepre { get; set; }
        public string FechaAdqui { get; set; }
        public decimal? PeriodosDepre { get; set; }
        public string FechaDarBaja { get; set; }
        public string FechaUltAvaluo { get; set; }
        public string FechaUltAjusPaag { get; set; }
        public string FechaUltDepre { get; set; }
        public string FechaActivacion { get; set; }
        public string CoOc { get; set; }
        public string TipoOc { get; set; }
        public string NroOc { get; set; }
        public string FechaOc { get; set; }
        public string TercOc { get; set; }
        public string TercSucOc { get; set; }
        public string IdReferencia { get; set; }
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
