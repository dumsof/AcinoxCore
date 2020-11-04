namespace File.Entities.ResumenVenta
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("ventas")]
    public class SaleSummary
    {
        [XmlElement("venta")]
        public List<SaleSummaryEntitie> Ventas
        {
            get;
            set;
        }
    }
}