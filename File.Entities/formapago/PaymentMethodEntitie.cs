namespace File.Entities.formapago
{
    using System.Xml.Serialization;

    public class PaymentMethodEntitie
    {
        [XmlElement("cod")]
        public string Cod { get; set; }

        [XmlElement("desc")]
        public string Desc { get; set; }

        [XmlElement("gencart", IsNullable = true)]
        public string GenCart { get; set; }

        [XmlElement("ind1", IsNullable = true)]
        public string Ind1 { get; set; }

        [XmlElement("ind2", IsNullable = true)]
        public string Ind2 { get; set; }

        [XmlElement("numdias", IsNullable = true)]
        public string NumDias { get; set; }
    }
}