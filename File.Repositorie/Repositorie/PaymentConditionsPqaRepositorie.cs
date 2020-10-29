namespace File.Repositorie.Repositorie
{
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class PaymentConditionsPqaRepositorie : RepositorieBase, IPaymentConditionsPqaRepositorie
    {
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public PaymentConditionsPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<PaymentConditionRepoEntitie> GetPaymentConditions()
        {
            List<PaymentConditionRepoEntitie> paymentCondition;
            using (var result = this.GetAll(this.configurationQuerySql.Value.ConsultaSQLCondicionPago))
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

            return paymentCondition;
        }
    }
}