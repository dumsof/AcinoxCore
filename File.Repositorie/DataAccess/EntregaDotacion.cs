using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class EntregaDotacion
    {
        public string FechaDeEntrega { get; set; }
        public string Empresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Empleado { get; set; }
        public string SucEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string NumeroContrato { get; set; }
        public string EstadoContrato { get; set; }
        public string CoEmpleado { get; set; }
        public string NombreCo { get; set; }
        public string CostosEmpleado { get; set; }
        public string NombreCcostos { get; set; }
        public string Articulo { get; set; }
        public string Talla { get; set; }
        public decimal? CantidadOrdenada { get; set; }
        public decimal? CantidadEntregada { get; set; }
        public decimal? CantidadPendiente { get; set; }
    }
}
