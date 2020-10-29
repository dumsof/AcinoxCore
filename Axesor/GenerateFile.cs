namespace Acinox
{
    using File.Business.IBusiness;
    using File.Entities;
    using File.Utility;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System.Threading;
    using System.Threading.Tasks;

    public class GenerateFile : BackgroundService
    {
        private readonly ILogger<GenerateFile> _logger;
        private readonly IOptions<ConfiguracionHoraEjecucionProceso> configHoraProceso;
        private readonly ISocietieBusiness societieBusiness;
        private readonly IClassificationBusiness classificationBusiness;
        private readonly ICustomerBusiness customerBusiness;
        private readonly IAddressBusiness addressBusiness;
        private readonly IPaymentMethodBusiness paymentMethodBusiness;
        private readonly ICustomerContactsBusiness customerContactsBusiness;
        private readonly IPartidasCompensatedBusiness partidasCompensatedBusiness;
        private readonly IPartidasOpenBusiness partidasOpenBusiness;
        private readonly IPaymentConditionBusiness paymentCondition;
        private readonly IManagementFile managementFile;
        private readonly IManagementFtp managementFtp;

        public GenerateFile(ILogger<GenerateFile> logger, IOptions<ConfiguracionHoraEjecucionProceso> configHoraProceso,
            ISocietieBusiness societieBusiness, IClassificationBusiness classificationBusiness, ICustomerBusiness customerBusiness,
            IAddressBusiness addressBusiness, IPaymentMethodBusiness paymentMethodBusiness, ICustomerContactsBusiness customerContactsBusiness,
            IPartidasCompensatedBusiness partidasCompensatedBusiness, IPartidasOpenBusiness partidasOpenBusiness, IPaymentConditionBusiness paymentCondition,
            IManagementFile managementFile, IManagementFtp managementFtp)
        {
            _logger = logger;
            this.configHoraProceso = configHoraProceso;
            this.societieBusiness = societieBusiness;
            this.classificationBusiness = classificationBusiness;
            this.customerBusiness = customerBusiness;
            this.addressBusiness = addressBusiness;
            this.paymentMethodBusiness = paymentMethodBusiness;
            this.customerContactsBusiness = customerContactsBusiness;
            this.partidasCompensatedBusiness = partidasCompensatedBusiness;
            this.partidasOpenBusiness = partidasOpenBusiness;
            this.paymentCondition = paymentCondition;
            this.managementFile = managementFile;
            this.managementFtp = managementFtp;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            //DUM: se inicia las variables
            _logger.LogInformation("Servicio Iniciado..\n");
            this.managementFile.CreatedPathFile();
            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (Utility.IsHourProced || this.configHoraProceso.Value.ProcesarCadaMinutoSinValidacionHora)
                {
                    var societies = societieBusiness.GetEmpresas();
                    foreach (var societie in societies)
                    {
                        string nameFolderSocietie = societie.Cod;
                        this.societieBusiness.ProcessSocietie(nameFolderSocietie);
                        this.classificationBusiness.ProcessClassification(societie, nameFolderSocietie);
                        this.paymentMethodBusiness.ProcessPaymentMethod(societie, nameFolderSocietie);
                        this.customerBusiness.ProcessCustomer(societie, nameFolderSocietie);
                        this.addressBusiness.ProcessAddress(societie, nameFolderSocietie);
                        this.customerContactsBusiness.ProcessContacts(societie, nameFolderSocietie);
                        this.paymentCondition.ProcessPaymentCondition(societie, nameFolderSocietie);
                        this.partidasOpenBusiness.ProcessPartidasOpen(societie, nameFolderSocietie);
                        //this.partidasCompensatedBusiness.ProcessPartidasCompensated();
                        this.managementFtp.UnloadAllFileFolderFtp(nameFolderSocietie);
                        //this.managementFile.MoveAllFileFolder();
                    }


                    _logger.LogInformation("[PROCESO CREAR ARCHIVO XML FINALIZO CON ÉXITO]\n");
                }

                await Task.Delay(60000 * this.configHoraProceso.Value.ProcesarCadaMinuto, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("El proceso esta detenido o parado.");
            await base.StopAsync(cancellationToken);
        }
    }
}