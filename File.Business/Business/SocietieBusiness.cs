namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities;
    using File.Repositorie.IRepositorie;
    using File.Repositorie.Repositorie;
    using System.Collections.Generic;
    using System.Linq;

    public class SocietieBusiness : ISocietieBusiness
    {
        private readonly ISocietieRepositorie societieRepositorie;

        public SocietieBusiness()
        {
            this.societieRepositorie = new SocietieRepositorie();
        }

        public IEnumerable<SocietieEntitie> GetSocieties()
        {
            var empresa = this.societieRepositorie.GetEmpresas();

            var societie = empresa.Select(c => new SocietieEntitie
            {
                Cod = c.Codigo,
                Razons = c.Descripcion,
                Nif = c.Nit,
                CodMoneda = "01"
            }).ToList();

            return societie;
        }
    }
}
