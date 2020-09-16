namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.DataAccess;
    using System.Collections.Generic;

    public interface ISocietieRepositorie
    {
        public IEnumerable<Empresas> GetEmpresas();
    }
}
