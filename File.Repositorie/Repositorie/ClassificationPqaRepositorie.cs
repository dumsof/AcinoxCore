namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
    using File.Repositorie.IRepositorie;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class ClassificationPqaRepositorie : IClassificationPqaRepositorie
    {
        private readonly PQADbContext dbContext;

        public ClassificationPqaRepositorie()
        {
            this.dbContext = new PQADbContext();
        }

        public IEnumerable<CategoriasClientes> GetClassification()
        {
            List<CategoriasClientes> classification;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"SELECT  DISTINCT
                                                cod=SUBSTRING(ISNULL(STR(ID_CategoriaCliente),''),1,64)
                                                ,[desc]=SUBSTRING(ISNULL(NombreCategoriaCliente,''),1,255)
                                        FROM [Corporativo].CategoriasClientes
                                        ORDER BY [desc] ASC";
                this.dbContext.Database.OpenConnection();

                using (var resultClassification = command.ExecuteReader())
                {
                    var enumerable = resultClassification.Cast<IDataRecord>();
                    classification = enumerable.Select(registro =>
                    new CategoriasClientes
                    {
                        IdCategoriaCliente = long.Parse(registro.GetString(0)),
                        NombreCategoriaCliente = registro.GetString(1)
                    }).ToList();
                }
            }

            return classification;
        }
    }
}