namespace File.Business.Business
{
    using CsvHelper;
    using File.Business.IBusiness;
    using File.Utility;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class ManagementFile : IManagementFile
    {
        public bool CreateFileCsv<T>(string nameFile, IEnumerable<T> datas)
        {
            var path = $"{Utility.PathFileGenerated}\\{nameFile}.csv";
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

        public bool SaveFile(string nameFolder, string nameFile, XmlDocument dataFileXml)
        {
            //FileStream fileStream = new FileStream("file.xml", FileMode.Create);
            //XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            //XmlWriter writer = XmlWriter.Create(fileStream, settings);

            dataFileXml.Save($"{Utility.PathAplication}\\{nameFolder}\\{nameFile}");

            return true;
        }

        public void CreatedPathFile()
        {
            if (!Directory.Exists(Utility.PathFileGenerated))
            {
                Directory.CreateDirectory(Utility.PathFileGenerated);
            }
            if (!Directory.Exists(Utility.PathFileProcessed))
            {
                Directory.CreateDirectory(Utility.PathFileProcessed);
            }
        }

        public void MoveFileUpLoadFtp(string nameFileWithExtension)
        {
            string pathFileGenerated = Utility.PathFileGenerated ;
            string pathFileProcessed = Utility.PathFileProcessed;
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