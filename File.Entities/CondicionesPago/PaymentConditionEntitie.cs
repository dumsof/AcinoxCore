namespace File.Entities.CondicionesPago
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class PaymentConditionEntitie
    {
        [XmlElement("cod")]
        public string Cod { get; set; }

        [XmlElement("desc")]
        public string Desc { get; set; }

        [XmlArrayItem("plazo")]
        public List<PlazosEntitie> plazos { get; set; }
    }
}