namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.ResumenVenta;
    using File.Entities.sociedad;
    using File.Message;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;

    public class SaleSummaryBusiness : ISaleSummaryBusiness
    {
        private readonly ILogger<SaleSummaryBusiness> logger;
        private readonly ISaleSummaryPqaRepositorie repositorie;
        private readonly IMessageManagement messageManagement;

        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private const string nameFileXml = "ventas";

        public SaleSummaryBusiness(ILogger<SaleSummaryBusiness> logger, ISaleSummaryPqaRepositorie repositorie,
            IMessageManagement messageManagement, IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.repositorie = repositorie;
            this.messageManagement = messageManagement;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessSaleSummary(SocietieEntitie societie, string nameFolderSocietie)
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, nameFolderSocietie }));
            var saleSumary = this.GetSaleSummary(societie.Cod);
            this.GenerateFileXml(saleSumary, nameFolderSocietie);
        }

        private void GenerateFileXml(IEnumerable<SaleSummaryEntitie> saleSumary, string nameFolderSocietie)
        {
            if (saleSumary == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<SaleSummaryEntitie>(nameFileXml, saleSumary);
            var saleSummaryXml = new SaleSummary { Ventas = saleSumary.ToList() };
            this.managementFile.CreateFileXml<SaleSummary>(nameFileXml, saleSummaryXml, nameFolderSocietie);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.CountFileGenerad, new object[] { nameFileXml, saleSumary?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFolderSocietie}\\{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml }));
        }

        private IEnumerable<SaleSummaryEntitie> GetSaleSummary(string codEmpresa)
        {
            var address = this.repositorie.GetSaleSummary(codEmpresa);
            var dato = address.Select(c => new SaleSummaryEntitie
            {
                CodCli = c.CodCli,
                Anio = c.Anio,
                Mes = c.Mes,
                Importe = c.Importe

            }).ToList();

            return dato;
        }
    }
}