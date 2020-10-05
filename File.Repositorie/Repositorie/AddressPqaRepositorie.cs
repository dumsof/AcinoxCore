
namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using File.Utility;
    using System.Data;
    using System.Linq;

    public class AddressPqaRepositorie : IAddressPqaRepositorie, IDisposable
    {
        private readonly PQADbContext dbContext;
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public AddressPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.dbContext = new PQADbContext();
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<AddressRepoEntitie> GetAddress()
        {
            List<AddressRepoEntitie> address;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandTimeout = Utility.ConnectionStringsTimeout;
                //command.CommandText = this.configurationQuerySql.Value.ConsultaSQLCliente;

                command.CommandText = @"SELECT	 LTRIM(STR( CS.id_cliente)) as codcliente 
		                                        ,LTRIM(STR(CS.ID_ClienteSucursal)) as coddireccion 
		                                        ,'0' as tdireccion 
		                                        ,CS.Calle+' '+CS.NumExterior+' ' as domicilio 
		                                        ,CS.Municipio as ciudad 
		                                        ,CS.Localidad as prov 
		                                        ,LTRIM(STR(CS.ID_CodigoPostal)) as cp 
		                                        ,P.NombrePais as pais 
		                                        ,' ' as ind1 
		                                        ,' ' as ind2 
		                                        ,' ' as ind3
                                        FROM Corporativo.ClientesSucursales as CS
                                        JOIN Corporativo.Paises as P on P.ID_Pais=CS.ID_Pais";

                this.dbContext.Database.OpenConnection();

                using (var resultAddress = command.ExecuteReader())
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
            }

            return address;
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
