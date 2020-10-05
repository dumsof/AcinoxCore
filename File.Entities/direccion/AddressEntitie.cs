
namespace File.Entities.direccion
{
    using System.Xml.Serialization;

    public class AddressEntitie
    {
        [XmlElement("codcliente")]
        public string CodCliente { get; set; }
        [XmlElement("coddireccion")]
        public string CodDireccion { get; set; }
        [XmlElement("tdireccion")]
        public string TDireccion { get; set; }
        [XmlElement("domicilio")]
        public string Domicilio { get; set; }
        [XmlElement("ciudad")]
        public string Ciudad { get; set; }
        [XmlElement("prov")]
        public string Prov { get; set; }
        [XmlElement("cp")]
        public string Cp { get; set; }
        [XmlElement("pais")]
        public string Pais { get; set; }
        [XmlElement("ind1")]
        public string Ind1 { get; set; }
        [XmlElement("ind2")]
        public string Ind2 { get; set; }
        [XmlElement("ind3")]
        public string Ind3 { get; set; }
    }
}
