namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.CondicionesPago;
    using File.Message;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public void ProcessPaymentCondition()
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, DateTimeOffset.Now }));
            var paymentCondition = this.GetPaymentCondition();
            if (paymentCondition == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<PaymentConditionEntitie>(nameFileXml, paymentCondition);
            var paymentConditionXml = new PaymentCondition { CondicionesPago = paymentCondition.ToList() };
            this.managementFile.CreateFileXml<PaymentCondition>(nameFileXml, paymentConditionXml);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, paymentCondition?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml, DateTimeOffset.Now }));
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