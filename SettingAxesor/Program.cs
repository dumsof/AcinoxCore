namespace SettingAxesor
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using Serilog.Events;
    using SettingAxesor.AxesorBusiness.Business;
    using SettingAxesor.AxesorBusiness.IBusiness;
    using SettingAxesor.AxesorCrossCutting.Utilities;
    using SettingAxesor.AxesorRepositorie.IRepositorie;
    using SettingAxesor.AxesorRepositorie.Repositorie;
    using System;
    using System.Windows.Forms;

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
                }).UseSerilog();
            var host = builder.Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var serv = serviceScope.ServiceProvider;
                try
                {
                    Log.Information("Inicio correctamente la Aplicación Setting\n");
                    var form = serv.GetRequiredService<frmSettingFile>();
                    Application.Run(form);
                    Log.Information("Finalizo correctamente la Aplicación Setting\n");
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "Hay un problema al iniciar la aplicación setting axesor, por favor verifique.\n");
                    MessageBox.Show("Error Aplication");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
        }

        private static void ConfiguracionSeriLog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                 .WriteTo.File($"{Utility.PathAplication}\\Logs\\LogSettingFilesAxesor.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}