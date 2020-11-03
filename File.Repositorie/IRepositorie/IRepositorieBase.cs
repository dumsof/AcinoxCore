namespace File.Repositorie.IRepositorie
{
    using System.Data.Common;

    public interface IRepositorieBase
    {
        DbDataReader GetAllExecuteReader(string querySQL);
    }
}