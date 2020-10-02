namespace File.Entities.cliente
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class CustomerEntitie
    {
        [XmlElement("cod")]
        public string Cod { get; set; }

        [XmlElement("nif")]
        public string Nif { get; set; }

        [XmlElement("razons")]
        public string Razons { get; set; }

        [XmlElement("codcondp")]
        public string Codcondp { get; set; }

        [XmlElement("limitrg")]
        public decimal? limitrg { get; set; }

        [XmlElement("prov")]
        public string Prov { get; set; }


        [XmlArrayItem("dim")]
        public List<Dim> dims { get; set; }

        [XmlElement("lrcomp", IsNullable = true)]
        public int? Lrcomp { get; set; }


        [XmlArrayItem("codvp", IsNullable = true)]
        public List<string> viasp { get; set; }

        [XmlElement("clasifcontable")]
        public string Clasifcontable { get; set; }

        [XmlElement("lsegcredito", IsNullable = true)]
        public decimal? Lsegcredito { get; set; }

        [XmlElement("fchcadsegcred", IsNullable = true)]
        public string Fchcadsegcred { get; set; }

        [XmlElement("tipoentidad", IsNullable = true)]
        public string Tipoentidad { get; set; }

        [XmlElement("sector", IsNullable = true)]
        public string Sector { get; set; }

        [XmlElement("fchaltaerp", IsNullable = true)]
        public string Fchaltaerp { get; set; }

        [XmlElement("fchinitact", IsNullable = true)]
        public string Fchinitact { get; set; }

        [XmlElement("ind1", IsNullable = true)]
        public string Ind1 { get; set; }

        [XmlElement("ind2", IsNullable = true)]
        public string Ind2 { get; set; }

        [XmlElement("ind3", IsNullable = true)]
        public string Ind3 { get; set; }

        [XmlElement("ind4", IsNullable = true)]
        public string Ind4 { get; set; }

        [XmlElement("ind5", IsNullable = true)]
        public string Ind5 { get; set; }

        [XmlElement("ind6", IsNullable = true)]
        public string Ind6 { get; set; }

        [XmlElement("ind7", IsNullable = true)]
        public string Ind7 { get; set; }

        [XmlElement("ind8", IsNullable = true)]
        public string Ind8 { get; set; }

        [XmlElement("ind9", IsNullable = true)]
        public string Ind9 { get; set; }
    }
}