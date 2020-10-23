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
        private readonly ISocietiePqaRepositorie societiePqaRepositorie;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private const string nameFileXml = "direcciones";

        public AddressBusiness(ILogger<AddressBusiness> logger, IAddressPqaRepositorie addressRepositorie,
            ISocietiePqaRepositorie societiePqaRepositorie, IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.addressRepositorie = addressRepositorie;
            this.societiePqaRepositorie = societiePqaRepositorie;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessAddress()
        {
            logger.LogInformation($"Inicio el proceso de [{nameFileXml}]: {DateTimeOffset.Now}");

            var societies = this.societiePqaRepositorie.GetEmpresas();
            foreach (var societie in societies)
            {
                var addres = this.GetAddress(societie.Cod);
                this.GenerateFileXml(addres, societie.Nif);
            }
        }

        private void GenerateFileXml(IEnumerable<AddressEntitie> addres, string nitSocietie)
        {
            logger.LogInformation($"Inicio el proceso de [{nameFileXml}]: {DateTimeOffset.Now}");
            if (addres == null)
            {
                this.logger.LogInformation($"No existe información de los {nameFileXml}");
                return;
            }

            this.managementFile.CreateFileCsv<AddressEntitie>(nameFileXml, addres);
            var addressXml = new Address { Direccion = addres.ToList() };
            this.managementFile.CreateFileXml<Address>(nameFileXml, addressXml, nitSocietie);
            logger.LogInformation($"Archivo [{nameFileXml}] con {addres.Count()} registros generado con éxito.");

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nitSocietie}\\{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation($"La validación del XSD se realizo con éxito");

            logger.LogInformation($"Finalizo el proceso de [{nameFileXml}]: {DateTimeOffset.Now} \n");
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