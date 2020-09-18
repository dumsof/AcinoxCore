namespace Acinox
{
    using File.Business.Business;
    using File.Business.IBusiness;
    using File.Utility;
    using LoggerService;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISocietieBusiness societieBusiness;
        private readonly IManagementFile managementFile;
        private readonly ILoggerManager loggerNlog;

        public Worker(ILogger<Worker> logger, ISocietieBusiness societieBusiness)
        {
            _logger = logger;
            _logger.LogInformation("Constructor servicio");
            this.societieBusiness = societieBusiness; 
            this.managementFile = new ManagementFile();
            this.loggerNlog = new LoggerManager();
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            //DUM: se inicia las variables
            _logger.LogInformation("Inicia servicio");
            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    this.loggerNlog.LogInfo($"INICIO EL PROCESO A LAS: {DateTimeOffset.Now}");
                    GenerarFileSociedades();
                    this.loggerNlog.LogInfo($"FINALIZO EL PROCESO CON EXITO: {DateTimeOffset.Now}");
                }
                catch (Exception ex)
                {
                    this.loggerNlog.LogError($"ERROR MENSAJE : {ex.Message}");
                    this.loggerNlog.LogError($"ERROR DETALLE  : {ex.StackTrace} {ex.InnerException}");
                }

                await Task.Delay(60000 * 5, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Proces stops");
            await base.StopAsync(cancellationToken);
        }

        private void GenerarFileSociedades()
        {
            _logger.LogInformation("LA TAREA INICIO EL PROCESO A LAS: {time}", DateTimeOffset.Now);
           
            var societies = this.societieBusiness.GetSocieties();

            if (societies != null)
            {

                this.CrearRuta();
                XmlWriterSettings setting = new XmlWriterSettings() { Indent = true };
                setting.ConformanceLevel = ConformanceLevel.Auto;
                string path = $"{Utility.PathAplication}\\ArchivosGenerados";

                using (XmlWriter writer = XmlWriter.Create($"{path}\\sociedades.xml", setting))
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

                this.MoverArchivo("sociedades.xml");
            }
        }

        private void CrearRuta()
        {
            string rutaArchivoGenerado = Utility.PathAplication + "\\ArchivosGenerados";
            if (!Directory.Exists(rutaArchivoGenerado))
            {
                Directory.CreateDirectory(rutaArchivoGenerado);
            }
        }

        private void MoverArchivo(string nombreArchivo)
        {
            string rutaArchivoGenerado = Utility.PathAplication + "\\ArchivosGenerados";
            string rutaArchivoProcesado = Utility.PathAplication + "\\ArchivoProcesado";
            if (!Directory.Exists(rutaArchivoProcesado))
            {
                Directory.CreateDirectory(rutaArchivoProcesado);
            }
            if (File.Exists($"{rutaArchivoProcesado}\\{nombreArchivo}"))
            {
                File.Delete($"{rutaArchivoProcesado}\\{nombreArchivo}");

            }
            File.Move($"{rutaArchivoGenerado}\\{nombreArchivo}", $"{rutaArchivoProcesado}\\{nombreArchivo}");
        }
    }
}