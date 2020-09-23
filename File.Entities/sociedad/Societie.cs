namespace File.Entities.sociedad
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("sociedades")]
    public class Societie
    {        
        [XmlElement("Soc")]
        public List<SocietieEntitie> Sociedades
        {
            get;
            set;
        }
    }
}