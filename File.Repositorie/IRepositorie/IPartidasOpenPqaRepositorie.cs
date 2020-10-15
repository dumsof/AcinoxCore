namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.EntitieRepositorie;
    using System.Collections.Generic;

    public interface IPartidasOpenPqaRepositorie
    {
        IEnumerable<PartidasOpenRepoEntitie> GetPartidasOpen();
    }
}