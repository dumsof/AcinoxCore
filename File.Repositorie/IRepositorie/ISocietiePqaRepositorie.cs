namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.DataAccessPqa;
    using System.Collections.Generic;

    public interface ISocietiePqaRepositorie
    {
        public IEnumerable<Empresas> GetEmpresas();
    }
}