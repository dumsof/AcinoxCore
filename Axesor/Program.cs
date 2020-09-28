namespace Acinox
{
    using File.Business.Business;
    using File.Business.IBusiness;
    using File.Entities;
    using File.Repositorie.IRepositorie;
    using File.Repositorie.Repositorie;
    using File.Utility;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using Serilog.Events;
    using System;

    public class Program
    {
        private static IConfigurationRoot Configuration { get; set; }

        //DUM: pagina de como se puede publicar el servicio de windows
        //Url:https://geeks.ms/jorge/2020/03/02/creando-un-servicio-windows-con-net-core-3-1/
        public static void Main(string[] args)
        {
            ConfiguracionSeriLog();
            CofigurationJson();
            try
            {
                Log.Information("Inicio la subida del servicio.");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Hay un problema al iniciar el servicio, por favor verifique.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ISocietieRepositorie, SocietieRepositorie>();
                    services.AddSingleton<ISocietiePqaRepositorie, SocietiePqaRepositorie>();
                    services.AddSingleton<ISocietieBusiness, SocietieBusiness>();

                    services.AddSingleton<IManagementFile, ManagementFile>();
                    services.AddSingleton<IManagementFtp, ManagementFtp>();
                    services.AddSingleton<IValidationXsd, ValidationXsd>();

                    services.Configure<ConfiguracionHoraEjecucionProceso>(Configuration.GetSection("ConfiguracionHoraEjecucionProceso"));
                    services.Configure<ConfiguracionFtp>(Configuration.GetSection("ConfiguracionFtp"));
                    services.AddHostedService<GenerateFile>();
                   
                    
                })

                .UseSerilog(); //Dum: cuando se habilita no se presentan los mensaje en la cosola se guardan en el archivo de Log

        private static void ConfiguracionSeriLog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File($"{Utility.PathFolderLogs}\\{string.Format("{0:yyyy-MM-dd}", DateTime.Now)}-LogAplication.txt")
                .CreateLogger();
        }

        private static void CofigurationJson()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Utility.PathAplication)
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }
    }
}