namespace File.Repositorie.Repositorie
{
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class PartidasOpenPqaRepositorie : RepositorieBase, IPartidasOpenPqaRepositorie
    {
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public PartidasOpenPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<PartidasOpenRepoEntitie> GetPartidasOpen(string codEmpresa)
        {
            List<PartidasOpenRepoEntitie> partidasOpen;
            //string consultaTemp = this.configurationQuerySql.Value.ConsultaSQLPartidasAbiertas;
            string querySQL = @$"SELECT DISTINCT
		                                 codcli=CLI.RFC
		                                ,ndoc=SerieDocumento+'-'+LTRIM(STR( NumeroDocumento))
		                                ,nvcto=''
		                                ,fchemi=(SELECT FORMAT (CA.FechaDocumento, 'yyyy-MM-dd'))
		                                ,fchvcto=(SELECT FORMAT (CA.FechaVencimiento, 'yyyy-MM-dd'))
		                                ,importe=CASE MO.CodigoMoneda
				                                 WHEN  'USD' THEN  CA.TTotal
				                                 ELSE  CAST((CA.TTotal/C.ValorCambio) AS DECIMAL (12,2))
				                                 END
		                                ,estado=CASE WHEN CA.FechaVencimiento>GETDATE() THEN
							                                 0
					                                 WHEN CA.FechaVencimiento<GETDATE() AND DATEADD(day,CA.DiasCredito,CA.FechaDocumento)<=GETDATE() THEN
							                                 1
					                                 ELSE
							                                 2
					                                 END
		                                ,dotada=0
		                                ,codvp=''
		                                ,codcondp=LTRIM(STR(ISNULL(CP.ID_CondicionPago,0)))
		                                ,codmondoc=MO.CodigoMoneda
		                                ,impmondoc=CA.TTotal
		                                ,ind1=''
		                                ,ind2=''
		                                ,ind3=''
		                                ,ind4=''
		                                ,ind5=''
		                                ,ind6=''
		                                ,ind7=''
		                                ,ind8=''
		                                ,ind9=''
		                                ,tdoc=''
		                                ,campoid=ISNULL(CLI.RFC,'')+'@#'+(SELECT FORMAT (CA.FechaDocumento, 'yyyy-MM-dd HH:MM:ss'))+'@#'+SerieDocumento+'-'+LTRIM(STR( NumeroDocumento))
		                                ,codejercicio=''
		                                ,numdocorigen=''
                                  FROM [Facturacion].[CXCCargos] CA
                                  JOIN Corporativo.ClientesSucursales SU ON SU.ID_ClienteSucursal=CA.ID_ClienteSucursal
                                  JOIN Corporativo.Clientes CLI ON CLI.ID_Cliente=SU.ID_Cliente
                                  JOIN [Corporativo].[Monedas] MO ON MO.ID_Moneda=CA.ID_Moneda
                                  LEFT JOIN Corporativo.ValoresCambios C ON C.ID_Moneda=1  AND C.FechaCambio=CAST(CA.FechaDocumento AS date)
                                  LEFT JOIN Corporativo.CondicionesPagos CP ON CP.Dias=CA.DiasCredito
                                  WHERE CA.CondicionesPago='CREDITO' AND CA.TTotal>0  AND CLI.ID_Empresa={codEmpresa}";

            using (var result = this.GetAll(querySQL))
            {
                var enumResult = result.Cast<IDataRecord>();
                partidasOpen = enumResult.Select(registro =>
                    new PartidasOpenRepoEntitie
                    {
                        CodCli = registro.GetString(0),
                        Ndoc = registro.GetString(1),
                        Nvcto = registro.GetString(2),
                        Fchemi = registro.GetString(3),
                        Fchvcto = registro.GetString(4),
                        Importe = registro.GetDecimal(5),
                        Estado = registro.GetInt32(6),
                        Dotada = registro.GetInt32(7),
                        CodVp = registro.GetString(8),
                        CodConDp = registro.GetString(9),
                        CodMonDoc = registro.GetString(10),
                        ImpMonDoc = registro.GetDecimal(11),
                        Ind1 = registro.GetString(12),
                        Ind2 = registro.GetString(13),
                        Ind3 = registro.GetString(14),
                        Ind4 = registro.GetString(15),
                        Ind5 = registro.GetString(16),
                        Ind6 = registro.GetString(17),
                        Ind7 = registro.GetString(18),
                        Ind8 = registro.GetString(19),
                        Ind9 = registro.GetString(20),
                        Tdoc = registro.GetString(21),
                        Campoid = registro.GetString(22),
                        CodeJercicio = registro.GetString(23),
                        NumDocOrigen = registro.GetString(24)
                    }).ToList();
            }

            return partidasOpen;
        }
    }
}