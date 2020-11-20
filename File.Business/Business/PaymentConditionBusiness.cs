namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.CondicionesPago;
    using File.Entities.sociedad;
    using File.Message;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using File.Utility;

    public class PaymentConditionBusiness : IPaymentConditionBusiness
    {
        private readonly IPaymentConditionsPqaRepositorie paymentConditionPqaRepositorie;
        private readonly IMessageManagement messageManagement;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private readonly ILogger<PaymentConditionBusiness> logger;
        private const string nameFileXml = "cndpago";

        public PaymentConditionBusiness(ILogger<PaymentConditionBusiness> logger, IPaymentConditionsPqaRepositorie paymentConditionPqaRepositorie,
         IMessageManagement messageManagement, IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.paymentConditionPqaRepositorie = paymentConditionPqaRepositorie;
            this.messageManagement = messageManagement;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessPaymentCondition(SocietieEntitie societie, string nameFolderSocietie)
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, nameFolderSocietie }));
            var paymentCondition = this.GetPaymentCondition();
            this.GenerateFileXml(paymentCondition, nameFolderSocietie);
        }

        private void GenerateFileXml(IEnumerable<PaymentConditionEntitie> paymentCondition, string nameFolderSocietie)
        {
            if (paymentCondition == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<PaymentConditionEntitie>(nameFileXml, paymentCondition);
            var paymentConditionXml = new PaymentCondition { CondicionesPago = paymentCondition.ToList() };
            this.managementFile.CreateFileXml<PaymentCondition>(nameFileXml, paymentConditionXml, nameFolderSocietie);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.CountFileGenerad, new object[] { nameFileXml, paymentCondition?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFolderSocietie}\\{Utility.DateTimeProces}\\{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml }));
        }

        private IEnumerable<PaymentConditionEntitie> GetPaymentCondition()
        {
            var paymentCondition = this.paymentConditionPqaRepositorie.GetPaymentConditions();

            return paymentCondition.Select(c => new PaymentConditionEntitie
            {
                Cod = c.Cod,
                Desc = c.Desc,
                plazos = JsonConvert.DeserializeObject<List<PlazosEntitie>>(c.Plazos?.Replace("[,", "[")),
            }).ToList();
        }
    }
}