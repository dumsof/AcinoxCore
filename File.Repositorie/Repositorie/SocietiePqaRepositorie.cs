namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
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

        public IEnumerable<Empresas> GetEmpresas()
        {
            List<Empresas> societie;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"SELECT cod          =SUBSTRING(STR(ID_Empresa),1,64)
                                              ,razons		=SUBSTRING(NombreEmpresa,1,255)
	                                          ,nif		    =SUBSTRING(RFC,1,32)
	                                          ,codmoneda	=SUBSTRING('',1,32)
                                        FROM [Corporativo].[Empresas]";
                this.dbContext.Database.OpenConnection();

                using (var resultSocietie = command.ExecuteReader())
                {
                    var enumerable = resultSocietie.Cast<IDataRecord>();
                    societie = enumerable.Select(registro =>
                    new Empresas
                    {
                        IdEmpresa = Convert.ToInt64(registro.GetString(0)),
                        NombreEmpresa = registro.GetString(1),
                        Rfc = registro.GetString(2)
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