namespace File.Entities.sociedad
{
    using System.Xml.Serialization;

    public class SocietieEntitie
    {
        [XmlElement("cod")]
        public string Cod { get; set; }

        [XmlElement("razons")]
        public string Razons { get; set; }

        [XmlElement("nif")]
        public string Nif { get; set; }

        [XmlElement("codmoneda")]
        public string CodMoneda { get; set; }
    }
}