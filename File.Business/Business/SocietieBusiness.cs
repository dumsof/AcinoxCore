namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.sociedad;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SocietieBusiness : ISocietieBusiness
    {
        private readonly ISocietieRepositorie societieRepositorie;
        private readonly ISocietiePqaRepositorie societiePqaRepositorie;
        private readonly IManagementFile managementFile;
        private readonly IManagementFtp managementFtp;
        private readonly IValidationXsd validationXsd;
        private readonly ILogger<SocietieBusiness> logger;

        public SocietieBusiness(ILogger<SocietieBusiness> logger, ISocietieRepositorie societieRepositorie, ISocietiePqaRepositorie societiePqaRepositorie,
            IManagementFile managementFile, IManagementFtp managementFtp, IValidationXsd validationXsd)
        {
            this.logger = logger;
            this.societieRepositorie = societieRepositorie;
            this.societiePqaRepositorie = societiePqaRepositorie;
            this.managementFile = managementFile;
            this.managementFtp = managementFtp;
            this.validationXsd = validationXsd;
        }

        public void ProcessSocietie()
        {
            logger.LogInformation($"Inicio el proceso de [Sociedades]: {DateTimeOffset.Now}");

            var societies = this.GetSocieties();
            if (societies == null)
            {
                this.logger.LogInformation("No existe información de las sociedades");
                return;
            }

            this.managementFile.CreateFileCsv<SocietieEntitie>("sociedades", societies);
            var societiesXml = new Societie { Sociedades = societies.ToList() };
            this.managementFile.CreateFileXml<Societie>("sociedades", societiesXml);
            logger.LogInformation($"Archivo [sociendades] con {societies.Count()} registros generado con éxito.");

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml("sociedades.xsd", "sociedades.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation($"La validación del XSD se realizo con éxito");

            logger.LogInformation($"Finalizo el proceso de [Sociedades]: {DateTimeOffset.Now}");
        }

        public void ProcessSocietiePQA()
        {
            logger.LogInformation($"Inicio el proceso de [Sociedades]: {DateTimeOffset.Now}");
            var societies = this.GetSocietiesPqa();
            if (societies == null)
            {
                this.logger.LogInformation("No existe información de las sociedades");
                return;
            }

            this.managementFile.CreateFileCsv<SocietieEntitie>("sociedades", societies);
            var societiesXml = new Societie { Sociedades = societies.ToList() };
            this.managementFile.CreateFileXml<Societie>("sociedades", societiesXml);
            logger.LogInformation($"Archivo [sociendades] con {societies.Count()} registros generado con éxito.");

            var resultValidatioWithXsd = this.validationXsd.ValidationShemaXml("sociedades.xsd", "sociedades.xml");

            if (resultValidatioWithXsd.Length > 0)
            {
                logger.LogWarning(resultValidatioWithXsd);
                return;
            }
            logger.LogInformation($"La validación del XSD se realizo con éxito");

            logger.LogInformation($"Finalizo el proceso de [Sociedades]: {DateTimeOffset.Now}");
        }

        private IEnumerable<SocietieEntitie> GetSocieties()
        {
            var empresa = this.societieRepositorie.GetEmpresas();

            var societie = empresa.Select(c => new SocietieEntitie
            {
                Cod = c.Codigo,
                Razons = c.Descripcion,
                Nif = c.Nit,
                CodMoneda = "01"
            }).ToList();

            return societie;
        }

        private IEnumerable<SocietieEntitie> GetSocietiesPqa()
        {
            var empresa = this.societiePqaRepositorie.GetEmpresas();

            return empresa.Select(c => new SocietieEntitie
            {
                Cod = c.Cod,
                Razons = c.Razons,
                Nif = c.Nif,
                CodMoneda = c.CodMoneda
            }).ToList();
        }
    }
}