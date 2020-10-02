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


    public class CustomerPqaRepositorie : ICustomerPqaRepositorie, IDisposable
    {
        private readonly PQADbContext dbContext;
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public CustomerPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.dbContext = new PQADbContext();
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<CustomerEntitie> GetCustomers()
        {
            List<CustomerEntitie> customers;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandTimeout = Utility.ConnectionStringsTimeout;
                //command.CommandText = this.configurationQuerySql.Value.ConsultaSQLCliente;

                command.CommandText = @"SELECT top 1 cod=C.ID_Cliente,nif=C.RFC,razons=C.NombreCliente FROM [Corporativo].[Clientes] C";
                                       

                this.dbContext.Database.OpenConnection();

                using (var resultCustomer = command.ExecuteReader())
                {
                    var enumerable = resultCustomer.Cast<IDataRecord>();
                    customers = enumerable.Select(registro =>
                    new CustomerEntitie
                    {
                        Cod = registro.GetString(0)
                        //Nif = registro.GetString(1),
                        //Razons = registro.GetString(2),
                        //Codcondp= registro.GetString(3),
                        //Limitrg=registro.GetDecimal(4),
                        //Prov=registro.GetString(5),
                        //Dims=registro.GetString(6)

                    }).ToList();
                }
            }

            return customers;
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