using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class CuentaBancaria
    {
        public string Empleado { get; set; }
        public string Sucursal { get; set; }
        public string Banco { get; set; }
        public string TipoDeCuenta { get; set; }
        public string Ciudad { get; set; }
        public string NroDeCuenta { get; set; }
        public string FechaDeApertura { get; set; }
        public string Observaciones { get; set; }
    }
}
