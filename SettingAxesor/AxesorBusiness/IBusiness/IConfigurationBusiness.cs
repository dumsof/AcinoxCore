namespace SettingAxesor.AxesorBusiness.IBusiness
{
    using SettingAxesor.AxesorCrossCutting.Entitie;

    public interface IConfigurationBusiness
    {
        bool VerifyConnection(ConnectionStringsServerDataBaseEntitie serverDataBaseEntitie);
        bool SaveConfigurationDataBase(ConnectionStringsServerDataBaseEntitie serverDataBaseEntitie);
        bool SaveConfigurationHours(ConfiguracionHoraEjecucionProcesoEntitie configuracionHoraEjecucion);
    }
}