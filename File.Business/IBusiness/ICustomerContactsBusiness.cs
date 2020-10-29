namespace File.Business.IBusiness
{
    using File.Entities.sociedad;

    public interface ICustomerContactsBusiness
    {
        public void ProcessContacts(SocietieEntitie societie, string nameFolderSocietie);
    }
}