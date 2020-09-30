namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.EntitieRepositorie;
    using System.Collections.Generic;

    public interface IClassificationPqaRepositorie
    {
        public IEnumerable<ClasificacionRepoEntitie> GetClassification();
    }
}