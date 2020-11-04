using System.Xml.Serialization;

namespace File.Entities.PartidasCompensada
{
    public class PartidasCompensatedEntitie
    {
        [XmlElement("codcli")]
        public string CodCli { get; set; }

        [XmlElement("ndoc")]
        public string Ndoc { get; set; }

        [XmlElement("nvcto")]
        public string Nvcto { get; set; }

        [XmlElement("fchemi")]
        public string Fchemi { get; set; }

        [XmlElement("fchvcto")]
        public string Fchvcto { get; set; }

        [XmlElement("fchcomp")]
        public string Fchcomp { get; set; }

        [XmlElement("importe")]
        public decimal Importe { get; set; }

        [XmlElement("marca")]
        public string Marca { get; set; }

        [XmlElement("impmondoc")]
        public decimal ImpMonDoc { get; set; }

        [XmlElement("codmondoc")]
        public string CodMonDoc { get; set; }

        [XmlElement("ind1")]
        public string Ind1 { get; set; }

        [XmlElement("ind2")]
        public string Ind2 { get; set; }

        [XmlElement("ind3")]
        public string Ind3 { get; set; }

        [XmlElement("ind4")]
        public string Ind4 { get; set; }

        [XmlElement("ind5")]
        public string Ind5 { get; set; }

        [XmlElement("ind6")]
        public string Ind6 { get; set; }

        [XmlElement("ind7")]
        public string Ind7 { get; set; }

        [XmlElement("ind8")]
        public string Ind8 { get; set; }

        [XmlElement("ind9")]
        public string Ind9 { get; set; }

        [XmlElement("tdoc")]
        public string Tdoc { get; set; }

        [XmlElement("campoid")]
        public string Campoid { get; set; }

        [XmlElement("codejercicio")]
        public string CodeJercicio { get; set; }

        [XmlElement("codejerciciocomp")]
        public string CodEjercicioComp { get; set; }

        [XmlElement("numdoccobro")]
        public string NumDocCobro { get; set; }

        [XmlElement("numdocorigen")]
        public string NumDocOrigen { get; set; }
    }
}