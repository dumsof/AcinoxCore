namespace File.Entities.contactosCliente
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("contactos")]
    public class CustomerContacts
    {
        [XmlElement("contacto")]
        public List<CustomerContactsEntitie> Contactos
        {
            get;
            set;
        }
    }
}
