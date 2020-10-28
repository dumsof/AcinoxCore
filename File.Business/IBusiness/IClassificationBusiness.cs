namespace File.Business.IBusiness
{
    using File.Entities.sociedad;

    public interface IClassificationBusiness
    {
        public void ProcessClassification(SocietieEntitie societie, string nameFolderSocietie);
    }
}
