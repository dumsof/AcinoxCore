namespace SettingAxesor.AxesorBusiness.Business
{
    using Newtonsoft.Json;
    using SettingAxesor.AxesorBusiness.IBusiness;
    using SettingAxesor.AxesorCrossCutting.Entitie;
    using SettingAxesor.AxesorRepositorie.IRepositorie;
    using System.IO;
    using AxesorCrossCutting.Utilities;

    public class ConfigurationBusiness : IConfigurationBusiness
    {
        private string fileSetting = "appsettings.json";
        private string configuracionDato = "ConnectionStringsSQlServer";
        private string keyNombreServidor = "NombreServidor";
        private string keyBaseDato = "NombreBaseDato";
        private string keyUsuario = "UsuarioBaseDato";
        private string keyPassawordDataBase = "PasswordUsuarioBaseDato";
        private string keyTimeOut = "Timeout";

        private string configuracionFTP = "ConfiguracionFtp";
        private string keyServidorFtp = "ServidorFtp";
        private string keyUsuarioFtp = "UsuarioFtp";
        private string keyPasswordFtp = "PasswordFtp";
        private string keyTiposArchivoEnviarFtp = "TiposArchivoEnviarFtp";

        private string configuracionEjecucion = "ConfiguracionHoraEjecucionProceso";
        private string keyHora24 = "Hora24";
        private string keyMinuto60 = "Minuto60";

        private readonly IConfigurationRepositorie repositorie;

        private dynamic ValoresJson { get; set; }

        public ConfigurationBusiness(IConfigurationRepositorie repositorie)
        {
            this.LoadValoresJson();
            this.repositorie = repositorie;
        }
        public bool VerifyConnection(ConnectionStringsServerDataBaseEntitie serverDataBaseEntitie)
        {
            try
            {
                return this.repositorie.VerifyConnection(serverDataBaseEntitie);
            }
            catch
            {
                return false;
            }
            
        }

        public bool SaveConfigurationDataBase(ConnectionStringsServerDataBaseEntitie serverDataBaseEntitie)
        {
            this.ValoresJson[configuracionEjecucion][keyNombreServidor] = serverDataBaseEntitie.NombreServidor;
            this.ValoresJson[configuracionEjecucion][keyBaseDato] = serverDataBaseEntitie.NombreBaseDato;
            this.ValoresJson[configuracionEjecucion][keyUsuario] = serverDataBaseEntitie.UsuarioBaseDato;
            this.ValoresJson[configuracionEjecucion][keyPassawordDataBase] = serverDataBaseEntitie.PasswordUsuarioBaseDato;
            string output = JsonConvert.SerializeObject(this.ValoresJson, Formatting.Indented);
            File.WriteAllText(fileSetting, output);

            return true;
        }

        public bool SaveConfigurationFtp(ConfiguracionFtp configuracionFtp )
        {
            this.ValoresJson[configuracionEjecucion][keyServidorFtp] = configuracionFtp.ServidorFtp;
            this.ValoresJson[configuracionEjecucion][keyUsuarioFtp] = configuracionFtp.UsuarioFtp;
            this.ValoresJson[configuracionEjecucion][keyPasswordFtp] = configuracionFtp.PasswordFtp;           
            string output = JsonConvert.SerializeObject(this.ValoresJson, Formatting.Indented);
            File.WriteAllText(fileSetting, output);

            return true;
        }

        public bool SaveConfigurationHours(ConfiguracionHoraEjecucionProcesoEntitie configuracionHoraEjecucion)
        {
            this.ValoresJson[configuracionEjecucion][keyHora24] = configuracionHoraEjecucion.Hora24;
            this.ValoresJson[configuracionEjecucion][keyMinuto60] = configuracionHoraEjecucion.Minuto60;
            string output = JsonConvert.SerializeObject(this.ValoresJson, Formatting.Indented);
            File.WriteAllText(fileSetting, output);

            return true;
        }

        


        private void LoadValoresJson()
        {
            string json = File.ReadAllText($"{Utility.PathAppSetting}//{fileSetting}");
            this.ValoresJson = JsonConvert.DeserializeObject(json);
        }
    }
}