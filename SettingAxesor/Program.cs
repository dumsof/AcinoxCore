namespace SettingAxesor
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SettingAxesor.AxesorBusiness.Business;
    using SettingAxesor.AxesorBusiness.IBusiness;
    using SettingAxesor.AxesorRepositorie.IRepositorie;
    using SettingAxesor.AxesorRepositorie.Repositorie;
    using System;
    using System.Windows.Forms;
    using SettingAxesor.AxesorCrossCutting.Utilities;
    using Serilog;
    using Microsoft.Extensions.Logging;
    using Serilog.Events;

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Utility.CofigurationJson();          
            ConfiguracionSeriLog();

            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<frmSettingFile>();
                    services.AddScoped<IConfigurationBusiness, ConfigurationBusiness>();
                    services.AddSingleton<IConfigurationRepositorie, ConfigurationRepositorie>();
                    services.AddLogging(x =>
                    {
                        
                        //To Do: sirilog
                    });
                });
            var host = builder.Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var serv = serviceScope.ServiceProvider;
                try
                {
                    var form = serv.GetRequiredService<frmSettingFile>();
                    Application.Run(form);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show(ex.Message, "Error Aplication");
                }
            }
        }

        private static void ConfiguracionSeriLog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                 .WriteTo.File($"{Utility.PathAplication}\\LogSettingFilesAxesor.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            //services.AddLogging(c)
            //services.a
        }
    }
}