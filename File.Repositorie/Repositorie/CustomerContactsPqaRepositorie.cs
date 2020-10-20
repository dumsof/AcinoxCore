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
                //command.CommandText = this.configurationQuerySql.Value.ConsultaSQLContactoCliente;

                command.CommandText = @"SELECT DISTINCT
                                                ltrim(str(t2.ID_Cliente)) as codcliente ,
                                                ISNULL(ltrim(str(t2.ID_Cliente))+ltrim(str(t2.ID_ClienteSucursal))+ltrim(str(t1.ID_ClienteSucursalContacto))+ltrim(str(t4.ID_ClienteSucursalContactoTelefono))+ltrim(str(t5.ID_Internet)),'') as codcontacto ,
                                                t1.NombreContacto as nombre ,
                                                t3.RFC as nif ,
                                                ISNULL( (case when (t5.ID_Internet = 1) then '0' when (t5.ID_Internet = 2) then '1' end),'0') as tcontacto ,
                                                t4.NumeroLocal as tlffijo ,
                                                t4.CodigoArea as coddireccion ,
                                                ISNULL((case when (t4.ID_Telefono = 7) then ISNULL(NumeroLocal,'') end),'') as tlfmovil ,
                                                ISNULL((case when (t4.ID_Telefono = 6) then ISNULL(NumeroLocal,'') end),'') as fax ,
                                                t5.CuentaDireccion as email ,
                                                ' ' as ind1 ,
                                                ' ' as ind2 ,
                                                ' ' as ind3
                                        FROM Corporativo.ClientesSucursalesContactos as t1
                                        INNER JOIN Corporativo.ClientesSucursalesContactosTelefonos as t4  ON t1.ID_ClienteSucursalContacto=t4.ID_ClienteSucursalContacto
                                        INNER JOIN Corporativo.ClientesSucursalesContactosInternets as t5  ON t1.ID_ClienteSucursalContacto=t5.ID_ClienteSucursalContacto  AND t5.ID_Internet IN(1,2,3,8,9,12,18)
                                        INNER JOIN Corporativo.ClientesSucursales as t2					   ON t1.ID_ClienteSucursal=t2.ID_ClienteSucursal
                                        INNER JOIN Corporativo.Clientes as t3							   ON t1.ID_ClienteSucursal=t3.ID_Cliente";

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
                        TContacto = registro.GetString(4),
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