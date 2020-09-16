using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
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
        private readonly IManagementFile managementFile;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            this.societieBusiness = new SocietieBusiness();
            this.managementFile = new ManagementFile();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                _logger.LogInformation("LA TAREA INICIO EL PROCESO A LAS: {time}", DateTimeOffset.Now);

                var societies = this.societieBusiness.GetSocieties();

                if (societies != null)
                {
                    XmlWriterSettings setting = new XmlWriterSettings() { Indent = true };
                    setting.ConformanceLevel = ConformanceLevel.Auto;
                    using (XmlWriter writer = XmlWriter.Create("E:\\sociedades.xml", setting))
                    {
                        writer.WriteStartElement("sociedades");
                        foreach (var s in societies)
                        {
                            writer.WriteStartElement("sociedad");
                            writer.WriteElementString("cod", s.Cod);
                            writer.WriteElementString("razons", s.Razons);
                            writer.WriteElementString("nit", s.Nif);
                            writer.WriteElementString("codmoneda", s.CodMoneda);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        writer.Flush();
                    }
                }

                foreach (var societie in societies)
                {
                    _logger.LogInformation($"Código={societie.Cod} Razón Social={societie.Razons} NIt={societie.Nif} Moneda={societie.CodMoneda}", DateTimeOffset.Now);
                }
                await Task.Delay(60000 * 5, stoppingToken);
            }
        }
    }
}
