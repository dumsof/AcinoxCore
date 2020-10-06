namespace File.Entities.contactosCliente
{
    using System.Xml.Serialization;

    public class CustomerContactsEntitie
    {
        [XmlElement("codcliente")]
        public string CodCliente { get; set; }
        [XmlElement("codcontacto")]
        public string CodContacto { get; set; }
        [XmlElement("nombre")]
        public string Nombre { get; set; }
        [XmlElement("nif")]
        public string Nif { get; set; }      
        [XmlElement("tcontacto")]
        public int TContacto { get; set; }
        [XmlElement("coddireccion")]
        public string CodDireccion { get; set; }
        [XmlElement("tlffijo")]
        public string TlFfijo { get; set; }
        [XmlElement("tlfmovil")]
        public string TlfMovil { get; set; }
        [XmlElement("fax")]
        public string Fax { get; set; }
        [XmlElement("email")]
        public string Email { get; set; }
        [XmlElement("ind1")]
        public string Ind1 { get; set; }
        [XmlElement("ind2")]
        public string Ind2 { get; set; }
        [XmlElement("ind3")]
        public string Ind3 { get; set; }
    }
}
