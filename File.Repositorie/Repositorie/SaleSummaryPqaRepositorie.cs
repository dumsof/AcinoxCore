namespace File.Repositorie.Repositorie
{
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class SaleSummaryPqaRepositorie : RepositorieBase, ISaleSummaryPqaRepositorie
    {
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public SaleSummaryPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<SaleSummaryRepoEntitie> GetSaleSummary(string codEmpresa)
        {
            List<SaleSummaryRepoEntitie> saleSumary;
            using (var resultSocietie = this.GetAllExecuteReader(string.Format(this.configurationQuerySql.Value.ConsultaSQLResumenVentas, codEmpresa)))
            {
                var enumerable = resultSocietie.Cast<IDataRecord>();
                saleSumary = enumerable.Select(registro =>
                new SaleSummaryRepoEntitie
                {
                    CodCli = registro.GetString(0),
                    Anio = registro.GetInt32(1),
                    Mes = registro.GetInt32(2),
                    Importe = registro.GetDecimal(3)

                }).ToList();
            }

            return saleSumary;
        }
    }
}