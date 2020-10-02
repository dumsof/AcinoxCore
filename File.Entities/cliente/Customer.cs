namespace File.Entities.cliente
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("clientes")]
    public class Customer
    {
        [XmlElement("cliente")]
        public List<CustomerEntitie> Clientes
        {
            get;
            set;
        }
    }
}
