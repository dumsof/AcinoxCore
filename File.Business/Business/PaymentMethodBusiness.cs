namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.formapago;
    using File.Entities.sociedad;
    using File.Message;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;

    public class PaymentMethodBusiness : IPaymentMethodBusiness
    {
        private readonly ILogger<PaymentMethodBusiness> logger;
        private readonly IPaymentMethodPqaRepositorie paymentMethodRepositorie;
        private readonly IMessageManagement messageManagement;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private const string nameFileXml = "viaspago";

        public PaymentMethodBusiness(ILogger<PaymentMethodBusiness> logger, IPaymentMethodPqaRepositorie paymentMethodRepositorie,
            IMessageManagement messageManagement, IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.paymentMethodRepositorie = paymentMethodRepositorie;
            this.messageManagement = messageManagement;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessPaymentMethod(SocietieEntitie societie, string nameFolderSocietie)
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, nameFolderSocietie }));
            var paymentMethod = this.GetPaymentMethods(societie.Cod);
            this.GenerateFileXml(paymentMethod, nameFolderSocietie);
        }

        private void GenerateFileXml(IEnumerable<PaymentMethodEntitie> paymentMethod, string nameFolderSocietie)
        {
            if (paymentMethod == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<PaymentMethodEntitie>(nameFileXml, paymentMethod);
            var paymentMethodXml = new PaymentMethod { Via = paymentMethod.ToList() };
            this.managementFile.CreateFileXml<PaymentMethod>(nameFileXml, paymentMethodXml, nameFolderSocietie);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.CountFileGenerad, new object[] { nameFileXml, paymentMethod?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFolderSocietie}\\{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml }));
        }

        private IEnumerable<PaymentMethodEntitie> GetPaymentMethods(string idEmpresa)
        {
            var paymentMethod = this.paymentMethodRepositorie.GetPaymentMethods(idEmpresa);

            var dato = paymentMethod.Select(c => new PaymentMethodEntitie
            {
                Cod = c.Cod,
                Desc = c.Desc,
                GenCart = c.GenCart,
                Ind1 = c.Ind1,
                Ind2 = c.Ind2,
                NumDias = c.NumDias
            }).ToList();

            return dato;
        }
    }
}