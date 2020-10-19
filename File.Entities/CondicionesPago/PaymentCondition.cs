namespace File.Entities.CondicionesPago
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("condspago")]
    public class PaymentCondition
    {
        [XmlElement("cond")]
        public List<PaymentConditionEntitie> CondicionesPago
        {
            get;
            set;
        }
    }
}
