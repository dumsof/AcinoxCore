namespace SettingAxesor.AxesorRepositorie.IRepositorie
{
    using SettingAxesor.AxesorCrossCutting.Entitie;

    public interface IConfigurationRepositorie
    {
        bool VerifyConnection(ConnectionStringsServerDataBaseEntitie serverDataBaseEntitie);
    }
}