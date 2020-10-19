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

    public class PaymentConditionsPqaRepositorie : IPaymentConditionsPqaRepositorie, IDisposable
    {
        private readonly PQADbContext dbContext;
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public PaymentConditionsPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.dbContext = new PQADbContext();
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<PaymentConditionRepoEntitie> GetPaymentConditions()
        {
            List<PaymentConditionRepoEntitie> paymentCondition;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandTimeout = Utility.ConnectionStringsTimeout;
                //command.CommandText = this.configurationQuerySql.Value.ConsultaSQLCondicionPago;
                command.CommandText = @"SELECT  cod		=LTRIM(STR(CP.ID_CondicionPago))
                                              ,[desc]	=CP.NombreCondicionPago
                                              ,plazos='['+(SELECT ',{Dsc:""'+LTRIM(STR(Dias)) + ' días""'
						                                          ,',Dias:' +LTRIM(STR(Dias))
						                                          ,',Porc:'+'100'
						                                          ,',CodVia:'+LTRIM(STR(ID_CondicionPago))
						                                          ,',Codp:'+LTRIM(STR(Dias)) +'}'
					                                        FROM PQA.Corporativo.CondicionesPagos
					                                        WHERE Dias=CP.Dias AND ID_CondicionPago=CP.ID_CondicionPago
					                                        FOR XML PATH (''))+']' 	  
                                        FROM PQA.Corporativo.CondicionesPagos CP";

                this.dbContext.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var enumerable = result.Cast<IDataRecord>();
                    paymentCondition = enumerable.Select(registro =>
                    new PaymentConditionRepoEntitie
                    {
                        Cod = registro.GetString(0),
                        Desc = registro.GetString(1),
                        Plazos = registro.GetString(2)

                    }).ToList();
                }
            }

            return paymentCondition;
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