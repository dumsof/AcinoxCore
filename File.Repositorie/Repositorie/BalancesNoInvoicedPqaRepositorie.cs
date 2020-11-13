
namespace File.Repositorie.Repositorie
{
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using System.Collections.Generic;

    public class BalancesNoInvoicedPqaRepositorie : RepositorieBase, IBalancesNoInvoicedPqaRepositorie
    {
        public IEnumerable<BalancesNoInvoicedRepoEntitie> GetBalancesNoInvoiced(string codEmpresa)
        {
            throw new System.NotImplementedException();
        }
    }
}