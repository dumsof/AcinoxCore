namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccess;
    using File.Repositorie.IRepositorie;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SocietieRepositorie : ISocietieRepositorie, IDisposable
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

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.dbContext.Dispose();
            }            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}