namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
    using File.Repositorie.EntitieRepositorie;
    using File.Utility;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class PartidasOpenPqaRepositorie
    {
        private readonly PQADbContext dbContext;
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public PartidasOpenPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.dbContext = new PQADbContext();
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<PartidasOpenRepoEntitie> GetPartidasOpen()
        {
            List<PartidasOpenRepoEntitie> partidasOpen;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandTimeout = Utility.ConnectionStringsTimeout;
                command.CommandText = this.configurationQuerySql.Value.ConsultaSQLPartidasAbiertas;

                this.dbContext.Database.OpenConnection();

                using (var resultCustomer = command.ExecuteReader())
                {
                    var enumerable = resultCustomer.Cast<IDataRecord>();
                    partidasOpen = enumerable.Select(registro =>
                    new PartidasOpenRepoEntitie
                    {
                        CodCli = registro.GetString(0),
                        Ndoc = registro.GetString(1),
                        Nvcto = registro.GetString(2),
                        Fchemi = registro.GetString(3),
                        Fchvcto = registro.GetString(4),
                        Importe = registro.GetDecimal(5),
                        Estado = registro.GetInt16(6),
                        Dotada = registro.GetInt16(7),
                        CodVp = registro.GetString(8),
                        CodConDp = registro.GetString(9),
                        CodMonDoc = registro.GetString(10),
                        ImpMonDoc = registro.GetDecimal(11),
                        Ind1 = registro.GetString(12),
                        Ind2 = registro.GetString(13),
                        Ind3 = registro.GetString(14),
                        Ind4 = registro.GetString(15),
                        Ind5 = registro.GetString(16),
                        Ind6 = registro.GetString(17),
                        Ind7 = registro.GetString(18),
                        Ind8 = registro.GetString(19),
                        Ind9 = registro.GetString(20),
                        Tdoc = registro.GetString(21),
                        Campoid = registro.GetString(22),
                        CodeJercicio = registro.GetString(23),
                        NumDocOrigen = registro.GetString(24)
                    }).ToList();
                }
            }

            return partidasOpen;
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