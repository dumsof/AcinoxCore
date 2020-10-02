namespace File.Utility
{
    using Microsoft.Extensions.Configuration;
    using System;

    public static class Utility
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static IConfigurationRoot ConfigurationSql { get; set; }

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
            get => $"{PathAplication}\\{Configuration.GetSection("ConfiguracionNombreCarpeta:NombreCarpetaArchivoGenerado").Value}";
        }

        public static string PathFolderProcessed
        {
            get => $"{PathAplication}\\{Configuration.GetSection("ConfiguracionNombreCarpeta:NombreCarpetaArchivoProcesado").Value}";
        }

        public static string PathFolderLogs
        {
            get => $"{PathAplication}\\{Configuration.GetSection("ConfiguracionNombreCarpeta:NombreCarpetaLog").Value}";
        }

        public static string ExtesionFiles
        {
            get => $"{Configuration.GetSection("ConfiguracionFtp:TiposArchivoEnviarFtp").Value}";
        }

        public static string ConnectionStringsSQLServer
        {
            get
            {
                string connectionStringsSQLServer = Configuration.GetSection("ConnectionStringsSQlServer:ConexionBaseDato").Value;
                string nameServer = Configuration.GetSection("ConnectionStringsSQlServer:NombreServidor").Value;
                string userDataBase = Configuration.GetSection("ConnectionStringsSQlServer:UsuarioBaseDato").Value;
                string password = Configuration.GetSection("ConnectionStringsSQlServer:PasswordUsuarioBaseDato").Value;
                string nameDataBase = Configuration.GetSection("ConnectionStringsSQlServer:NombreBaseDato").Value;
                string timeOut = Configuration.GetSection("ConnectionStringsSQlServer:Timeout").Value;

                return string.Format(connectionStringsSQLServer, nameServer, userDataBase, password, nameDataBase, timeOut);
            }
        }

        public static int ConnectionStringsTimeout
        {
            get => Convert.ToInt32(Configuration.GetSection("ConnectionStringsSQlServer:Timeout").Value);
        }

        public static int HourFormat24
        {
            get
            {
                TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
                return timeOfDay.Hours;
            }
        }

        public static bool IsHourProced
        {
            get
            {
                var hour24 = int.Parse(Configuration.GetSection("ConfiguracionHoraEjecucionProceso:Hora24").Value);
                var minute60 = int.Parse(Configuration.GetSection("ConfiguracionHoraEjecucionProceso:Minuto60").Value);

                return hour24 == HourFormat24 && minute60 == DateTime.Now.Minute;
            }
        }

        public static void CofigurationJson()
        {
            if (Configuration == null)
            {
                Configuration = GetBuilder("appsettings");
            }
        }

        public static void CofigurationSQL()
        {
            if (ConfigurationSql == null)
            {
                ConfigurationSql = GetBuilder("consultasSQLPqa");
            }
        }

        private static IConfigurationRoot GetBuilder(string nameFileConfigJson)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(PathAplication)
           .AddJsonFile($"{nameFileConfigJson}.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}