namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.EntitieRepositorie;
    using System.Collections.Generic;

    public interface IBalancesNoInvoicedPqaRepositorie
    {
        public IEnumerable<BalancesNoInvoicedRepoEntitie> GetBalancesNoInvoiced(string codEmpresa);
    }
}