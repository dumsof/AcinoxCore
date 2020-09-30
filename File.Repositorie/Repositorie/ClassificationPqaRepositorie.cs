namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
    using File.Repositorie.EntitieRepositorie;
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

        public IEnumerable<ClasificacionRepoEntitie> GetClassification()
        {
            List<ClasificacionRepoEntitie> classification;

            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"SELECT DISTINCT
                                           id= str(1000 + UsoCategoria)
                                          ,cod=SUBSTRING(ISNULL(STR(ID_CategoriaCliente),''),1,64)
                                          ,[desc]=SUBSTRING(ISNULL(NombreCategoriaCliente,''),1,255)
                                        FROM [Corporativo].CategoriasClientes
                                        ORDER BY cod ASC";
                this.dbContext.Database.OpenConnection();

                using (var resultClassification = command.ExecuteReader())
                {
                    var enumerable = resultClassification.Cast<IDataRecord>();
                    classification = enumerable.Select(registro =>
                    new ClasificacionRepoEntitie
                    {
                        Id = registro.GetString(0),
                        Cod = registro.GetString(1),
                        Desc = registro.GetString(2)
                    }).ToList();
                }
            }

            return classification;
        }
    }
}