

namespace File.Business.IBusiness
{
    using File.Entities.sociedad;
    using System.Collections.Generic;

    public interface ISocietieBusiness
    {
        public IEnumerable<SocietieEntitie> GetEmpresas();
       

        public void ProcessSocietie(string nameFolderSocietie);
    }
}