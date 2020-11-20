namespace SettingAxesor.AxesorBusiness.Business
{
    using AxesorCrossCutting.Utilities;
    using FluentFTP;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using SettingAxesor.AxesorBusiness.IBusiness;
    using SettingAxesor.AxesorCrossCutting.Entitie;
    using SettingAxesor.AxesorRepositorie.IRepositorie;
    using System;
    using System.IO;
    using System.Net;

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
        private readonly ILogger<ConfigurationBusiness> logger;
        private readonly IConfigurationRepositorie repositorie;

        private dynamic ValoresJson { get; set; }

        public ConfigurationBusiness(ILogger<ConfigurationBusiness> logger, IConfigurationRepositorie repositorie)
        {
            this.LoadValoresJson();
            this.logger = logger;
            this.repositorie = repositorie;
        }

        public bool VerifyConnection(ConfiguracionStringsServerDataBaseEntitie serverDataBaseEntitie)
        {
            try
            {
                return this.repositorie.VerifyConnection(serverDataBaseEntitie);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error conexión servidor Base de Datos");
                return false;
            }
        }

        public bool VerifyConnectionFtp(ConfiguracionFtpEntitie configuracionFtp)
        {
            try
            {
                using (FtpClient ftp = new FtpClient($"{configuracionFtp.ServidorFtp}", new NetworkCredential { UserName = configuracionFtp.UsuarioFtp, Password = configuracionFtp.PasswordFtp }))
                {
                    ftp.Connect();
                    return ftp.IsConnected;
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error conexión servidor FTP");
                return false;
            }
        }

        public bool SaveConfigurationDataBase(ConfiguracionStringsServerDataBaseEntitie serverDataBaseEntitie)
        {
            this.ValoresJson[configuracionDato][keyNombreServidor] = serverDataBaseEntitie.NombreServidor;
            this.ValoresJson[configuracionDato][keyBaseDato] = serverDataBaseEntitie.NombreBaseDato;
            this.ValoresJson[configuracionDato][keyUsuario] = serverDataBaseEntitie.UsuarioBaseDato;
            this.ValoresJson[configuracionDato][keyPassawordDataBase] = serverDataBaseEntitie.PasswordUsuarioBaseDato;
            this.SaveAppSetting();

            return true;
        }

        public bool SaveConfigurationFtp(ConfiguracionFtpEntitie configuracionFtp)
        {
            this.ValoresJson[configuracionFTP][keyServidorFtp] = configuracionFtp.ServidorFtp;
            this.ValoresJson[configuracionFTP][keyUsuarioFtp] = configuracionFtp.UsuarioFtp;
            this.ValoresJson[configuracionFTP][keyPasswordFtp] = configuracionFtp.PasswordFtp;
            this.ValoresJson[configuracionFTP][keyPasswordFtp] = configuracionFtp.TipoArchivoFtp;
            this.SaveAppSetting();

            return true;
        }

        public bool SaveConfigurationHours(ConfiguracionHoraEjecucionProcesoEntitie configuracionHoraEjecucion)
        {
            this.ValoresJson[configuracionEjecucion][keyHora24] = configuracionHoraEjecucion.Hora24;
            this.ValoresJson[configuracionEjecucion][keyMinuto60] = configuracionHoraEjecucion.Minuto60;
            this.SaveAppSetting();

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

        private void SaveAppSetting()
        {
            string output = JsonConvert.SerializeObject(this.ValoresJson, Formatting.Indented);
            File.WriteAllText($"{Utility.PathAppSetting}//{fileSetting}", output);
        }
    }
}