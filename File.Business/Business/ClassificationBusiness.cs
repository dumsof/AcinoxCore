namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.clasificacion;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ClassificationBusiness : IClassificationBusiness
    {
        private readonly ILogger<ClassificationBusiness> logger;
        private readonly IClassificationPqaRepositorie classificationRepositorie;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private const string nombreFileClassification = "clasifcriterios";

        public ClassificationBusiness(ILogger<ClassificationBusiness> logger, IClassificationPqaRepositorie classificationRepositorie,
            IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.classificationRepositorie = classificationRepositorie;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessClassification()
        {
            logger.LogInformation($"Inicio el proceso de [{nombreFileClassification}]: {DateTimeOffset.Now}");
            var classification = this.GetClassification();
            if (classification == null)
            {
                this.logger.LogInformation($"No existe información de los {nombreFileClassification}");
                return;
            }

            this.managementFile.CreateFileCsv<ClassificationEntitie>(nombreFileClassification, classification);
            var societiesXml = new Classification { CritElem = classification.ToList() };
            this.managementFile.CreateFileXml<Classification>(nombreFileClassification, societiesXml);
            logger.LogInformation($"Archivo [{nombreFileClassification}] con {classification.Count()} registros generado con éxito.");

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nombreFileClassification}.xsd", $"{nombreFileClassification}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation($"La validación del XSD se realizo con éxito");

            logger.LogInformation($"Finalizo el proceso de [{nombreFileClassification}]: {DateTimeOffset.Now}");
        }

        private IEnumerable<ClassificationEntitie> GetClassification()
        {
            var classification = this.classificationRepositorie.GetClassification();

            return classification.Select(c => new ClassificationEntitie
            {
                Id = c.Id,
                Cod = c.Cod,
                Desc = c.Desc
            }).ToList();
        }
    }
}