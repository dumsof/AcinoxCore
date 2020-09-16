namespace File.Entities
{
    using System.Xml.Serialization;

    public class SocietieEntitie
    {
        [XmlAttribute("Código")]
        public string Cod { get; set; }
        public string Razons { get; set; }
        public string Nif { get; set; }
        public string CodMoneda { get; set; }
    }
}