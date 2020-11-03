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
			var querySql = @"SELECT DISTINCT
												 codcli=CLI.RFC
												,ndoc=SerieDocumento+' '+LTRIM(STR( NumeroDocumento))
												,nvcto=''
												,fchemi='2014-01-02'
												,fchvcto='2014-01-02'
												,importe=0.0
												,estado=2
												,dotada=1
												,codvp=''
												,codcondp=''
												,codmondoc=''
												,impmondoc=0.0
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
												,campoid=''
												,codejercicio=''
												,numdocorigen=0.0
										  FROM [Facturacion].[CXCCargos] CA
										  JOIN Corporativo.ClientesSucursales SU ON SU.ID_ClienteSucursal=CA.ID_ClienteSucursal
										  JOIN Corporativo.Clientes CLI ON CLI.ID_Cliente=SU.ID_Cliente
										  WHERE CLI.ID_Empresa={0}";

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