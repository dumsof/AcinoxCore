namespace File.Entities.PartidasCompensadaAnulada
{
    using System.Xml.Serialization;

    public class PartidasCompensatedCanceledEntitie
    {
        [XmlElement("numcobro")]
        public string NumCobro { get; set; }

        [XmlElement("fchinv")]
        public string Fchinv { get; set; }

        [XmlElement("fchcreacion")]
        public string FchCreacion { get; set; }
    }
}