namespace File.Entities.formapago
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("viaspago")]
    public class PaymentMethod
    {
        [XmlElement("via")]
        public List<PaymentMethodEntitie> Via
        {
            get;
            set;
        }
    }
}