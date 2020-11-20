namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.PartidasCompensada;
    using File.Entities.sociedad;
    using File.Message;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;
    using File.Utility;

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

        public void ProcessPartidasCompensated(SocietieEntitie societie, string nameFolderSocietie)
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, nameFolderSocietie }));
            var partidasCompensated = this.GetPartidasOpen(societie.Cod);
            this.GenerateFileXml(partidasCompensated, nameFolderSocietie);
        }

        private void GenerateFileXml(IEnumerable<PartidasCompensatedEntitie> partidasCompensated, string nameFolderSocietie)
        {
            if (partidasCompensated == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<PartidasCompensatedEntitie>(nameFileXml, partidasCompensated);
            var partidasCompensatedXml = new PartidasCompensated { PartidasCompensadas = partidasCompensated.ToList() };
            this.managementFile.CreateFileXml<PartidasCompensated>(nameFileXml, partidasCompensatedXml, nameFolderSocietie);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.CountFileGenerad, new object[] { nameFileXml, partidasCompensated?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFolderSocietie}\\{Utility.DateTimeProces}\\{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml }));
        }

        private IEnumerable<PartidasCompensatedEntitie> GetPartidasOpen(string idEmpresa)
        {
            var partidaOpen = this.partidaCompensatedPqaRepositorie.GetPartidasCompensated(idEmpresa);

            return partidaOpen.Select(c => new PartidasCompensatedEntitie
            {
                CodCli = c.CodCli,
                Ndoc = c.Ndoc,
                Nvcto = c.Nvcto,
                Fchemi = c.Fchemi,
                Fchvcto = c.Fchvcto,
                Fchcomp = c.Fchcomp,
                Importe = c.Importe,
                Marca = c.Marca,
                ImpMonDoc = c.ImpMonDoc,
                CodMonDoc = c.CodMonDoc,
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
                NumDocCobro = c.NumDocCobro,
                NumDocOrigen = c.NumDocOrigen,
                CodEjercicioComp = c.CodEjercicioComp
            }).ToList();
        }
    }
}