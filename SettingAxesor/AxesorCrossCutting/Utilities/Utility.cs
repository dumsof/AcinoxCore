namespace SettingAxesor.AxesorCrossCutting.Utilities
{
    using Microsoft.Extensions.Configuration;
    using System;

    public static class Utility
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static IConfigurationRoot ConfigurationSql { get; set; }

        public static IConfigurationRoot ConfigurationMessage { get; set; }
        private static string nameFolderReplace = "ServicioAxesorInstall";
        private static string nameFolderAppSetting = "AxesorArchivoFtp";

        public static string PathAplication
        {
            get
            {
                return string.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath) ?
                 AppDomain.CurrentDomain.BaseDirectory : AppDomain.CurrentDomain.RelativeSearchPath;
            }
        }

        public static string PathAppSetting
        {
            get
            {
                string pathFile = PathAplication.Replace(nameFolderReplace, nameFolderAppSetting);
                return pathFile;
            }
        }

        public static string ConnectionStringsSQLServer
        {
            get
            {
                return Configuration.GetSection("ConnectionStringsSQlServer:ConexionBaseDato").Value;
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

        public static void CofigurationMessage()
        {
            if (ConfigurationMessage == null)
            {
                ConfigurationMessage = GetBuilder("MessageAplication");
            }
        }

        private static IConfigurationRoot GetBuilder(string nameFileConfigJson)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(PathAppSetting)
           .AddJsonFile($"{nameFileConfigJson}.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}