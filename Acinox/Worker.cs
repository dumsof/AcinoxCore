using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using File.Business.Business;
using File.Business.IBusiness;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Acinox
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISocietieBusiness societieBusiness;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            this.societieBusiness = new SocietieBusiness();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                _logger.LogInformation("LA TAREA INICIO EL PROCESO A LAS: {time}", DateTimeOffset.Now);

                var societies = this.societieBusiness.GetSocieties();

                foreach (var societie in societies)
                {
                    _logger.LogInformation($"Código={societie.Cod} Razón Social={societie.Razons} NIt={societie.Nif} Moneda={societie.CodMoneda}", DateTimeOffset.Now);
                }
                await Task.Delay(60000 * 5, stoppingToken);
            }
        }
    }
}
