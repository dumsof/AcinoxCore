namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.sociedad;
    using File.Message;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SocietieBusiness : ISocietieBusiness
    {
        private readonly ISocietieRepositorie societieRepositorie;
        private readonly ISocietiePqaRepositorie societiePqaRepositorie;
        private readonly IMessageManagement messageManagement;
        private readonly IManagementFile managementFile;
        private readonly IManagementFtp managementFtp;
        private readonly IValidationXsd validationXsd;
        private readonly ILogger<SocietieBusiness> logger;
        private const string nameFileXml = "sociedades";

        public SocietieBusiness(ILogger<SocietieBusiness> logger, ISocietieRepositorie societieRepositorie, ISocietiePqaRepositorie societiePqaRepositorie,
         IMessageManagement messageManagement, IManagementFile managementFile, IManagementFtp managementFtp, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.societieRepositorie = societieRepositorie;
            this.societiePqaRepositorie = societiePqaRepositorie;
            this.messageManagement = messageManagement;
            this.managementFile = managementFile;
            this.managementFtp = managementFtp;
            this.validationXsd = validationXsd;
        }

        public void ProcessSocietie()
        {
            logger.LogInformation($"Inicio el proceso de [{nameFileXml}]: {DateTimeOffset.Now}");

            var societies = this.GetSocieties();
            if (societies == null)
            {
                this.logger.LogInformation($"No existe información de las {nameFileXml}");
                return;
            }

            this.managementFile.CreateFileCsv<SocietieEntitie>(nameFileXml, societies);
            var societiesXml = new Societie { Sociedades = societies.ToList() };
            this.managementFile.CreateFileXml<Societie>(nameFileXml, societiesXml);
            logger.LogInformation($"Archivo [{nameFileXml}] con {societies.Count()} registros generado con éxito.");

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation($"La validación del XSD se realizo con éxito");

            logger.LogInformation($"Finalizo el proceso de [{nameFileXml}]: {DateTimeOffset.Now} \n");
        }

        public void ProcessSocietiePQA()
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, DateTimeOffset.Now }));
            var societies = this.GetSocietiesPqa();
            if (societies == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<SocietieEntitie>(nameFileXml, societies);
            var societiesXml = new Societie { Sociedades = societies.ToList() };
            this.managementFile.CreateFileXml<Societie>(nameFileXml, societiesXml);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, societies?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml, DateTimeOffset.Now }));
        }

        private IEnumerable<SocietieEntitie> GetSocieties()
        {
            var empresa = this.societieRepositorie.GetEmpresas();

            var societie = empresa.Select(c => new SocietieEntitie
            {
                Cod = c.Codigo,
                Razons = c.Descripcion,
                Nif = c.Nit,
                CodMoneda = "01"
            }).ToList();

            return societie;
        }

        private IEnumerable<SocietieEntitie> GetSocietiesPqa()
        {
            var empresa = this.societiePqaRepositorie.GetEmpresas();

            return empresa.Select(c => new SocietieEntitie
            {
                Cod = c.Cod,
                Razons = c.Razons,
                Nif = c.Nif,
                CodMoneda = c.CodMoneda
            }).ToList();
        }
    }
}