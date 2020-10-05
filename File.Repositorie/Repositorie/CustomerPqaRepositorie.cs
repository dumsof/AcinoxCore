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

                command.CommandText = @"SELECT cod=LTRIM(STR(C.ID_Cliente))
	                                          ,nif=C.RFC
	                                          ,razons=C.NombreCliente
	                                          ,codcondp=''
	                                          ,limitrg=0.0
	                                          ,prov=p.NombrePais
	                                          ,dims ='['+(SELECT ',{CodCrite:'+LTRIM(STR(1000+ISNULL(CAC.UsoCategoria,0))),',CodElemen:'+LTRIM(STR(CCC.ID_CategoriaCliente))+'}'
				                                        FROM Corporativo.ClientesCategoriasClientes CCC
				                                        JOIN Corporativo.CategoriasClientes CAC ON CAC.ID_CategoriaCliente=CCC.ID_CategoriaCliente
				                                        WHERE CCC.ID_Cliente=C.ID_Cliente
				                                        FOR XML PATH ('') )+']'
	                                          ,lrcomp=1
	                                          ,viasp=LTRIM(STR(C.DiasCredito))
	                                          ,clasifcontable= CASE WHEN LOWER(LTRIM(P.NombrePais))='Mexico' THEN 'Nacional' ELSE 'Extranjero' END 
	                                          ,lsegcredito=CC.LimiteCredito
	                                          ,fchcadsegcred=(select FORMAT (CC.RegistroAlta, 'yyyy-MM-dd'))
	                                          ,tipoentidad=''
	                                          ,sector=''
	                                          ,fchaltaerp= (select FORMAT (C.RegistroAlta, 'yyyy-MM-dd'))
	                                          ,fchinitact= (select FORMAT (getdate(), 'yyyy-MM-dd'))
	                                          ,ind1=''
	                                          ,ind2=''
	                                          ,ind3=''
	                                          ,ind4=''
	                                          ,ind5=''
	                                          ,ind6=''
	                                          ,ind7=''
	                                          ,ind8=''
	                                          ,ind9=''
                                        FROM [Corporativo].[Clientes] C
                                        JOIN [Corporativo].[ClientesSucursales] CS ON C.ID_Cliente=CS.ID_Cliente
                                        JOIN [Corporativo].[Paises] p ON C.ID_Nacionalidad=P.ID_Pais
                                        JOIN [Facturacion].[CondicionesCreditosClientes] CC ON CC.ID_Cliente=C.ID_Cliente";

                this.dbContext.Database.OpenConnection();

                using (var resultCustomer = command.ExecuteReader())
                {
                    var enumerable = resultCustomer.Cast<IDataRecord>();
                    customers = enumerable.Select(registro =>
                    new CustomerEntitie
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
                        //LsegCredito = registro.GetDecimal(10),
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