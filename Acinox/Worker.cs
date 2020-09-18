namespace Acinox
{
    using File.Business.IBusiness;
    using File.Entities;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IOptions<ConfiguracionHoraEjecucionProceso> configHoraProceso;
        private readonly ISocietieBusiness societieBusiness;
        private readonly IManagementFile managementFile;

        public Worker(ILogger<Worker> logger, IOptions<ConfiguracionHoraEjecucionProceso> configHoraProceso, ISocietieBusiness societieBusiness, IManagementFile managementFile)
        {
            _logger = logger;
            this.configHoraProceso = configHoraProceso;
            this.societieBusiness = societieBusiness;
            this.managementFile = managementFile;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            //DUM: se inicia las variables
            this.managementFile.CreatedPathFile();
            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (this.EsHoraProceso())
                {
                    _logger.LogInformation($"Inicio el proceso de [Sociedades]: {DateTimeOffset.Now}");
                    this.societieBusiness.ProcessSocietie();
                    _logger.LogInformation($"Finalizo el proceso de [Sociedades]: {DateTimeOffset.Now}");
                }

                await Task.Delay(60000 * 1, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Proces stops");
            await base.StopAsync(cancellationToken);
        }

        private bool EsHoraProceso() => this.configHoraProceso.Value.Hora24 >= DateTime.Now.Hour && this.configHoraProceso.Value.Minuto60 >= DateTime.Now.Minute;
    }
}