namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.EntitieRepositorie;
    using System.Collections.Generic;

    public interface ICustomerPqaRepositorie
    {
        public IEnumerable<CustomerRepoEntitie> GetCustomers(string idEmpresa);
    }
}