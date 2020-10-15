namespace File.Entities.PartidasAbierta
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("partabiertas")]
    public class PartidasOpen
    {
        [XmlElement("part")]
        public List<PartidasOpenEntitie> PartidasAbiertas
        {
            get;
            set;
        }
    }
}