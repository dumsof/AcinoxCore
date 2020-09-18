namespace File.Entities
{
    public class ConfiguracionHoraEjecucionProceso
    {
        public int Hora24 { get; set; }

        public int Minuto60 { get; set; }

        public int ProcesarCadaMinuto { get; set; }

        public bool ProcesarCadaMinutoSinValidacionHora { get; set; }
    }
}