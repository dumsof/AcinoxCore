using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class TarjetaCredito
    {
        public string Empleado { get; set; }
        public string Sucursal { get; set; }
        public string Tarjeta { get; set; }
        public string Entidad { get; set; }
        public string Numero { get; set; }
        public decimal? CupoTotal { get; set; }
        public string FechaDeExpedicion { get; set; }
        public string FechaDeVencimiento { get; set; }
    }
}
