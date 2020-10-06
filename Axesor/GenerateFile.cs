﻿namespace Acinox
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
        private readonly IManagementFile managementFile;
        private readonly IManagementFtp managementFtp;

        public GenerateFile(ILogger<GenerateFile> logger, IOptions<ConfiguracionHoraEjecucionProceso> configHoraProceso,
            ISocietieBusiness societieBusiness, IClassificationBusiness classificationBusiness, ICustomerBusiness customerBusiness,
            IAddressBusiness addressBusiness, IPaymentMethodBusiness paymentMethodBusiness, ICustomerContactsBusiness customerContactsBusiness,
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
                    this.societieBusiness.ProcessSocietiePQA();
                    this.classificationBusiness.ProcessClassification();
                    this.paymentMethodBusiness.ProcessPaymentMethod();
                    this.customerBusiness.ProcessCustomer();
                    this.addressBusiness.ProcessAddress();
                    this.customerContactsBusiness.ProcessContacts();
                    this.managementFtp.UnloadAllFileFolderFtp();
                    this.managementFile.MoveAllFileFolder();
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