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
        private readonly ISocietiePqaRepositorie societiePqaRepositorie;
        private readonly IMessageManagement messageManagement;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private readonly ILogger<SocietieBusiness> logger;
        private const string nameFileXml = "sociedades";

        public SocietieBusiness(ILogger<SocietieBusiness> logger, ISocietiePqaRepositorie societiePqaRepositorie,
         IMessageManagement messageManagement, IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.societiePqaRepositorie = societiePqaRepositorie;
            this.messageManagement = messageManagement;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessSocietie(string nameFolderSocietie)
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, nameFolderSocietie }));
            var societies = this.GetEmpresas();
            this.GenerateFileXml(societies, nameFolderSocietie);
        }

        private void GenerateFileXml(IEnumerable<SocietieEntitie> societies, string nameFolderSocietie)
        {
            if (societies == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<SocietieEntitie>(nameFileXml, societies);
            var societiesXml = new Societie { Sociedades = societies.ToList() };
            this.managementFile.CreateFileXml<Societie>(nameFileXml, societiesXml, nameFolderSocietie);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.CountFileGenerad, new object[] { nameFileXml, societies?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFolderSocietie}\\{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml}));
        }

        public IEnumerable<SocietieEntitie> GetEmpresas()
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