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

        public IEnumerable<CustomerRepoEntitie> GetCustomers(string idEmpresa)
        {
            List<CustomerRepoEntitie> customers;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandTimeout = Utility.ConnectionStringsTimeout;
                command.CommandText = this.configurationQuerySql.Value.ConsultaSQLCliente.Replace("{0}", idEmpresa);

                this.dbContext.Database.OpenConnection();

                using (var resultCustomer = command.ExecuteReader())
                {
                    var enumerable = resultCustomer.Cast<IDataRecord>();
                    customers = enumerable.Select(registro =>
                    new CustomerRepoEntitie
                    {
                        Cod = registro.GetString(0),
                        Nif = registro.GetString(1),
                        Razons = registro.GetString(2),
                        Codcondp = registro.GetString(3),
                        Limitrg = registro.GetDecimal(4),
                        Prov = registro.GetString(5),
                        Dims = registro.GetString(6),
                        Lrcomp = registro.GetInt32(7),
                        Viasp = registro.GetString(8),
                        ClasifContable = registro.GetString(9),
                        LsegCredito = registro.GetDecimal(10),
                        Fchcadsegcred = registro.GetString(11),
                        Tipoentidad = registro.GetString(12),
                        Sector = registro.GetString(13),
                        Fchaltaerp = registro.GetString(14),
                        Fchinitact = registro.GetString(15),
                        Ind1 = registro.GetString(16),
                        Ind2 = registro.GetString(17),
                        Ind3 = registro.GetString(18),
                        Ind4 = registro.GetString(19),
                        Ind5 = registro.GetString(20),
                        Ind6 = registro.GetString(21),
                        Ind7 = registro.GetString(22),
                        Ind8 = registro.GetString(23),
                        Ind9 = registro.GetString(24)
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