namespace File.Business.IBusiness
{
    using File.Entities.sociedad;

    public interface IPaymentMethodBusiness
    {
        public void ProcessPaymentMethod(SocietieEntitie societie, string nameFolderSocietie);
    }
}