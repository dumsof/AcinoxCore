namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.PartidasCompensada;
    using File.Message;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PartidasCompensatedBusiness : IPartidasCompensatedBusiness
    {
        private readonly IPartidasCompensatedPqaRepositorie partidaCompensatedPqaRepositorie;
        private readonly IMessageManagement messageManagement;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private readonly ILogger<PartidasCompensatedBusiness> logger;
        private const string nameFileXml = "partcomps";

        public PartidasCompensatedBusiness(ILogger<PartidasCompensatedBusiness> logger, IPartidasCompensatedPqaRepositorie partidaCompensatedPqaRepositorie,
         IMessageManagement messageManagement, IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.partidaCompensatedPqaRepositorie = partidaCompensatedPqaRepositorie;
            this.messageManagement = messageManagement;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessPartidasCompensated()
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, DateTimeOffset.Now }));
            var partidasCompensated = this.GetPartidasOpen();
            if (partidasCompensated == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<PartidasCompensatedEntitie>(nameFileXml, partidasCompensated);
            var partidasCompensatedXml = new PartidasCompensated { PartidasCompensadas = partidasCompensated.ToList() };
            this.managementFile.CreateFileXml<PartidasCompensated>(nameFileXml, partidasCompensatedXml);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, partidasCompensated?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml, DateTimeOffset.Now }));
        }

        private IEnumerable<PartidasCompensatedEntitie> GetPartidasOpen()
        {
            var partidaOpen = this.partidaCompensatedPqaRepositorie.GetPartidasCompensated();

            return partidaOpen.Select(c => new PartidasCompensatedEntitie
            {
                CodCli = c.CodCli,
                Ndoc = c.Ndoc,
                Nvcto = c.Nvcto,
                Fchemi = c.Fchemi,
                Fchvcto = c.Fchvcto,
                Importe = c.Importe,
                Estado = c.Estado,
                Dotada = c.Dotada,
                CodVp = c.CodVp,
                CodConDp = c.CodConDp,
                CodMonDoc = c.CodMonDoc,
                ImpMonDoc = c.ImpMonDoc,
                Ind1 = c.Ind1,
                Ind2 = c.Ind2,
                Ind3 = c.Ind3,
                Ind4 = c.Ind4,
                Ind5 = c.Ind5,
                Ind6 = c.Ind6,
                Ind7 = c.Ind7,
                Ind8 = c.Ind8,
                Ind9 = c.Ind9,
                Tdoc = c.Tdoc,
                Campoid = c.Campoid,
                CodeJercicio = c.CodeJercicio,
                NumDocOrigen = c.NumDocOrigen
            }).ToList();
        }
    }
}