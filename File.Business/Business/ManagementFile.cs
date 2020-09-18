namespace File.Business.Business
{
    using CsvHelper;
    using File.Business.IBusiness;
    using File.Utility;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;

    public class ManagementFile : IManagementFile
    {
        public bool CreateFileCsv<T>(string nameFile, IEnumerable<T> datas)
        {
            var path = $"{Utility.PathFolderGenerated}\\{nameFile}.csv";
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

        public bool UnloadFileFtp(string nameFolder)
        {
            DirectoryInfo directorio = new DirectoryInfo($"{Utility.PathAplication}\\{nameFolder}");
            FileInfo[] files = directorio.GetFiles("*.xml");
            string nombreFolderArchivoProcesado = "ArchivoProcesado";
            foreach (var file in files)
            {
                Directory.Move($"{Utility.PathAplication}\\{nameFolder}\\{file.Name}", $"{Utility.PathAplication}\\{nombreFolderArchivoProcesado}\\{file.Name}");
            }

            return true;
        }
    }
}