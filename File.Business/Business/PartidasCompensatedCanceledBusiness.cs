namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.PartidasCompensadaAnulada;
    using File.Entities.sociedad;
    using File.Message;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;

    public class PartidasCompensatedCanceledBusiness : IPartidasCompensatedCanceledBusiness
    {
        private readonly IPartidasCompensatedCanceledPqaRepositorie partidaCompensatedCanceledPqaRepositorie;
        private readonly IMessageManagement messageManagement;
        private readonly IManagementFile managementFile;
        private readonly IValidationXsd validationXsd;
        private readonly ILogger<PartidasCompensatedCanceledBusiness> logger;
        private const string nameFileXml = "partcompsinv";

        public PartidasCompensatedCanceledBusiness(ILogger<PartidasCompensatedCanceledBusiness> logger, IPartidasCompensatedCanceledPqaRepositorie partidaCompensatedCanceledPqaRepositorie,
         IMessageManagement messageManagement, IManagementFile managementFile, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.partidaCompensatedCanceledPqaRepositorie = partidaCompensatedCanceledPqaRepositorie;
            this.messageManagement = messageManagement;
            this.managementFile = managementFile;
            this.validationXsd = validationXsd;
        }

        public void ProcessPartidasCompensatedCanceled(SocietieEntitie societie, string nameFolderSocietie)
        {
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.InicioProcessGeneradFile, new object[] { nameFileXml, nameFolderSocietie }));
            var partidasCompensated = this.GetPartidasOpen(societie.Cod);
            this.GenerateFileXml(partidasCompensated, nameFolderSocietie);
        }

        private void GenerateFileXml(IEnumerable<PartidasCompensatedCanceledEntitie> partidasCompensatedCanceled, string nameFolderSocietie)
        {
            if (partidasCompensatedCanceled == null)
            {
                this.logger.LogInformation(this.messageManagement.GetMessage(MessageType.NoExitsInformation, new object[] { nameFileXml }));
                return;
            }

            this.managementFile.CreateFileCsv<PartidasCompensatedCanceledEntitie>(nameFileXml, partidasCompensatedCanceled);
            var partidasCompensatedCanceledXml = new PartidasCompensatedCanceled { PartidasCompensadasAnuladas = partidasCompensatedCanceled.ToList() };
            this.managementFile.CreateFileXml<PartidasCompensatedCanceled>(nameFileXml, partidasCompensatedCanceledXml, nameFolderSocietie);
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.CountFileGenerad, new object[] { nameFileXml, partidasCompensatedCanceled?.Count() }));

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml($"{nameFileXml}.xsd", $"{nameFolderSocietie}\\{nameFileXml}.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation(this.messageManagement.GetMessage(MessageType.ValidationXSDSuccess));

            logger.LogInformation(this.messageManagement.GetMessage(MessageType.FinishedProcess, new object[] { nameFileXml }));
        }

        private IEnumerable<PartidasCompensatedCanceledEntitie> GetPartidasOpen(string idEmpresa)
        {
            var partidaOpen = this.partidaCompensatedCanceledPqaRepositorie.GetPartidasCompensatedCanceled(idEmpresa);           

            return partidaOpen
                .Where(c => c.FchCreacion != string.Empty)
                .Select(c => new PartidasCompensatedCanceledEntitie
                {
                    NumCobro = c.NumCobro,
                    Fchinv = c.Fchinv,
                    FchCreacion = c.FchCreacion,
                }).ToList();
        }
    }
}