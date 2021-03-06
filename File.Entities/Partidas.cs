﻿namespace File.Entities
{
    using System.Xml.Serialization;

    public class Partidas
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

        [XmlElement("importe")]
        public decimal Importe { get; set; }

        [XmlElement("estado")]
        public int Estado { get; set; }

        [XmlElement("dotada")]
        public int Dotada { get; set; }

        [XmlElement("codvp")]
        public string CodVp { get; set; }

        [XmlElement("codcondp")]
        public string CodConDp { get; set; }

        [XmlElement("codmondoc")]
        public string CodMonDoc { get; set; }

        [XmlElement("impmondoc")]
        public decimal ImpMonDoc { get; set; }

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

        [XmlElement("numdocorigen")]
        public string NumDocOrigen { get; set; }
    }
}
