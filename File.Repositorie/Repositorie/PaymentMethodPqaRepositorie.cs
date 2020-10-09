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

    public class PaymentMethodPqaRepositorie : IPaymentMethodPqaRepositorie, IDisposable
    {
        private readonly PQADbContext dbContext;
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public PaymentMethodPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.dbContext = new PQADbContext();
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<PaymentMethodRepoEntitie> GetPaymentMethods()
        {
            List<PaymentMethodRepoEntitie> paymentMethod;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandTimeout = Utility.ConnectionStringsTimeout;
                command.CommandText = this.configurationQuerySql.Value.ConsultaSQLFormasPagoCobro;
              
                this.dbContext.Database.OpenConnection();

                using (var resultCustomer = command.ExecuteReader())
                {
                    var enumerable = resultCustomer.Cast<IDataRecord>();
                    paymentMethod = enumerable.Select(registro =>
                    new PaymentMethodRepoEntitie
                    {
                        Cod = registro.GetString(0),
                        Desc = registro.GetString(1),
                        GenCart = registro.GetString(2),
                        Ind1 = registro.GetString(3),
                        Ind2 = registro.GetString(4),
                        NumDias = registro.GetString(5),
                    }).ToList();
                }
            }

            return paymentMethod;
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