namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.EntitieRepositorie;
    using System.Collections.Generic;

    public interface IPaymentMethodPqaRepositorie
    {
        public IEnumerable<PaymentMethodRepoEntitie> GetPaymentMethods(string idEmpresa);
    }
}