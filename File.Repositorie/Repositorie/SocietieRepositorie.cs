namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccess;
    using File.Repositorie.IRepositorie;
    using System.Collections.Generic;
    using System.Linq;

    public class SocietieRepositorie : ISocietieRepositorie
    {
        private readonly DdContext dbContext;

        public SocietieRepositorie()
        {
            this.dbContext = new DdContext();
        }

        public IEnumerable<Empresas> GetEmpresas()
        {
            var empresa = this.dbContext.Empresas.ToList();

            return empresa;
        }
    }
}