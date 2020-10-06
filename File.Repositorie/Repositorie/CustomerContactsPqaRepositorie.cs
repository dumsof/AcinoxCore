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

    public class CustomerContactsPqaRepositorie : ICustomerContactsPqaRepositorie, IDisposable
    {
        private readonly PQADbContext dbContext;
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public CustomerContactsPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.dbContext = new PQADbContext();
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<CustomerContactsRepoEntitie> GetContacts()
        {
            List<CustomerContactsRepoEntitie> customers;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandTimeout = Utility.ConnectionStringsTimeout;
                //command.CommandText = this.configurationQuerySql.Value.ConsultaSQLCliente;

                command.CommandText = @"SELECT   codcliente		=LTRIM(STR(CS.ID_Cliente))
		                                        ,codcontacto	=LTRIM(STR(CSC.ID_ClienteSucursalContacto))
		                                        ,nombre			=CSC.NombreContacto
		                                        ,nif			=C.RFC
		                                        ,tcontacto		=0
		                                        ,coddireccion	=CS.Calle+' '+CS.NumExterior
		                                        ,tlffijo		=''
		                                        ,' ' as tlfmovil 
		                                        ,' ' as fax 
		                                        ,' ' as email 
		                                        ,' ' as ind1 
		                                        ,' ' as ind2 
		                                        ,' ' as ind3
                                        FROM Corporativo.ClientesSucursalesContactos CSC
                                        JOIN Corporativo.ClientesSucursales CS							ON CSC.ID_ClienteSucursal=CSC.ID_ClienteSucursal
                                        JOIN Corporativo.Clientes C										ON  C.ID_Cliente=CS.ID_Cliente";

                this.dbContext.Database.OpenConnection();

                using (var resultAddress = command.ExecuteReader())
                {
                    var enumerable = resultAddress.Cast<IDataRecord>();
                    customers = enumerable.Select(registro =>
                    new CustomerContactsRepoEntitie
                    {
                        CodCliente = registro.GetString(0),
                        CodContacto = registro.GetString(1),
                        Nombre = registro.GetString(2),
                        Nif = registro.GetString(3),
                        TContacto = registro.GetInt32(4),
                        CodDireccion = registro.GetString(5),
                        TlFfijo = registro.GetString(6),
                        TlfMovil = registro.GetString(7),
                        Fax = registro.GetString(8),
                        Email = registro.GetString(9),
                        Ind1 = registro.GetString(10),
                        Ind2 = registro.GetString(11),
                        Ind3 = registro.GetString(12),
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