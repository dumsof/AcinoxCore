namespace File.Entities.SaldoNoFacturado
{
    using System.Xml.Serialization;

    public class BalancesNoInvoicedEntitie
    {
        [XmlElement("codcli")]
        public string CodCli { get; set; }

        [XmlElement("importe")]
        public decimal Importe { get; set; }

        [XmlElement("fchfacturacion")]
        public string FchFacturacion { get; set; }

        [XmlElement("plazopago")]
        public int PlazoPago { get; set; }

        [XmlElement("numpedido")]
        public string NumPedido { get; set; }

        [XmlElement("numalbaran")]
        public string NumAlbaran { get; set; }

        [XmlElement("campoid")]
        public string CampoId { get; set; }
    }
}