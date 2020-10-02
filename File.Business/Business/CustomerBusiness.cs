﻿namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.cliente;
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
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private const string nameFileXml = "clientes";

        public CustomerBusiness(ILogger<CustomerBusiness> logger, ICustomerPqaRepositorie customerRepositorie,
            IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.customerRepositorie = customerRepositorie;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessCustomer()
        {
            logger.LogInformation($"Inicio el proceso de [{nameFileXml}]: {DateTimeOffset.Now}");
            var customers = this.GetCustomers();
            if (customers == null)
            {
                this.logger.LogInformation($"No existe información de los {nameFileXml}");
                return;
            }

            this.managementFile.CreateFileCsv<CustomerEntitie>(nameFileXml, customers);
            var customerXml = new Customer { Clientes = customers.ToList() };
            this.managementFile.CreateFileXml<Customer>(nameFileXml, customerXml);
            logger.LogInformation($"Archivo [{nameFileXml}] con {customers.Count()} registros generado con éxito.");

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation($"La validación del XSD se realizo con éxito");

            logger.LogInformation($"Finalizo el proceso de [{nameFileXml}]: {DateTimeOffset.Now}");
        }

        private IEnumerable<CustomerEntitie> GetCustomers()
        {
            var customers = this.customerRepositorie.GetCustomers();

            var dato = customers.Select(c => new CustomerEntitie
            {
                Cod = c.Cod,
                Nif = c.Nif,
                Razons = c.Razons,
                Codcondp = c.Codcondp,
                limitrg = c.Limitrg,
                Prov = c.Prov,
                Dims = JsonConvert.DeserializeObject<List<Dim>>(c.Dims?.Replace("[,", "[")),
                Lrcomp = c.Lrcomp
            }).ToList();

            return dato;
        }
    }
}