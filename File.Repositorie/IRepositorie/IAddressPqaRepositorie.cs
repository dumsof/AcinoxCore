namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.EntitieRepositorie;
    using System.Collections.Generic;

    public interface IAddressPqaRepositorie
    {
        public IEnumerable<AddressRepoEntitie> GetAddress(string idEmpresa);
    }
}