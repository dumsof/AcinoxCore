using System.Collections.Generic;
using System.Xml;

namespace File.Business.IBusiness
{
    public interface IManagementFile
    {
        public bool CreateFileCsv<T>(string nameFile, IEnumerable<T> datas);

        public void CreatedPathFile();

        public void MoveFileUpLoadFtp(string nameFileWithExtension);

        public bool SaveFile(string nameFolder, string nameFile, XmlDocument dataFileXml);

        public bool UnloadFileFtp(string nameFolder);
    }
}