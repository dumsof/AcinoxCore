using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class ResumenVlrsConsolidados
    {
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdIndicadorCod { get; set; }
        public string IdConsoCod { get; set; }
        public string IdTerc { get; set; }
        public string IdSuc { get; set; }
        public string IdContrato { get; set; }
        public string IdGpocco { get; set; }
        public string IdCconiv1 { get; set; }
        public string IdCconiv2 { get; set; }
        public string IdCconiv3 { get; set; }
        public string IdCconiv4 { get; set; }
        public string IdGterc { get; set; }
        public string IdCargo { get; set; }
        public string IdRegimen { get; set; }
        public string IdSalIntegral { get; set; }
        public string IdClaseContrato { get; set; }
        public string IdTipoEntidad { get; set; }
        public string IdEntidad { get; set; }
        public string LapsoDoc { get; set; }
        public decimal? NmconmesConsol { get; set; }
        public decimal? NmconmesPagoMes { get; set; }
        public decimal? NmconmesConsolMesant { get; set; }
        public decimal? NmconmesCausacion { get; set; }
        public decimal? NmconmesProvision { get; set; }
        public string FechaGen { get; set; }
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
    }
}
