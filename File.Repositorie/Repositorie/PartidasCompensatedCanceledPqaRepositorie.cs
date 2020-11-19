namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class PartidasCompensatedCanceledPqaRepositorie : RepositorieBase, IPartidasCompensatedCanceledPqaRepositorie
    {
        private readonly PQADbContext dbContext;
        private readonly IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql;

        public PartidasCompensatedCanceledPqaRepositorie(IOptions<ConfiguracionQuerySqlPqa> configurationQuerySql)
        {
            this.dbContext = new PQADbContext();
            this.configurationQuerySql = configurationQuerySql;
        }

        public IEnumerable<PartidasCompensatedCanceledRepoEntitie> GetPartidasCompensatedCanceled(string idEmpresa)
        {
            List<PartidasCompensatedCanceledRepoEntitie> partidasCompensatedCanceled;

            //command.CommandText = this.configurationQuerySql.Value.ConsultaSQLPartidasCompensadas;
            var querySql = @$" SELECT DISTINCT
		                        numcobro=CA.SerieDocumento+'-'+LTRIM(STR( CA.NumeroDocumento)) 
		                        ,fchinv=(SELECT FORMAT (CA.FechaDocumento, 'yyyy-MM-dd'))
		                        ,fchcreacion=ISNULL((SELECT TOP 1 FORMAT (CX.FechaDocumento, 'yyyy-MM-dd') 
						                        FROM Facturacion.CXCCargos CX 
						                        WHERE CX.TTotal<0 AND CX.ID_CXCCargoCancelo IS NOT NULL AND CX.ID_ClienteSucursal=CA.ID_ClienteSucursal AND CX.SerieDocumento=CA.SerieDocumento AND CX.NumeroDocumento=CA.NumeroDocumento
						                        ORDER BY CX.FechaDocumento DESC),'')   
                         FROM Facturacion.CXCCargos CA
                         JOIN Corporativo.ClientesSucursales SU ON SU.ID_ClienteSucursal=CA.ID_ClienteSucursal
                         JOIN Corporativo.Clientes CLI ON CLI.ID_Cliente=SU.ID_Cliente
                         WHERE ID_CXCCargoCancelo IS NOT NULL 
                         AND (CA.FechaDocumento BETWEEN DATEADD(MONTH,-36,GETDATE()) AND GETDATE())
                         AND CA.TTotal>0 AND CLI.ID_Empresa={idEmpresa.Trim()}
                         ORDER BY fchinv DESC";

            using (var resultPartidasCompensated = this.GetAllExecuteReader(string.Format(querySql, idEmpresa)))
            {
                var enumerable = resultPartidasCompensated.Cast<IDataRecord>();
                partidasCompensatedCanceled = enumerable.Select(registro =>
                new PartidasCompensatedCanceledRepoEntitie
                {
                    NumCobro = registro.GetString(0),
                    Fchinv = registro.GetString(1),
                    FchCreacion = registro.GetString(2),

                }).ToList();
            }

            return partidasCompensatedCanceled;
        }
    }
}