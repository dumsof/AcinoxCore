using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class Impuestos
    {
        public string IdImpues { get; set; }
        public string IdDesc { get; set; }
        public decimal? IdTasa { get; set; }
        public decimal? IdTasaDesc { get; set; }
        public string IdModoLiq { get; set; }
        public string IdIndImpocon { get; set; }
        public string IdImpoconDesc { get; set; }
        public string IdIndBasedata { get; set; }
        public string IdItemCopago { get; set; }
        public decimal? IdTasaCompra { get; set; }
    }
}
