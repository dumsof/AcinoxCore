namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class SocietiePqaRepositorie : ISocietiePqaRepositorie, IDisposable
    {
        private readonly PQADbContext dbContext;
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public SocietiePqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.dbContext = new PQADbContext();
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<EmpresasRepoEntitie> GetEmpresas()
        {
            //si no hay forma de identificar que es lo nuevo se debe partir los archivos para que se generen 10 mil registros.

            List<EmpresasRepoEntitie> societie;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = this.configurationQuerySql.Value.ConsultaSQLSociedad;

                this.dbContext.Database.OpenConnection();

                using (var resultSocietie = command.ExecuteReader())
                {
                    var enumerable = resultSocietie.Cast<IDataRecord>();
                    societie = enumerable.Select(registro =>
                    new EmpresasRepoEntitie
                    {
                        Cod = registro.GetString(0),
                        Razons = registro.GetString(1),
                        Nif = registro.GetString(2),
                        CodMoneda = registro.GetString(3),
                    }).ToList();
                }
            }

            return societie;
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