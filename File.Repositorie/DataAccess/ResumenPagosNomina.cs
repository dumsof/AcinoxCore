using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class ResumenPagosNomina
    {
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdCpto { get; set; }
        public string IdTerc { get; set; }
        public string IdSuc { get; set; }
        public string IdContrato { get; set; }
        public string IdTipoDoc { get; set; }
        public string IdNroDoc { get; set; }
        public string IdNtd { get; set; }
        public string IdGpocco { get; set; }
        public string IdCconiv1 { get; set; }
        public string IdCconiv2 { get; set; }
        public string IdCconiv3 { get; set; }
        public string IdCconiv4 { get; set; }
        public string IdIndDevDed { get; set; }
        public string IdGterc { get; set; }
        public string IdCargo { get; set; }
        public string IdRegimen { get; set; }
        public string IdSalIntegral { get; set; }
        public string IdClaseContrato { get; set; }
        public string LapsoDoc { get; set; }
        public decimal? NmmovHoras { get; set; }
        public decimal? NmmovValor { get; set; }
        public string FechaGen { get; set; }
        public string CoMov { get; set; }
        public string ProyectoMov { get; set; }
        public string TipoNomina { get; set; }
        public string CategoriaCargo { get; set; }
        public string NivelCargo { get; set; }
        public string DescripcionCargo { get; set; }
        public string Periodo { get; set; }
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public decimal? SaldoCuotaPrestamo { get; set; }
        public string IdUbicacion { get; set; }
        public string CliUbica { get; set; }
        public string SucUbica { get; set; }
        public string CoContrato { get; set; }
        public string CoContratoDesc { get; set; }
        public string IdEstado { get; set; }
        public string CoMovDesc { get; set; }
        public string DescProyectoMov { get; set; }
    }
}
