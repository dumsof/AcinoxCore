using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class ResumenAutoliquidacion
    {
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdTipoEntidad { get; set; }
        public string IdEntidad { get; set; }
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
        public string LapsoDoc { get; set; }
        public decimal? Nmala197Ibc { get; set; }
        public decimal? Nmala197Vlrcot { get; set; }
        public decimal? Nmala197VlrsolAfp { get; set; }
        public decimal? Nmala197VlrvolEmpAfp { get; set; }
        public decimal? Nmala197VlrvolTercAfp { get; set; }
        public string FechaGen { get; set; }
        public decimal? Nmpgter2VlrcotCcf { get; set; }
        public decimal? Nmpgter2VlrcotSena { get; set; }
        public decimal? Nmpgter2VlrcotIcbf { get; set; }
        public decimal? Nmala197VlrcotEmpleado { get; set; }
        public decimal? Nmala197VlrcotEmpresa { get; set; }
        public string Nmala197NitEntidad { get; set; }
        public decimal? DiasCot { get; set; }
        public string ExoIcbfSena { get; set; }
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
    }
}
