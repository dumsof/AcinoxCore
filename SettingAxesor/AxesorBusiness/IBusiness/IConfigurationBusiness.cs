﻿namespace SettingAxesor.AxesorBusiness.IBusiness
{
    using SettingAxesor.AxesorCrossCutting.Entitie;
    using System;

    public interface IConfigurationBusiness
    {
        bool VerifyConnection(ConfiguracionStringsServerDataBaseEntitie serverDataBaseEntitie);

        bool VerifyConnectionFtp(ConfiguracionFtpEntitie configuracionFtp);

        bool SaveConfigurationDataBase(ConfiguracionStringsServerDataBaseEntitie serverDataBaseEntitie);

        bool SaveConfigurationFtp(ConfiguracionStringsServerDataBaseEntitie serverDataBaseEntitie);

        bool SaveConfigurationHours(ConfiguracionHoraEjecucionProcesoEntitie configuracionHoraEjecucion);

        Tuple<ConfiguracionStringsServerDataBaseEntitie, ConfiguracionFtpEntitie, ConfiguracionHoraEjecucionProcesoEntitie> LoadValueControl();
    }
}