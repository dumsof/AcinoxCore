namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class PartidasCompensatedPqaRepositorie : RepositorieBase, IPartidasCompensatedPqaRepositorie
    {
        private readonly PQADbContext dbContext;
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public PartidasCompensatedPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.dbContext = new PQADbContext();
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<PartidasCompensatedRepoEntitie> GetPartidasCompensated(string idEmpresa)
        {
            List<PartidasCompensatedRepoEntitie> partidasCompensated;

            //command.CommandText = this.configurationQuerySql.Value.ConsultaSQLPartidasCompensadas;
            var querySql = @"SELECT	
									C.RFC AS codcli
									,CONCAT(F.SerieCFD, '-', F.NumeroCFD) AS ndoc
									,'' AS nvcto -- Falta validar
									,CONVERT(VARCHAR,F.FechaCFD,23) AS fchemi
									,CONVERT(VARCHAR,CXCC.FechaVencimiento,23) AS fchvcto
									,CONVERT(VARCHAR,CXCC.Saldada,23) AS fchcomp
									,CASE M.CodigoMoneda
										WHEN 'USD'
										THEN CXCC.TTotal ELSE CAST((CXCC.TTotal/VC.ValorCambio) AS DECIMAL (12,2))
									END AS importe 
									,CONVERT(VARCHAR,GETDATE(),23) AS marca
									,F.Ttotal AS impmondoc
									,M.CodigoMoneda AS codmondoc
									,'' AS ind1
									,'' AS ind2
									,'' AS ind3
									,'' AS ind4
									,'' AS ind5
									,'' AS ind6
									,'' AS ind7
									,'' AS ind8
									,'' AS ind9
									,'FACTURA' AS tdoc --Validar
									,CONCAT(CONVERT(VARCHAR,GETDATE(),23), '@#', CXCC.SerieDocumento, '@#', CXCC.NumeroDocumento) AS campoid
									,'' AS codejercicio
									,'' AS codejerciciocomp
									,'' AS numdoccobro -- Pendiente realizae fichero partidas compensadas anuladas
									,'' AS numdocorigen
								FROM Facturacion.CFD F
									INNER JOIN Facturacion.CXCCargos CXCC ON CXCC.ID_CFD = F.ID_CFD
									INNER JOIN Corporativo.ClientesSucursales SC ON SC.ID_ClienteSucursal = CXCC.ID_ClienteSucursal
									INNER JOIN Corporativo.Clientes C ON C.ID_Cliente = SC.ID_Cliente
									INNER JOIN Corporativo.Monedas M ON M.ID_Moneda = CXCC.ID_Moneda
									LEFT JOIN Corporativo.ValoresCambios VC ON VC.ID_Moneda = 1  AND VC.FechaCambio = CAST(CXCC.FechaDocumento AS DATE)
									WHERE CXCC.Saldada IS NOT NULL 
									AND CXCC.ID_CXCCargoCancelo IS NULL
									AND F.SerieCFD = 'MZT'
									AND C.ID_Empresa={0}
								UNION ALL
								SELECT	
									C.RFC AS codcli
									,CONCAT(CXCC.SerieDocumento, '-', CXCC.NumeroDocumento) AS ndoc
									,'' AS nvcto -- Validar
									,CONVERT(VARCHAR,CXCA.FechaAbono,23) AS fchemi
									,CONVERT(VARCHAR,CXCC.FechaVencimiento,23) AS fchvcto
									,CONVERT(VARCHAR,CXCC.Saldada,23) AS fchcomp
									,CASE M.CodigoMoneda
										WHEN 'USD'
										THEN CXCC.TTotal ELSE CAST((CXCC.TTotal/VC.ValorCambio) AS DECIMAL (12,2))
									END AS importe 
									,CONVERT(VARCHAR,GETDATE(),23) AS marca
									,CXCA.TTotal AS impmondoc
									,M.CodigoMoneda AS codmondoc
									,'' AS ind1
									,'' AS ind2
									,'' AS ind3
									,'' AS ind4
									,'' AS ind5
									,'' AS ind6
									,'' AS ind7
									,'' AS ind8
									,'' AS ind9
									,'ABONO' AS tdoc --Validar
									,CONCAT(CONVERT(VARCHAR,GETDATE(),23), '@#', CXCC.SerieDocumento, '@#', CXCC.NumeroDocumento) AS campoid
									,'' AS codejercicio
									,'' AS codejerciciocomp
									,'' AS numdoccobro -- Pendiente realizae fichero partidas compensadas anuladas
									,'' AS numdocorigen
								FROM Facturacion.CXCAbonos CXCA
									INNER JOIN Facturacion.CXCCargos CXCC ON CXCC.ID_CXCCargo = CXCA.ID_CXCCargo
									INNER JOIN Facturacion.CFD F ON F.ID_CFD = CXCC.ID_CFD
									INNER JOIN Corporativo.ClientesSucursales SC ON SC.ID_ClienteSucursal = CXCC.ID_ClienteSucursal
									INNER JOIN Corporativo.Clientes C ON C.ID_Cliente = SC.ID_Cliente
									INNER JOIN Corporativo.Monedas M ON M.ID_Moneda = CXCC.ID_Moneda
									LEFT JOIN Corporativo.ValoresCambios VC ON VC.ID_Moneda = 1  AND VC.FechaCambio = CAST(CXCC.FechaDocumento AS DATE)
									WHERE CXCC.Saldada IS NOT NULL 
									AND CXCC.ID_CXCCargoCancelo IS NULL
									AND F.SerieCFD = 'MZT'
									AND C.ID_Empresa={0}
									ORDER BY codcli, ndoc, fchemi";

            using (var resultPartidasCompensated = this.GetAllExecuteReader(string.Format(querySql, idEmpresa)))
            {
                var enumerable = resultPartidasCompensated.Cast<IDataRecord>();
                partidasCompensated = enumerable.Select(registro =>
                new PartidasCompensatedRepoEntitie
                {
                    CodCli = registro.GetString(0),
                    Ndoc = registro.GetString(1),
                    Nvcto = registro.GetString(2),
                    Fchemi = registro.GetString(3),
                    Fchvcto = registro.GetString(4),
                    Fchcomp = registro.GetString(5),
                    Importe = registro.GetDecimal(6),
                    Marca = registro.GetString(7),
                    ImpMonDoc = registro.GetDecimal(8),
                    CodMonDoc = registro.GetString(9),
                    Ind1 = registro.GetString(10),
                    Ind2 = registro.GetString(11),
                    Ind3 = registro.GetString(12),
                    Ind4 = registro.GetString(13),
                    Ind5 = registro.GetString(14),
                    Ind6 = registro.GetString(15),
                    Ind7 = registro.GetString(16),
                    Ind8 = registro.GetString(17),
                    Ind9 = registro.GetString(18),
                    Tdoc = registro.GetString(19),
                    Campoid = registro.GetString(20),
                    CodeJercicio = registro.GetString(21),
                    CodEjercicioComp = registro.GetString(22),
                    NumDocCobro = registro.GetString(23),
                    NumDocOrigen = registro.GetString(24)
                }).ToList();
            }

            return partidasCompensated;
        }
    }
}