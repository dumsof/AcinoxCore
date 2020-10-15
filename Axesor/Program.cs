namespace Acinox
{
    using File.Business.Business;
    using File.Business.IBusiness;
    using File.Entities;
    using File.Message;
    using File.Repositorie.EntitieRepositorie;
    using File.Repositorie.IRepositorie;
    using File.Repositorie.Repositorie;
    using File.Utility;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using Serilog.Events;
    using System;
    using System.Collections.Generic;

    public static class Program
    {
        //DUM: pagina de como se puede publicar el servicio de windows
        //Url:https://geeks.ms/jorge/2020/03/02/creando-un-servicio-windows-con-net-core-3-1/
        public static void Main(string[] args)
        {
            try
            {
                Utility.CofigurationJson();
                Utility.CofigurationSQL();
                Utility.CofigurationMessage();
                ConfiguracionSeriLog();
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
                    services.AddSingleton<IClassificationPqaRepositorie, ClassificationPqaRepositorie>();
                    services.AddSingleton<ICustomerPqaRepositorie, CustomerPqaRepositorie>();
                    services.AddSingleton<IPaymentMethodPqaRepositorie, PaymentMethodPqaRepositorie>();
                    services.AddSingleton<IAddressPqaRepositorie, AddressPqaRepositorie>();
                    services.AddSingleton<ICustomerContactsPqaRepositorie, CustomerContactsPqaRepositorie>();
                    services.AddSingleton<IPartidasOpenPqaRepositorie, PartidasOpenPqaRepositorie>();

                    services.AddSingleton<ISocietieBusiness, SocietieBusiness>();
                    services.AddSingleton<IClassificationBusiness, ClassificationBusiness>();
                    services.AddSingleton<ICustomerBusiness, CustomerBusiness>();
                    services.AddSingleton<IPaymentMethodBusiness, PaymentMethodBusiness>();
                    services.AddSingleton<IAddressBusiness, AddressBusiness>();
                    services.AddSingleton<ICustomerContactsBusiness, CustomerContactsBusiness>();
                    services.AddSingleton<IPartidasOpenBusiness, PartidasOpenBusiness>();

                    services.AddSingleton<IManagementFile, ManagementFile>();
                    services.AddSingleton<IManagementFtp, ManagementFtp>();
                    services.AddSingleton<IValidationXsd, ValidationXsd>();
                    services.AddSingleton<IMessageManagement, MessageManagement>();

                    services.Configure<ConfiguracionHoraEjecucionProceso>(Utility.Configuration.GetSection("ConfiguracionHoraEjecucionProceso"));
                    services.Configure<ConfiguracionFtp>(Utility.Configuration.GetSection("ConfiguracionFtp"));
                    services.Configure<ConfiguracionQuerySqlPqa>(Utility.ConfigurationSql.GetSection("ConfiguracionQuerySqlPqa"));

                    services.Configure<List<Message>>(Utility.ConfigurationMessage.GetSection("Message"));

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
    }
}