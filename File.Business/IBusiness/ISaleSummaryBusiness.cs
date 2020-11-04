namespace File.Business.IBusiness
{
    using File.Entities.sociedad;

    public interface ISaleSummaryBusiness
    {
        public void ProcessSaleSummary(SocietieEntitie societie, string nameFolderSocietie);
    }
}