using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class Vivienda
    {
        public string Empleado { get; set; }
        public string Sucursal { get; set; }
        public string NroVivienda { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Propia { get; set; }
        public decimal? ValorVivienda { get; set; }
        public decimal? ValorDeuda { get; set; }
        public decimal? ValorCuota { get; set; }
        public string Entidad { get; set; }
        public string Escritura { get; set; }
        public string Observacion { get; set; }
        public string FechaActual { get; set; }
        public string FechaEscritura { get; set; }
        public string TipoDeVivienda { get; set; }
    }
}
