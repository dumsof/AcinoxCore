namespace Acinox
{
    using File.Business.IBusiness;
    using File.Entities;
    using File.Utility;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Serilog;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class GenerateFile : BackgroundService
    {
        private readonly ILogger<GenerateFile> logger;
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
        private readonly IPartidasCompensatedCanceledBusiness partidasCompensatedCanceled;
        private readonly ISaleSummaryBusiness saleSummaryBusiness;
        private readonly IManagementFile managementFile;
        private readonly IManagementFtp managementFtp;

        public GenerateFile(ILogger<GenerateFile> logger, IOptions<ConfiguracionHoraEjecucionProceso> configHoraProceso,
            ISocietieBusiness societieBusiness, IClassificationBusiness classificationBusiness, ICustomerBusiness customerBusiness,
            IAddressBusiness addressBusiness, IPaymentMethodBusiness paymentMethodBusiness, ICustomerContactsBusiness customerContactsBusiness,
            IPartidasCompensatedBusiness partidasCompensatedBusiness, IPartidasOpenBusiness partidasOpenBusiness, IPaymentConditionBusiness paymentCondition,
            IPartidasCompensatedCanceledBusiness partidasCompensatedCanceled,
            ISaleSummaryBusiness saleSummaryBusiness, IManagementFile managementFile, IManagementFtp managementFtp)
        {
            this.logger = logger;
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
            this.partidasCompensatedCanceled = partidasCompensatedCanceled;
            this.saleSummaryBusiness = saleSummaryBusiness;
            this.managementFile = managementFile;
            this.managementFtp = managementFtp;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            //DUM: se inicia las variables
            this.logger.LogInformation("Servicio Iniciado..\n");
            this.managementFile.CreatedPathFile();
            Utility.DateTimeProces = string.Format("{0:yyyyMMdd.HHmm}", DateTime.Now);
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
                        this.partidasCompensatedBusiness.ProcessPartidasCompensated(societie, nameFolderSocietie);
                        this.partidasCompensatedCanceled.ProcessPartidasCompensatedCanceled(societie, nameFolderSocietie);
                        this.saleSummaryBusiness.ProcessSaleSummary(societie, nameFolderSocietie);
                        //this.managementFtp.UnloadAllFileFolderFtp(nameFolderSocietie);
                        //this.managementFile.MoveAllFileFolder(nameFolderSocietie);
                        //this.managementFile.DeleteFolderGenerated(nameFolderSocietie);
                    }
                    this.logger.LogInformation("[PROCESO CREAR ARCHIVO XML FINALIZO CON ÉXITO]\n");
                    Log.CloseAndFlush();
                }

                await Task.Delay(60000 * this.configHoraProceso.Value.ProcesarCadaMinuto, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("El proceso esta detenido o parado.");
            await base.StopAsync(cancellationToken);
        }
    }
}