namespace File.Repositorie.Repositorie
{
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class ClassificationPqaRepositorie : RepositorieBase, IClassificationPqaRepositorie
    {
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public ClassificationPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<ClasificacionRepoEntitie> GetClassification(string codEmpresa)
        {
            List<ClasificacionRepoEntitie> classification;
            var querySql = string.Format(this.configurationQuerySql.Value.ConsultaSQLClasificacion, codEmpresa);
            using (var resultClassification = this.GetAll(querySql))
            {
                var enumerable = resultClassification.Cast<IDataRecord>();
                classification = enumerable.Select(registro =>
                new ClasificacionRepoEntitie
                {
                    Id = registro.GetString(0),
                    Cod = registro.GetString(1),
                    Desc = registro.GetString(2)
                }).ToList();
            }

            return classification;
        }
    }
}