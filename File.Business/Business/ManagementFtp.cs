namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities;
    using File.Utility;
    using FluentFTP;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;

    public class ManagementFtp : IManagementFtp
    {
        private readonly ILogger<ManagementFtp> logger;
        private readonly IOptions<ConfiguracionFtp> configFtp;

        public ManagementFtp(ILogger<ManagementFtp> logger, IOptions<ConfiguracionFtp> configFtp)
        {
            this.logger = logger;
            this.configFtp = configFtp;
        }

        public bool UnloadFileFtp(string nameFileExtension)
        {
            var fileToUpload = $"{Utility.PathFolderGenerated}\\{nameFileExtension}";
            List<string> remote = new List<string>() { fileToUpload };
            using (FtpClient ftp = new FtpClient(configFtp.Value.ServidorFtp, new NetworkCredential { UserName = configFtp.Value.UsuarioFtp, Password = configFtp.Value.PasswordFtp }))
            {
                ftp.UploadFiles(remote, $"{configFtp.Value.RutaCarpetaServidorFtp}\\{nameFileExtension}", FtpRemoteExists.Overwrite);
            }

            return true;
        }

        public bool UnloadAllFileFolderFtp()
        {
            DirectoryInfo directorio = new DirectoryInfo($"{Utility.PathFolderGenerated}\\");
            string[] extensioFile = configFtp.Value.TiposArchivoEnviarFtp?.Split(";");

            FileInfo[] files = directorio.EnumerateFiles().Where(c => extensioFile.Contains(c.Extension.ToLower())).ToArray();

            using (FtpClient ftp = new FtpClient(configFtp.Value.ServidorFtp, new NetworkCredential { UserName = configFtp.Value.UsuarioFtp, Password = configFtp.Value.PasswordFtp }))
            {
                ftp.UploadFiles(files, $"{configFtp.Value.RutaCarpetaServidorFtp}", FtpRemoteExists.Overwrite);
            }
            this.logger.LogInformation($"Los archivos generados fueron enviados por [FTP] con éxito.");
            return true;
        }
    }
}