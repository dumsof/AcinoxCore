namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.cliente;
    using File.Entities.sociedad;
    using File.Message;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly ILogger<CustomerBusiness> logger;
        private readonly ICustomerPqaRepositorie customerRepositorie;
        private readonly IMessageManagement messageManagement;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private const string nameFileXml = "clientes";

        public CustomerBusiness(ILogger<CustomerBusiness> logger, ICustomerPqaRepositorie customerRepositorie,
            IMessageManagement messageManagement, IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.customerRepositorie = customerRepositorie;
            this.messageManagement = messageManagement;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessCustomer(SocietieEntitie societie, string nameFolderSocietie)
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, nameFolderSocietie}));
            var customers = this.GetCustomers(societie.Cod);
            this.GenerateFileXml(customers, nameFolderSocietie);
        }

        private void GenerateFileXml(IEnumerable<CustomerEntitie> customers, string nameFolderSocietie)
        {
            if (customers == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<CustomerEntitie>(nameFileXml, customers);
            var customerXml = new Customer { Clientes = customers.ToList() };
            this.managementFile.CreateFileXml<Customer>(nameFileXml, customerXml, nameFolderSocietie);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.CountFileGenerad, new object[] { nameFileXml, customers?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFolderSocietie}\\{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml}));
        }

        private IEnumerable<CustomerEntitie> GetCustomers(string idEmpresa)
        {
            var customers = this.customerRepositorie.GetCustomers(idEmpresa);

            var dato = customers.Select(c => new CustomerEntitie
            {
                Cod = c.Cod,
                Nif = c.Nif,
                Razons = c.Razons,
                Codcondp = c.Codcondp,
                limitrg = c.Limitrg,
                Prov = c.Prov,
                dims = JsonConvert.DeserializeObject<List<Dim>>(c.Dims?.Replace("[,", "[")),
                Lrcomp = c.Lrcomp,
                viasp = new List<string> { c.Viasp },
                Clasifcontable = c.ClasifContable,
                Lsegcredito = c.LsegCredito,
                Fchcadsegcred = c.Fchcadsegcred,
                Tipoentidad = c.Tipoentidad,
                Sector = c.Sector,
                Fchaltaerp = c.Fchaltaerp,
                Fchinitact = c.Fchinitact,
                Ind1 = c.Ind1,
                Ind2 = c.Ind2,
                Ind3 = c.Ind3,
                Ind4 = c.Ind4,
                Ind5 = c.Ind5,
                Ind6 = c.Ind6,
                Ind7 = c.Ind7,
                Ind8 = c.Ind8,
                Ind9 = c.Ind9,
            }).ToList();

            return dato;
        }
    }
}