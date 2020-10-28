namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.direccion;
    using File.Entities.sociedad;
    using File.Message;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;

    public class AddressBusiness : IAddressBusiness
    {
        private readonly ILogger<AddressBusiness> logger;
        private readonly IAddressPqaRepositorie addressRepositorie;
        private readonly IMessageManagement messageManagement;

        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private const string nameFileXml = "direcciones";

        public AddressBusiness(ILogger<AddressBusiness> logger, IAddressPqaRepositorie addressRepositorie,
            IMessageManagement messageManagement, IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.addressRepositorie = addressRepositorie;
            this.messageManagement = messageManagement;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessAddress(SocietieEntitie societie, string nameFolderSocietie)
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, nameFolderSocietie }));
            var addres = this.GetAddress(societie.Cod);
            this.GenerateFileXml(addres, nameFolderSocietie);
        }

        private void GenerateFileXml(IEnumerable<AddressEntitie> addres, string nameFolderSocietie)
        {
            if (addres == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<AddressEntitie>(nameFileXml, addres);
            var addressXml = new Address { Direccion = addres.ToList() };
            this.managementFile.CreateFileXml<Address>(nameFileXml, addressXml, nameFolderSocietie);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.CountFileGenerad, new object[] { nameFileXml, addres?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFolderSocietie}\\{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml }));
        }

        private IEnumerable<AddressEntitie> GetAddress(string idEmpresa)
        {
            var address = this.addressRepositorie.GetAddress(idEmpresa);
            var dato = address.Select(c => new AddressEntitie
            {
                CodCliente = c.CodCliente,
                CodDireccion = c.CodDireccion,
                TDireccion = c.TDireccion,
                Domicilio = c.Domicilio,
                Ciudad = c.Ciudad,
                Prov = c.Prov,
                Cp = c.Cp,
                Pais = c.Pais,
                Ind1 = c.Ind1,
                Ind2 = c.Ind2,
                Ind3 = c.Ind3
            }).ToList();

            return dato;
        }
    }
}