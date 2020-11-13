namespace File.Entities.PartidasCompensadaAnulada
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("partcompsinv")]
    public class PartidasCompensatedCanceled
    {
        [XmlElement("partcinv")]
        public List<PartidasCompensatedCanceledEntitie> PartidasCompensadasAnuladas
        {
            get;
            set;
        }
    }
}