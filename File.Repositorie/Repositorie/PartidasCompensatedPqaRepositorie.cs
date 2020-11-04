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
            var querySql = @"SELECT	LTRIM(STR(C.ID_Cliente)) AS codcli
								,CONCAT(CC.SerieDocumento, '-', CC.NumeroDocumento) AS ndoc
								,'' AS nvcto
								,CONVERT(VARCHAR,CC.FechaDocumento,23) AS fchemi
								,CONVERT(VARCHAR,CC.FechaVencimiento,23) AS fchvcto
								,CONVERT(VARCHAR,CC.Saldada,23) AS fchcomp
								,CASE M.CodigoMoneda
								WHEN 'USD'
								THEN ROUND(F.Ttotal,2) ELSE (SELECT ValorCambio FROM Corporativo.ValoresCambios WHERE FechaCambio = CONVERT(DATE,F.FechaCFD,23)) * F.Ttotal
								END AS importe
								,CONCAT(CONVERT(VARCHAR,GETDATE(),112), '@#', CC.SerieDocumento, '@#', CC.NumeroDocumento) AS marca
								,F.Ttotal AS impmondoc
								,M.CodigoMoneda AS codmondoc
								,F.MetodoPago AS ind1
								,'' AS ind2
								,'' AS ind3
								,'' AS ind4
								,'' AS ind5
								,'' AS ind6
								,'' AS ind7
								,'' AS ind8
								,'' AS ind9
								,F.EfectoCFD AS tdoc
								,'' AS campoid
								,'' AS codejercicio
								,'' AS codejerciciocomp
								,'' AS numdoccobro
								,'' AS numdocorigen
								--,ca.ID_CXCCargo
								--,cc.ID_CXCCargo
							FROM Facturacion.CXCAbonos CA
							INNER JOIN Facturacion.CXCCargos CC ON CC.ID_CXCCargo = CA.ID_CXCCargo
							INNER JOIN Corporativo.ClientesSucursales SC ON SC.ID_ClienteSucursal = CC.ID_ClienteSucursal
							INNER JOIN Corporativo.Clientes C ON C.ID_Cliente = SC.ID_Cliente
							INNER JOIN Corporativo.Monedas M ON M.ID_Moneda = CC.ID_Moneda
							INNER JOIN Facturacion.CFD F ON F.ID_CFD = CC.ID_CFD
							WHERE CC.Saldada IS NOT NULL AND C.ID_Empresa={0}
							ORDER BY C.ID_Cliente ASC";

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