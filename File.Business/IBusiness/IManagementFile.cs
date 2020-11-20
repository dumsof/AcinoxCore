namespace File.Business.IBusiness
{
    using System.Collections.Generic;

    public interface IManagementFile
    {
        public bool CreateFileCsv<T>(string nameFile, IEnumerable<T> datas, bool crearCsv = false);

        public bool CreateFileXml<T>(string nameFile, T datas, string nameFolderNitSocietie = "");

        public void CreatedPathFile();

        public void MoveFileUpLoadFtp(string nameFileWithExtension);

        public bool MoveAllFileFolder(string nameFolderSocietie);

        bool DeleteFolderGenerated(string nameFolderSocietie);
    }
}