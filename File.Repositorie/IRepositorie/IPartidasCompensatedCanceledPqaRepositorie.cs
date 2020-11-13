namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.EntitieRepositorie;
    using System.Collections.Generic;

    public interface IPartidasCompensatedCanceledPqaRepositorie
    {
        IEnumerable<PartidasCompensatedCanceledRepoEntitie> GetPartidasCompensatedCanceled(string idEmpresa);
    }
}