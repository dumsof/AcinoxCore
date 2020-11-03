namespace File.Repositorie.Repositorie
{
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class PaymentMethodPqaRepositorie : RepositorieBase, IPaymentMethodPqaRepositorie
    {
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public PaymentMethodPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<PaymentMethodRepoEntitie> GetPaymentMethods(string idEmpresa)
        {
            List<PaymentMethodRepoEntitie> paymentMethod;

            using (var resultCustomer = this.GetAllExecuteReader(string.Format(this.configurationQuerySql.Value.ConsultaSQLFormasPagoCobro, idEmpresa)))
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

            return paymentMethod;
        }
    }
}