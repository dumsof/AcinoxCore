namespace File.Business.IBusiness
{
    using File.Entities.sociedad;

    public interface IPartidasCompensatedCanceledBusiness
    {
        public void ProcessPartidasCompensatedCanceled(SocietieEntitie societie, string nameFolderSocietie);
    }
}