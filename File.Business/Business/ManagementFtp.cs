namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities;
    using File.Utility;
    using FluentFTP;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Net;

    public class ManagementFtp : IManagementFtp
    {
        private readonly IOptions<ConfiguracionFtp> configFtp;

        public ManagementFtp(IOptions<ConfiguracionFtp> configFtp)
        {
            this.configFtp = configFtp;
        }

        public bool UnloadFileFtp(string nameFolder)
        {
            var fileToUpload = $"{Utility.PathFolderGenerated}\\sociedades.csv";
            List<string> remote = new List<string>() { fileToUpload };
            using (FtpClient ftp = new FtpClient(configFtp.Value.ServidorFtp, new NetworkCredential { UserName = configFtp.Value.UsuarioFtp, Password = configFtp.Value.PasswordFtp }))
            {
                ftp.UploadFiles(remote, $"{configFtp.Value.RutaCarpetaServidorFtp}\\sociedades.csv", FtpRemoteExists.Overwrite);
            }

            return true;
        }
    }
}