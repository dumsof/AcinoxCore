using System.Collections.Generic;

namespace File.Business.IBusiness
{
    public interface IManagementFile
    {
        public bool CreateFileCsv<T>(string nameFile, IEnumerable<T> datas);

        public bool CreateFileXml<T>(string nameFile, T datas);

        public void CreatedPathFile();

        public void MoveFileUpLoadFtp(string nameFileWithExtension);

        public bool MoveAllFileFolder();
    }
}