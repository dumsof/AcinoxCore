namespace File.Business.IBusiness
{
    public interface IManagementFtp
    {
        public bool UnloadFileFtp(string nameFileExtension);

        public bool UnloadAllFileFolderFtp();
    }
}