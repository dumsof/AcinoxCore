namespace File.Entities.clasificacion
{
    using System.Xml.Serialization;

    public class ClassificationEntitie
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("cod")]
        public string Cod { get; set; }

        [XmlElement("desc")]
        public string Desc { get; set; }
    }
}