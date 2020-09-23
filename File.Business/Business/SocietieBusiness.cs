namespace File.Business.Business
{
    using File.Business.IBusiness;
    using File.Entities.sociedad;
    using File.Repositorie.IRepositorie;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;

    public class SocietieBusiness : ISocietieBusiness
    {
        private readonly ISocietieRepositorie societieRepositorie;
        private readonly IManagementFile managementFile;
        private readonly IManagementFtp managementFtp;
        private readonly ILogger<SocietieBusiness> logger;

        public SocietieBusiness(ILogger<SocietieBusiness> logger, ISocietieRepositorie societieRepositorie, IManagementFile managementFile, IManagementFtp managementFtp)
        {
            this.logger = logger;
            this.societieRepositorie = societieRepositorie;
            this.managementFile = managementFile;
            this.managementFtp = managementFtp;
        }

        public void ProcessSocietie()
        {
            var societies = this.GetSocieties();
            if (societies == null)
            {
                this.logger.LogInformation("No existe información de las sociedades");
                return;
            }

            this.managementFile.CreateFileCsv<SocietieEntitie>("sociedades", societies);

            var societiesXml = new Societie { Sociedades = societies.ToList() };
            this.managementFile.CreateFileXml<Societie>("sociedades", societiesXml);
            this.managementFtp.UnloadAllFileFolderFtp();
            this.managementFile.MoveAllFileFolder();
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
    }
}