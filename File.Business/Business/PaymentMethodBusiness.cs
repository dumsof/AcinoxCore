namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.formapago;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PaymentMethodBusiness : IPaymentMethodBusiness
    {
        private readonly ILogger<PaymentMethodBusiness> logger;
        private readonly IPaymentMethodPqaRepositorie paymentMethodRepositorie;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private const string nameFileXml = "viaspago";

        public PaymentMethodBusiness(ILogger<PaymentMethodBusiness> logger, IPaymentMethodPqaRepositorie paymentMethodRepositorie,
            IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.paymentMethodRepositorie = paymentMethodRepositorie;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessPaymentMethod()
        {
            logger.LogInformation($"Inicio el proceso de [{nameFileXml}]: {DateTimeOffset.Now}");
            var paymentMethod = this.GetPaymentMethods();
            if (paymentMethod == null)
            {
                this.logger.LogInformation($"No existe información de los {nameFileXml}");
                return;
            }

            this.managementFile.CreateFileCsv<PaymentMethodEntitie>(nameFileXml, paymentMethod);
            var paymentMethodXml = new PaymentMethod { Via = paymentMethod.ToList() };
            this.managementFile.CreateFileXml<PaymentMethod>(nameFileXml, paymentMethodXml);
            logger.LogInformation($"Archivo [{nameFileXml}] con {paymentMethod.Count()} registros generado con éxito.");

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation($"La validación del XSD se realizo con éxito");

            logger.LogInformation($"Finalizo el proceso de [{nameFileXml}]: {DateTimeOffset.Now} \n");
        }

        private IEnumerable<PaymentMethodEntitie> GetPaymentMethods()
        {
            var paymentMethod = this.paymentMethodRepositorie.GetPaymentMethods();

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