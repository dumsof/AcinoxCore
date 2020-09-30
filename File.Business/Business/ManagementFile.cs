namespace File.Business.Business
{
    using CsvHelper;
    using File.Business.IBusiness;
    using File.Utility;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class ManagementFile : IManagementFile
    {
        private readonly ILogger<ManagementFile> logger;

        public ManagementFile(ILogger<ManagementFile> logger)
        {
            this.logger = logger;
        }
        public bool CreateFileCsv<T>(string nameFile, IEnumerable<T> datas)
        {
            var path = $"{Utility.PathFolderGenerated}\\{nameFile}.csv";
            this.DeleteFile(path);
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw, CultureInfo.CurrentCulture))
            {
                cw.WriteHeader<T>();
                cw.NextRecord();
                foreach (var data in datas)
                {
                    cw.WriteRecord<T>(data);
                    cw.NextRecord();
                }
            }

            return true;
        }

        public bool CreateFileXml<T>(string nameFile, T datas)
        {
            var path = $"{Utility.PathFolderGenerated}\\{nameFile}.xml";
            this.DeleteFile(path);

            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new StreamWriter(path))
            {
                serializer.Serialize(stream, datas);
            }

            return true;
        }

        public void CreatedPathFile()
        {
            if (!Directory.Exists(Utility.PathFolderGenerated))
            {
                Directory.CreateDirectory(Utility.PathFolderGenerated);
            }
            if (!Directory.Exists(Utility.PathFolderProcessed))
            {
                Directory.CreateDirectory(Utility.PathFolderProcessed);
            }
            if (!Directory.Exists(Utility.PathFolderLogs))
            {
                Directory.CreateDirectory(Utility.PathFolderLogs);
            }
        }

        public void MoveFileUpLoadFtp(string nameFileWithExtension)
        {
            string pathFileGenerated = Utility.PathFolderGenerated;
            string pathFileProcessed = Utility.PathFolderProcessed;
            if (File.Exists($"{pathFileProcessed}\\{nameFileWithExtension}"))
            {
                File.Delete($"{pathFileProcessed}\\{nameFileWithExtension}");
            }
            File.Move($"{pathFileGenerated}\\{nameFileWithExtension}", $"{pathFileProcessed}\\{nameFileWithExtension}");
        }

        public bool MoveAllFileFolder()
        {
            DirectoryInfo directorio = new DirectoryInfo($"{Utility.PathFolderGenerated}\\");
            string[] extensioFile = Utility.ExtesionFiles?.Split(";");
            FileInfo[] files = directorio.EnumerateFiles().Where(c => extensioFile.Contains(c.Extension.ToLower())).ToArray();
            foreach (var file in files)
            {
                this.DeleteFile($"{Utility.PathFolderProcessed}\\{file.Name}");
                Directory.Move($"{Utility.PathFolderGenerated}\\{file.Name}", $"{Utility.PathFolderProcessed}\\{file.Name}");
            }

            this.logger.LogInformation($"Los archivos se movieron a la carpeta de [ArchivosProcesado] con éxito.");

            return true;
        }

        private void DeleteFile(string pathFile)
        {
            File.Delete(pathFile);
        }
    }
}