namespace File.Business.IBusiness
{
    using File.Entities.sociedad;
    public interface IAddressBusiness
    {
        public void ProcessAddress(SocietieEntitie societie, string nameFileSocietie);
    }
}
