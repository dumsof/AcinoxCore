namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.direccion;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AddressBusiness : IAddressBusiness
    {
        private readonly ILogger<AddressBusiness> logger;
        private readonly IAddressPqaRepositorie addressRepositorie;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private const string nameFileXml = "direcciones";

        public AddressBusiness(ILogger<AddressBusiness> logger, IAddressPqaRepositorie addressRepositorie,
            IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.addressRepositorie = addressRepositorie;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessAddress()
        {
            logger.LogInformation($"Inicio el proceso de [{nameFileXml}]: {DateTimeOffset.Now}");
            var addres = this.GetAddress();
            if (addres == null)
            {
                this.logger.LogInformation($"No existe información de los {nameFileXml}");
                return;
            }

            this.managementFile.CreateFileCsv<AddressEntitie>(nameFileXml, addres);
            var addressXml = new Address { Direccion = addres.ToList() };
            this.managementFile.CreateFileXml<Address>(nameFileXml, addressXml);
            logger.LogInformation($"Archivo [{nameFileXml}] con {addres.Count()} registros generado con éxito.");

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation($"La validación del XSD se realizo con éxito");

            logger.LogInformation($"Finalizo el proceso de [{nameFileXml}]: {DateTimeOffset.Now} \n");
        }

        private IEnumerable<AddressEntitie> GetAddress()
        {
            var address = this.addressRepositorie.GetAddress();
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