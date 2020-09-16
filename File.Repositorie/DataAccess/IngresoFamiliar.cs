using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class IngresoFamiliar
    {
        public string Empleado { get; set; }
        public string Sucursal { get; set; }
        public string Parentesco { get; set; }
        public string NombreDelFamiliar { get; set; }
        public string EmpresaDelFamiliar { get; set; }
        public string OcupacionDelFamiliar { get; set; }
        public decimal? IngresosDelFamiliar { get; set; }
        public decimal? SubsidiosDelFamiliar { get; set; }
        public decimal? OtrosIngresos { get; set; }
        public string Observaciones { get; set; }
    }
}
