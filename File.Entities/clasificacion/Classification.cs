namespace File.Entities.clasificacion
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("clasifcriterios")]
    public class Classification
    {
        [XmlElement("critelem")]
        public List<ClassificationEntitie> CritElem
        {
            get;
            set;
        }
    }
}
