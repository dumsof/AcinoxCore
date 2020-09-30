namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class SocietiePqaRepositorie : ISocietiePqaRepositorie, IDisposable
    {
        private readonly PQADbContext dbContext;

        public SocietiePqaRepositorie()
        {
            this.dbContext = new PQADbContext();
        }

        public IEnumerable<EmpresasRepoEntitie> GetEmpresas()
        {
            //si no hay forma de identificar que es lo nuevo se debe partir los archivos para que se generen 10 mil registros.

            List<EmpresasRepoEntitie> societie;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"SELECT DISTINCT
	                                         cod		=SUBSTRING(STR(E.ID_Empresa),1,64)
	                                        ,razons		=SUBSTRING(ISNULL(E.NombreEmpresa,''),1,255)
	                                        ,nif		=SUBSTRING(ISNULL(E.RFC,''),1,32)
	                                        ,codmoneda	=SUBSTRING(ISNULL(M.CodigoMoneda,''),1,32)
                                        FROM [Corporativo].[Empresas] E
                                        JOIN [Facturacion].[TiposPagosPOSEmpresasSucursales] TP ON E.ID_Empresa=TP.ID_Empresa
                                        JOIN [Facturacion].[TiposPagosPOS] TPP ON TP.ID_TipoPago=TP.ID_TipoPago
                                        JOIN [Corporativo].[Monedas] M ON TPP.ID_Moneda=M.ID_Moneda
                                        --WHERE UPPER(LTRIM(CodigoMoneda))='MXP'
                                        ORDER BY cod ASC";
                this.dbContext.Database.OpenConnection();

                using (var resultSocietie = command.ExecuteReader())
                {
                    var enumerable = resultSocietie.Cast<IDataRecord>();
                    societie = enumerable.Select(registro =>
                    new EmpresasRepoEntitie
                    {
                        Cod = registro.GetString(0),
                        Razons = registro.GetString(1),
                        Nif = registro.GetString(2),
                        CodMoneda = registro.GetString(3),
                    }).ToList();
                }
            }

            return societie;
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