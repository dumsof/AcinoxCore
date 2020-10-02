namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class ClassificationPqaRepositorie : IClassificationPqaRepositorie
    {
        private readonly PQADbContext dbContext;
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public ClassificationPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.dbContext = new PQADbContext();
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<ClasificacionRepoEntitie> GetClassification()
        {
            List<ClasificacionRepoEntitie> classification;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = this.configurationQuerySql.Value.ConsultaSQLClasificacion;

                this.dbContext.Database.OpenConnection();

                using (var resultClassification = command.ExecuteReader())
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
            }

            return classification;
        }
    }
}