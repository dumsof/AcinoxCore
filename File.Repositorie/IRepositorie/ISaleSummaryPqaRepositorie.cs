namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.EntitieRepositorie;
    using System.Collections.Generic;

    public interface ISaleSummaryPqaRepositorie
    {
        public IEnumerable<SaleSummaryRepoEntitie> GetSaleSummary(string codEmpresa);
    }
}