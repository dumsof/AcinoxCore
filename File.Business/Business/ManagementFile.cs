namespace File.Business.Business
{
    using CsvHelper;
    using File.Business.IBusiness;
    using File.Utility;
    using Microsoft.Extensions.Logging;
    using System;
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

        public bool CreateFileCsv<T>(string nameFile, IEnumerable<T> datas, bool crearCsv = false)
        {
            if (crearCsv)
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
            }

            return true;
        }

        public bool CreateFileXml<T>(string nameFile, T datas, string nameFolderNitSocietie = "")
        {
            var path = string.Empty;
            if (string.IsNullOrEmpty(nameFolderNitSocietie))
            {
                path = $"{Utility.PathFolderGenerated}\\{nameFile}.xml";
            }
            else
            {
                this.CreateFolderSocietie(nameFolderNitSocietie);
                path = $"{Utility.PathFolderGenerated}\\{nameFolderNitSocietie}\\{Utility.DateTimeProces}\\{nameFile}.xml";
            }

            this.DeleteFile(path);

            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new StreamWriter(path))
            {
                serializer.Serialize(stream, datas);
            }

            return true;
        }

        private void CreateFolderSocietie(string nameFolderSocietie)
        {
            string pathFolderSocietie = $"{Utility.PathFolderGenerated}\\{nameFolderSocietie}\\{Utility.DateTimeProces}";
            if (!Directory.Exists(pathFolderSocietie))
            {
                Directory.CreateDirectory(pathFolderSocietie);
            }
        }

        private void CreateFolderSocietieProcessed(string nameFolderSocietie)
        {
            string pathFolderSocietie = $"{Utility.PathFolderProcessed}\\{nameFolderSocietie}\\{Utility.DateTimeProces}";
            if (!Directory.Exists(pathFolderSocietie))
            {
                Directory.CreateDirectory(pathFolderSocietie);
            }
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

        public bool MoveAllFileFolder(string nameFolderSocietie)
        {
            this.CreateFolderSocietieProcessed(nameFolderSocietie);
            string pathFullLoadColaGenerated = $"{Utility.PathFolderGenerated}\\{nameFolderSocietie}\\{Utility.DateTimeProces}";
            string pathFullLoadColaProcessed = $"{Utility.PathFolderProcessed}\\{nameFolderSocietie}\\{Utility.DateTimeProces}";
            DirectoryInfo directorio = new DirectoryInfo($"{pathFullLoadColaGenerated}");
            string[] extensioFile = Utility.ExtesionFiles?.Split(";");
            FileInfo[] files = directorio.EnumerateFiles().Where(c => extensioFile.Contains(c.Extension.ToLower())).ToArray();
            foreach (var file in files)
            {
                this.DeleteFile($"{pathFullLoadColaProcessed}\\{file.Name}");
                Directory.Move($"{pathFullLoadColaGenerated}\\{file.Name}", $"{pathFullLoadColaProcessed}\\{file.Name}");
            }

            this.logger.LogInformation($"Los archivos se movieron a la carpeta de [ArchivosProcesado] con éxito.\n");

            return true;
        }

        public bool DeleteFolderGenerated(string nameFolderSocietie)
        {
            string pathFullLoadColaGenerated = $"{Utility.PathFolderGenerated}\\{nameFolderSocietie}\\{Utility.DateTimeProces}";
            if (Directory.Exists(pathFullLoadColaGenerated))
            {
                Directory.Delete(pathFullLoadColaGenerated);
            }

            return true;
        }

        private void DeleteFile(string pathFile)
        {
            File.Delete(pathFile);
        }
    }
}