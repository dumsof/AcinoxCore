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

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var societies = this.societieBusiness.GetSocieties();

                foreach (var societie in societies)
                {
                    _logger.LogInformation($" Codigo={societie.Cod} Razón Social={societie.Razons}", DateTimeOffset.Now);
                }
                await Task.Delay(60000 * 5, stoppingToken);
            }
        }
    }
}
