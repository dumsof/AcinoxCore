namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class PartidasCompensatedCanceledPqaRepositorie : RepositorieBase, IPartidasCompensatedCanceledPqaRepositorie
    {
        private readonly PQADbContext dbContext;
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public PartidasCompensatedCanceledPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.dbContext = new PQADbContext();
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<PartidasCompensatedCanceledRepoEntitie> GetPartidasCompensatedCanceled(string idEmpresa)
        {
            List<PartidasCompensatedCanceledRepoEntitie> partidasCompensatedCanceled;

            //command.CommandText = this.configurationQuerySql.Value.ConsultaSQLPartidasCompensadas;
            var querySql = @"SELECT	'1111','2020-11-13','2020-11-13'";

            using (var resultPartidasCompensated = this.GetAllExecuteReader(string.Format(querySql, idEmpresa)))
            {
                var enumerable = resultPartidasCompensated.Cast<IDataRecord>();
                partidasCompensatedCanceled = enumerable.Select(registro =>
                new PartidasCompensatedCanceledRepoEntitie
                {
                    NumCobro = registro.GetString(0),
                    Fchinv = registro.GetString(1),
                    FchCreacion = registro.GetString(2),

                }).ToList();
            }

            return partidasCompensatedCanceled;
        }
    }
}