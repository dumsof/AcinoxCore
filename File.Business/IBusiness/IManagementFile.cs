using System.Xml;

namespace File.Business.IBusiness
{
    public interface IManagementFile
    {
        public bool SaveFile(string nameFolder, string nameFile, XmlDocument dataFileXml);

        public bool UnloadFileFtp(string nameFolder);
    }
}