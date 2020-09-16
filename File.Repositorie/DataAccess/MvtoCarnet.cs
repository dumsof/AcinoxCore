using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccess
{
    public partial class MvtoCarnet
    {
        public string LapsoDoc { get; set; }
        public string IdEmp { get; set; }
        public string IdCo { get; set; }
        public string IdTipo { get; set; }
        public string IdNroDoc { get; set; }
        public string IdFecha { get; set; }
        public string IdCarnet { get; set; }
        public string IdTerc { get; set; }
        public string IdSuc { get; set; }
        public decimal? PuntosAct { get; set; }
        public decimal? PuntosGan { get; set; }
        public decimal? PuntosEnt { get; set; }
        public decimal? PuntosNue { get; set; }
        public string TipoRed { get; set; }
        public string UsuarioIng { get; set; }
        public string FechaIng { get; set; }
        public string UsuarioMod { get; set; }
        public string FechaMod { get; set; }
        public string CajeroCod { get; set; }
        public string IdTurno { get; set; }
        public string IdCaja { get; set; }
    }
}
