using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class DocumentoCargues
    {
        public string IdEmp { get; set; }
        public string LapsoDoc { get; set; }
        public string FechaDcto { get; set; }
        public string IdCoCargue { get; set; }
        public string IdNroCargue { get; set; }
        public string IdEstado { get; set; }
        public string IdVehiculo { get; set; }
        public string IdTercCond { get; set; }
        public string IdSucCond { get; set; }
        public string IdTercResp { get; set; }
        public string IdSucResp { get; set; }
        public string IdBodegaAuto { get; set; }
        public string IdTercAyu1 { get; set; }
        public string IdSucAyu1 { get; set; }
        public string IdTercAyu2 { get; set; }
        public string IdSucAyu2 { get; set; }
        public string IdTercAyu3 { get; set; }
        public string IdSucAyu3 { get; set; }
        public string IdTercAyu4 { get; set; }
        public string IdSucAyu4 { get; set; }
        public string IdLipre { get; set; }
        public decimal? VlrtotCargue { get; set; }
        public decimal? VlrtotVenta { get; set; }
        public decimal? VlrvenCredito { get; set; }
        public decimal? VlrvenContado { get; set; }
        public decimal? VlrrecCartera { get; set; }
        public decimal? VlrrecCuadre { get; set; }
        public decimal? VlrrecDiferen { get; set; }
        public string Deta1 { get; set; }
        public string Deta2 { get; set; }
        public string Deta3 { get; set; }
        public string Deta4 { get; set; }
        public string IdEmpCuadre { get; set; }
        public string IdCoCuadre { get; set; }
        public string IdTipoCuadre { get; set; }
        public string IdNroCuadre { get; set; }
        public string IdFechaPys { get; set; }
        public string IdEmpDocin { get; set; }
        public string IdCoDocin { get; set; }
        public string IdTipoDocin { get; set; }
        public string IdNroDocin { get; set; }
        public string IdTercFac { get; set; }
        public string IdSucFac { get; set; }
        public string IdRuta { get; set; }
        public string IdLiqFlete { get; set; }
        public string FechaGen { get; set; }
    }
}
