namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.contactosCliente;
    using File.Entities.sociedad;
    using File.Message;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;
    using File.Utility;

    public class CustomerContactsBusiness : ICustomerContactsBusiness
    {
        private readonly ILogger<CustomerContactsBusiness> logger;
        private readonly ICustomerContactsPqaRepositorie customerContactsRepositorie;
        private readonly IMessageManagement messageManagement;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private const string nameFileXml = "contactos";

        public CustomerContactsBusiness(ILogger<CustomerContactsBusiness> logger, ICustomerContactsPqaRepositorie customerContactsRepositorie,
            IMessageManagement messageManagement, IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.customerContactsRepositorie = customerContactsRepositorie;
            this.messageManagement = messageManagement;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessContacts(SocietieEntitie societie, string nameFolderSocietie)
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, nameFolderSocietie }));
            var contacts = this.GetContacts(societie.Cod);
            this.GenerateFileXml(contacts, nameFolderSocietie);
        }

        private void GenerateFileXml(IEnumerable<CustomerContactsEntitie> contacts, string nameFolderSocietie)
        {
            if (contacts == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<CustomerContactsEntitie>(nameFileXml, contacts);
            var contactsXml = new CustomerContacts { Contactos = contacts.ToList() };
            this.managementFile.CreateFileXml<CustomerContacts>(nameFileXml, contactsXml, nameFolderSocietie);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.CountFileGenerad, new object[] { nameFileXml, contacts?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFolderSocietie}\\{Utility.DateTimeProces}\\{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml }));
        }

        private IEnumerable<CustomerContactsEntitie> GetContacts(string idEmpresa)
        {
            var contacts = this.customerContactsRepositorie.GetContacts(idEmpresa);
            var dato = contacts.Select(c => new CustomerContactsEntitie
            {
                CodCliente = c.CodCliente,
                CodContacto = c.CodContacto,
                Nombre = c.Nombre,
                Nif = c.Nif,
                TContacto = c.TContacto,
                CodDireccion = c.CodDireccion,
                TlFfijo = c.TlFfijo,
                TlfMovil = c.TlfMovil,
                Fax = c.Fax,
                Email = c.Email,
                Ind1 = c.Ind1,
                Ind2 = c.Ind2,
                Ind3 = c.Ind3
            }).ToList();

            return dato;
        }
    }
}