namespace File.Repositorie.Repositorie
{
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class AddressPqaRepositorie : RepositorieBase, IAddressPqaRepositorie
    {
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public AddressPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<AddressRepoEntitie> GetAddress(string idEmpresa)
        {
            List<AddressRepoEntitie> address;

            var querySql = string.Format(this.configurationQuerySql.Value.ConsultaSQLDireccion, idEmpresa);

            using (var resultAddress = this.GetAll(querySql))
            {
                var enumerable = resultAddress.Cast<IDataRecord>();
                address = enumerable.Select(registro =>
                new AddressRepoEntitie
                {
                    CodCliente = registro.GetString(0),
                    CodDireccion = registro.GetString(1),
                    TDireccion = registro.GetString(2),
                    Domicilio = registro.GetString(3),
                    Ciudad = registro.GetString(4),
                    Prov = registro.GetString(5),
                    Cp = registro.GetString(6),
                    Pais = registro.GetString(7),
                    Ind1 = registro.GetString(8),
                    Ind2 = registro.GetString(9),
                    Ind3 = registro.GetString(10),
                }).ToList();
            }

            return address;
        }
    }
}