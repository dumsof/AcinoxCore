namespace File.Entities.direccion
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("direcciones")]
    public class Address
    {
        [XmlElement("direccion")]
        public List<AddressEntitie> Direccion
        {
            get;
            set;
        }
    }
}
