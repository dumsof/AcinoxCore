namespace SettingAxesor.AxesorRepositorie.Repositorie
{
    using SettingAxesor.AxesorRepositorie.IRepositorie;
    using System.Data.SqlClient;
    using SettingAxesor.AxesorCrossCutting.Utilities;

    public class ConfigurationRepositorie : IConfigurationRepositorie
    {
        public bool VerifyConnection()
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = Utility.ConnectionStringsSQLServer;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            cnn.Close();

            return true;            
        }
    }
}