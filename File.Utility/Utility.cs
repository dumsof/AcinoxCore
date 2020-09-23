namespace File.Utility
{
    using Microsoft.Extensions.Configuration;
    using System;

    public static class Utility
    {
        private static IConfigurationRoot Configuration { get; set; }

        public static string PathAplication
        {
            get
            {
                return string.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath) ?
                 AppDomain.CurrentDomain.BaseDirectory : AppDomain.CurrentDomain.RelativeSearchPath;
            }
        }

        public static string PathFolderGenerated
        {
            get
            {
                CofigurationJson();
                return $"{PathAplication}\\{Configuration.GetSection("ConfiguracionNombreCarpeta:NombreCarpetaArchivoGenerado").Value}";
            }
        }

        public static string PathFolderProcessed
        {
            get
            {
                CofigurationJson();
                return $"{PathAplication}\\{Configuration.GetSection("ConfiguracionNombreCarpeta:NombreCarpetaArchivoProcesado").Value}";
            }
        }

        public static string PathFolderLogs
        {
            get
            {
                CofigurationJson();
                return $"{PathAplication}\\{Configuration.GetSection("ConfiguracionNombreCarpeta:NombreCarpetaLog").Value}";
            }
        }

        public static string ExtesionFiles
        {
            get
            {
                CofigurationJson();
                return $"{Configuration.GetSection("ConfiguracionFtp:TiposArchivoEnviarFtp").Value}";
            }
        }

        public static int HourFormat24
        {
            get
            {
                TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
                return timeOfDay.Hours;
            }
        }

        public static bool IsHourProced()
        {
            CofigurationJson();
            var hour24 = int.Parse(Configuration.GetSection("ConfiguracionHoraEjecucionProceso:Hora24").Value);
            var minute60 = int.Parse(Configuration.GetSection("ConfiguracionHoraEjecucionProceso:Minuto60").Value);

            return hour24 == HourFormat24 && minute60 == DateTime.Now.Minute;
        }

        private static void CofigurationJson()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(PathAplication)
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }
    }
}