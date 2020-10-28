namespace File.Business.IBusiness
{
    using File.Entities.sociedad;

    public interface IPartidasOpenBusiness
    {
        public void ProcessPartidasOpen(SocietieEntitie societie, string nameFolderSocietie);
    }
}