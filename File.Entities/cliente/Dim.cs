﻿namespace File.Entities.cliente
{
    using System.Xml.Serialization;

    [XmlRoot("dim")]
    public class Dim
    {
        [XmlElement("codcrit")]
        public string CodCrite { get; set; }

        [XmlElement("codelem")]
        public string CodElemen { get; set; }
    }
}