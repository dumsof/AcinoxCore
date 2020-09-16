using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class CmmovimientoScompra
    {
        public string LapsoDoc { get; set; }
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string DocumentoSc { get; set; }
        public string FechaDcto { get; set; }
        public string FechaEntrega { get; set; }
        public string IdSolicitante { get; set; }
        public string SolicitanteNom { get; set; }
        public string IndEstado { get; set; }
        public string IdItem { get; set; }
        public string IdExtItm { get; set; }
        public string IdMotivo { get; set; }
        public string IdUnidad { get; set; }
        public decimal? CantidadReq { get; set; }
        public decimal? CantidadComp { get; set; }
        public decimal? CantidadPdte { get; set; }
        public string IdLocal { get; set; }
        public string Detalle1 { get; set; }
        public string Detalle2 { get; set; }
        public string Detalle3 { get; set; }
        public string Detalle4 { get; set; }
        public string UsuarioIng { get; set; }
        public string FechaGen { get; set; }
        public string ParaUsar { get; set; }
        public string UsuarioConf { get; set; }
        public string FechaConf { get; set; }
        public string HoraConf { get; set; }
    }
}
