
namespace File.Entities.CondicionesPago
{
    using System.Xml.Serialization;
   
    public class PlazosEntitie
    {
        [XmlElement("dsc")]
        public string Dsc { get; set; }

        [XmlElement("dias")]
        public string Dias { get; set; }

        [XmlElement("porc")]
        public string Porc { get; set; }

        [XmlElement("codvia")]
        public string CodVia { get; set; }
        [XmlElement("codp")]
        public string Codp { get; set; }
    }
}