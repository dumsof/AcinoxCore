namespace File.Business.IBusiness
{
    using File.Entities.sociedad;

    public interface IPaymentConditionBusiness
    {
        void ProcessPaymentCondition(SocietieEntitie societie, string nameFolderSocietie);
    }
}