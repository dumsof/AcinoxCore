namespace SettingAxesor.AxesorBusiness.Business
{
    using SettingAxesor.AxesorBusiness.IBusiness;
    using SettingAxesor.AxesorRepositorie.IRepositorie;

    public class ConfigurationBusiness : IConfigurationBusiness
    {
        private readonly IConfigurationRepositorie repositorie;

        public ConfigurationBusiness(IConfigurationRepositorie repositorie)
        {
            this.repositorie = repositorie;
        }
        public bool ProbarConexionBaseDato()
        {

            return this.repositorie.ProbarConexionBaseDato();
        }
    }
}