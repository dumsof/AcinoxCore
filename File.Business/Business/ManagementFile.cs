

namespace File.Business.Business
{
    using File.Business.IBusiness;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using File.Utility;
    using System.Text;
    using System.Linq;
    using System.Xml;

    public class ManagementFile : IManagementFile
    {
        public bool SaveFile(string nameFolder, string nameFile, XmlDocument dataFileXml)
        {
            //FileStream fileStream = new FileStream("file.xml", FileMode.Create);
            //XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            //XmlWriter writer = XmlWriter.Create(fileStream, settings);

            dataFileXml.Save($"{Utility.PathAplication}\\{nameFolder}\\{nameFile}");

            return true;
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
