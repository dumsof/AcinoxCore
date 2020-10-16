namespace File.Entities.PartidasCompensada
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("partcomps")]
    public class PartidasCompensated
    {
        [XmlElement("partc")]
        public List<PartidasCompensatedEntitie> PartidasCompensadas
        {
            get;
            set;
        }
    }
}