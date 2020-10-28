namespace File.Repositorie.Repositorie
{
    using File.Repositorie.DataAccessPqa;
    using File.Repositorie.IRepositorie;
    using File.Utility;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Data.Common;

    public class RepositorieBase : IRepositorieBase, IDisposable
    {
        private readonly PQADbContext dbContext;

        public RepositorieBase()
        {
            this.dbContext = new PQADbContext();
        }

        public DbDataReader GetAll(string querySQL)
        {
            using (var command = this.dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandTimeout = Utility.ConnectionStringsTimeout;
                command.CommandText = querySQL;
                this.dbContext.Database.OpenConnection();

                return command.ExecuteReader();               
            }
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