namespace File.Entities.ResumenVenta
{
    using System.Xml.Serialization;

    public class SaleSummaryEntitie
    {
        [XmlElement("codcli")]
        public string CodCli { get; set; }

        [XmlElement("anio")]
        public int Anio { get; set; }

        [XmlElement("mes")]
        public int Mes { get; set; }

        [XmlElement("importe")]
        public decimal Importe { get; set; }
    }
}