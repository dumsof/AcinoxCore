using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class CmdocumentoCompras
    {
        public string LapsoDoc { get; set; }
        public string IdTerc { get; set; }
        public string IdSuc { get; set; }
        public string FechaDcto { get; set; }
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdTipo { get; set; }
        public string IdNro { get; set; }
        public string IdEmpDocfp { get; set; }
        public string IdCoDocfp { get; set; }
        public string IdTipoDocfp { get; set; }
        public string IdNroDocfp { get; set; }
        public string IdEmpDococ { get; set; }
        public string IdCoDococ { get; set; }
        public string IdTipoDococ { get; set; }
        public string IdNroDococ { get; set; }
        public string IdComprador { get; set; }
        public string Detalle { get; set; }
        public string DocAlt { get; set; }
        public string TipoNota { get; set; }
        public string IdMoneda { get; set; }
        public decimal? TasaConver { get; set; }
        public decimal? TasaCambio { get; set; }
        public decimal? VlrtotBru { get; set; }
        public decimal? VlrdesLinea1 { get; set; }
        public decimal? VlrdesLinea2 { get; set; }
        public decimal? VlrdesGlobal1 { get; set; }
        public decimal? VlrdesGlobal2 { get; set; }
        public decimal? Vlriva { get; set; }
        public decimal? Vlrimpoconsumo1 { get; set; }
        public decimal? Vlrimpoconsumo2 { get; set; }
        public decimal? Vlrnet { get; set; }
        public decimal? DsctoGlobal1 { get; set; }
        public decimal? DsctoGlobal2 { get; set; }
        public string IndIncluido { get; set; }
        public string EstadoTrans { get; set; }
        public string IdLote { get; set; }
        public string CtaPasivoEstimado { get; set; }
        public string IndConsignacion { get; set; }
        public string EstadoContab { get; set; }
        public string FechaGen { get; set; }
    }
}
