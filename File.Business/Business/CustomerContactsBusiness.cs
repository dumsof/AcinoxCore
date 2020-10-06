
namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.contactosCliente;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerContactsBusiness : ICustomerContactsBusiness
    {
        private readonly ILogger<CustomerContactsBusiness> logger;
        private readonly ICustomerContactsPqaRepositorie customerContactsRepositorie;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private const string nameFileXml = "contactos";

        public CustomerContactsBusiness(ILogger<CustomerContactsBusiness> logger, ICustomerContactsPqaRepositorie customerContactsRepositorie,
            IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.customerContactsRepositorie = customerContactsRepositorie;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessContacts()
        {
            logger.LogInformation($"Inicio el proceso de [{nameFileXml}]: {DateTimeOffset.Now}");
            var contacts = this.GetContacts();
            if (contacts == null)
            {
                this.logger.LogInformation($"No existe información de los {nameFileXml}");
                return;
            }

            this.managementFile.CreateFileCsv<CustomerContactsEntitie>(nameFileXml, contacts);
            var contactsXml = new CustomerContacts { Contactos = contacts.ToList() };
            this.managementFile.CreateFileXml<CustomerContacts>(nameFileXml, contactsXml);
            logger.LogInformation($"Archivo [{nameFileXml}] con {contacts.Count()} registros generado con éxito.");

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation($"La validación del XSD se realizo con éxito");

            logger.LogInformation($"Finalizo el proceso de [{nameFileXml}]: {DateTimeOffset.Now} \n");
        }

        private IEnumerable<CustomerContactsEntitie> GetContacts()
        {
            var contacts = this.customerContactsRepositorie.GetContacts();
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