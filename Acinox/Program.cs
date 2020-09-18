using File.Business.Business;
using File.Business.IBusiness;
using File.Repositorie.IRepositorie;
using File.Repositorie.Repositorie;
using File.Utility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;

namespace Acinox
{
    public class Program
    {
        //DUM: pagina de como se puede publicar el servicio de windows
        //Url:https://geeks.ms/jorge/2020/03/02/creando-un-servicio-windows-con-net-core-3-1/
        public static void Main(string[] args)
        {
            ConfiguracionSeriLog();

            try
            {
                Log.Information("Starting up the service");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "There was a problem starting the service");
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
                    services.AddSingleton<ISocietieBusiness, SocietieBusiness>();
                    services.AddHostedService<Worker>();
                })
                .UseSerilog(); //Dum: cuando se habilita no se presentan los mensaje en la cosola se guardan en el archivo de Log

        private static void ConfiguracionSeriLog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File($"{Utility.PathAplication}\\{string.Format("{0:yyyy-MM-dd}", DateTime.Now)}-LogAplication.txt")
                .CreateLogger();
        }
    }
}