namespace File.Entities.SaldoNoFacturado
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("saldosnofacturados")]
    public class BalancesNoInvoiced
    {
        [XmlElement("saldo")]
        public List<BalancesNoInvoicedEntitie> Ventas
        {
            get;
            set;
        }
    }
}