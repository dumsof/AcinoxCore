namespace SettingAxesor.AxesorBusiness.Business
{
    using Newtonsoft.Json;
    using SettingAxesor.AxesorBusiness.IBusiness;
    using SettingAxesor.AxesorCrossCutting.Entitie;
    using SettingAxesor.AxesorRepositorie.IRepositorie;
    using System.IO;
    using AxesorCrossCutting.Utilities;
    using System;

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
        public bool VerifyConnection(ConfiguracionStringsServerDataBaseEntitie serverDataBaseEntitie)
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

        public bool VerifyConnectionFtp(ConfiguracionFtpEntitie configuracionFtp)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool SaveConfigurationDataBase(ConfiguracionStringsServerDataBaseEntitie serverDataBaseEntitie)
        {
            this.ValoresJson[configuracionEjecucion][keyNombreServidor] = serverDataBaseEntitie.NombreServidor;
            this.ValoresJson[configuracionEjecucion][keyBaseDato] = serverDataBaseEntitie.NombreBaseDato;
            this.ValoresJson[configuracionEjecucion][keyUsuario] = serverDataBaseEntitie.UsuarioBaseDato;
            this.ValoresJson[configuracionEjecucion][keyPassawordDataBase] = serverDataBaseEntitie.PasswordUsuarioBaseDato;
            string output = JsonConvert.SerializeObject(this.ValoresJson, Formatting.Indented);
            File.WriteAllText(fileSetting, output);

            return true;
        }

        public bool SaveConfigurationFtp(ConfiguracionStringsServerDataBaseEntitie serverDataBaseEntitie)
        {

            return true;
        }

        public bool SaveConfigurationFtp(ConfiguracionFtpEntitie configuracionFtp)
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

        public Tuple<ConfiguracionStringsServerDataBaseEntitie, ConfiguracionFtpEntitie, ConfiguracionHoraEjecucionProcesoEntitie> LoadValueControl()
        {
            var dataBase = new ConfiguracionStringsServerDataBaseEntitie
            {
                NombreServidor = this.ValoresJson[configuracionDato][keyNombreServidor],
                NombreBaseDato = this.ValoresJson[configuracionDato][keyBaseDato],
                UsuarioBaseDato = this.ValoresJson[configuracionDato][keyUsuario],
                PasswordUsuarioBaseDato = this.ValoresJson[configuracionDato][keyPassawordDataBase],
                TimeOut = this.ValoresJson[configuracionDato][keyTimeOut]
            };

            var ftp = new ConfiguracionFtpEntitie
            {
                ServidorFtp = this.ValoresJson[configuracionFTP][keyServidorFtp],
                UsuarioFtp = this.ValoresJson[configuracionFTP][keyUsuarioFtp],
                PasswordFtp = this.ValoresJson[configuracionFTP][keyPasswordFtp],
                TipoArchivoFtp = this.ValoresJson[configuracionFTP][keyTiposArchivoEnviarFtp],
            };
            var hours = new ConfiguracionHoraEjecucionProcesoEntitie
            {
                Hora24 = this.ValoresJson[configuracionEjecucion][keyHora24],
                Minuto60 = this.ValoresJson[configuracionEjecucion][keyMinuto60]
            };
            return new Tuple<ConfiguracionStringsServerDataBaseEntitie, ConfiguracionFtpEntitie, ConfiguracionHoraEjecucionProcesoEntitie>(dataBase, ftp, hours);
        }


        private void LoadValoresJson()
        {
            string json = File.ReadAllText($"{Utility.PathAppSetting}//{fileSetting}");
            this.ValoresJson = JsonConvert.DeserializeObject(json);
        }
    }
}