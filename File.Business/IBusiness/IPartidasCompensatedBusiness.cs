namespace File.Business.IBusiness
{
    using File.Entities.sociedad;

    public interface IPartidasCompensatedBusiness
    {
        public void ProcessPartidasCompensated(SocietieEntitie societie, string nameFolderSocietie);
    }
}