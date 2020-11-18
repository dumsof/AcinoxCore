namespace SettingAxesor.AxesorRepositorie.Repositorie
{
    using SettingAxesor.AxesorRepositorie.IRepositorie;
    using System.Data.SqlClient;
    using SettingAxesor.AxesorCrossCutting.Utilities;
    using SettingAxesor.AxesorCrossCutting.Entitie;

    public class ConfigurationRepositorie : IConfigurationRepositorie
    {
        public bool VerifyConnection(ConfiguracionStringsServerDataBaseEntitie serverDataBaseEntitie)
        {
            SqlConnection cnn;
            string connetionString = Utility.ConnectionStringsSQLServer;

            connetionString = string.Format(connetionString, serverDataBaseEntitie.NombreServidor,
                serverDataBaseEntitie.UsuarioBaseDato, serverDataBaseEntitie.PasswordUsuarioBaseDato,
                serverDataBaseEntitie.NombreBaseDato, serverDataBaseEntitie.TimeOut);

            cnn = new SqlConnection(connetionString);
            cnn.Open();
            cnn.Close();

            return true;
        }
    }
}