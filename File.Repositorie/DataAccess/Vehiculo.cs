using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class Vehiculo
    {
        public string Empleado { get; set; }
        public string Sucursal { get; set; }
        public string NroVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal? ValorVehiculo { get; set; }
        public decimal? ValorDeuda { get; set; }
        public decimal? ValorCuota { get; set; }
        public string Entidad { get; set; }
        public string Observacion { get; set; }
        public string FechaActual { get; set; }
        public string TipoDeVehiculo { get; set; }
    }
}
