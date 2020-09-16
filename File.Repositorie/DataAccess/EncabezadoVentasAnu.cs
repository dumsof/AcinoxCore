using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class EncabezadoVentasAnu
    {
        public string LapsoDoc { get; set; }
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdTipdoc { get; set; }
        public string DocumentoFc { get; set; }
        public string FechaDcto { get; set; }
        public string IdTerc { get; set; }
        public string IdSuc { get; set; }
        public string FechaVcto { get; set; }
        public decimal? VlrBruto { get; set; }
        public decimal? VlrDsctoLinea1 { get; set; }
        public decimal? VlrDsctoLinea2 { get; set; }
        public decimal? VlrDsctoGloba1 { get; set; }
        public decimal? VlrDsctoGloba2 { get; set; }
        public decimal? VlrIva { get; set; }
        public decimal? VlrImpoconsumo1 { get; set; }
        public decimal? VlrImpoconsumo2 { get; set; }
        public decimal? VlrNeto { get; set; }
        public decimal? VlrRetTotal { get; set; }
        public decimal? VlrRetFte { get; set; }
        public decimal? VlrRetIva { get; set; }
        public decimal? VlrRetIca { get; set; }
        public decimal? VlrRetOtros { get; set; }
        public string NomCliContado { get; set; }
        public string NitCliContado { get; set; }
        public string TipIdeContado { get; set; }
        public string IdVendCc { get; set; }
        public string NombreVend { get; set; }
        public string IdCargue { get; set; }
        public string IdClater1 { get; set; }
        public string IdClater2 { get; set; }
        public string IdClater { get; set; }
        public string Detalle { get; set; }
        public string FormaPago { get; set; }
        public string IdTercTrans { get; set; }
        public string IdSucTrans { get; set; }
        public string PlacaVehiculo { get; set; }
        public decimal? VlrCxc { get; set; }
        public decimal? VlrEfectivo { get; set; }
        public decimal? VlrCheque { get; set; }
        public decimal? VlrOtros { get; set; }
        public decimal? VlrCsg { get; set; }
        public string DoctoAlt { get; set; }
        public string CiudadDespCod { get; set; }
        public string CiudadDespDesc { get; set; }
        public string CondPago { get; set; }
        public string DirDesp { get; set; }
        public string IndVenta { get; set; }
        public string PrefijoDoc { get; set; }
    }
}
