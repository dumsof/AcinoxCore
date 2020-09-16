using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class ArticulosDotacion
    {
        public string Empleado { get; set; }
        public string Sucursal { get; set; }
        public string ArticuloDeDotacion { get; set; }
        public decimal? Cantidad { get; set; }
        public string Talla { get; set; }
    }
}
