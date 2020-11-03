namespace File.Repositorie.Repositorie
{
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class SocietiePqaRepositorie : RepositorieBase, ISocietiePqaRepositorie
    {
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public SocietiePqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<EmpresasRepoEntitie> GetEmpresas()
        {
            List<EmpresasRepoEntitie> societie;
            using (var resultSocietie = this.GetAllExecuteReader(this.configurationQuerySql.Value.ConsultaSQLSociedad))
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

            return societie;
        }
    }
}