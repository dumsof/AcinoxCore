using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class ExperienciaLaboral
    {
        public string Empleado { get; set; }
        public string Sucursal { get; set; }
        public string Registro { get; set; }
        public string Empresa { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Cargo { get; set; }
        public string FechaDeIngreso { get; set; }
        public string FechaDeRetiro { get; set; }
        public decimal? SueldoInicial { get; set; }
        public decimal? SueldoFinal { get; set; }
        public string JefeInmediato { get; set; }
        public string CargoJefe { get; set; }
        public string MotivoDeRetiro { get; set; }
    }
}
