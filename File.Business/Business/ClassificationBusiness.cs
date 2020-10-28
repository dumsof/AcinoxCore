namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.clasificacion;
    using File.Entities.sociedad;
    using File.Message;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;

    public class ClassificationBusiness : IClassificationBusiness
    {
        private readonly ILogger<ClassificationBusiness> logger;
        private readonly IClassificationPqaRepositorie classificationRepositorie;
        private readonly IMessageManagement messageManagement;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private const string nameFileXml = "clasifcriterios";

        public ClassificationBusiness(ILogger<ClassificationBusiness> logger, IClassificationPqaRepositorie classificationRepositorie,
            IMessageManagement messageManagement, IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.classificationRepositorie = classificationRepositorie;
            this.messageManagement = messageManagement;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessClassification(SocietieEntitie societie, string nameFolderSocietie)
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, nameFolderSocietie }));
            var classification = this.GetClassification(societie.Cod);
            this.GenerateFileXml(classification, nameFolderSocietie);
        }

        private void GenerateFileXml(IEnumerable<ClassificationEntitie> classification, string nameFolderSocietie)
        {
            if (classification == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<ClassificationEntitie>(nameFileXml, classification);
            var societiesXml = new Classification { CritElem = classification.ToList() };
            this.managementFile.CreateFileXml<Classification>(nameFileXml, societiesXml, nameFolderSocietie);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.CountFileGenerad, new object[] { nameFileXml, classification?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFolderSocietie}\\{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml }));
        }

        private IEnumerable<ClassificationEntitie> GetClassification(string codEmpresa)
        {
            var classification = this.classificationRepositorie.GetClassification(codEmpresa);

            return classification.Select(c => new ClassificationEntitie
            {
                Id = c.Id,
                Cod = c.Cod,
                Desc = c.Desc
            }).ToList();
        }
    }
}