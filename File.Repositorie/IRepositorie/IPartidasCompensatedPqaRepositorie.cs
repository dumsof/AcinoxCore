namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.EntitieRepositorie;
    using System.Collections.Generic;

    public interface IPartidasCompensatedPqaRepositorie
    {
        IEnumerable<PartidasCompensatedRepoEntitie> GetPartidasCompensated();
    }
}