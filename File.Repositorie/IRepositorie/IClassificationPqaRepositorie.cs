namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.DataAccessPqa;
    using System.Collections.Generic;

    public interface IClassificationPqaRepositorie
    {
        public IEnumerable<CategoriasClientes> GetClassification();
    }
}