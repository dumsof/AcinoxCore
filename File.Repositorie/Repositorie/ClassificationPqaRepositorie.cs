namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using File.Utility;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class ClassificationPqaRepositorie : IClassificationPqaRepositorie, IDisposable
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
                command.CommandTimeout = Utility.ConnectionStringsTimeout;
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

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.dbContext.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}