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

            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<frmSettingFile>();
                    services.AddScoped<IConfigurationBusiness, ConfigurationBusiness>();
                    services.AddSingleton<IConfigurationRepositorie, ConfigurationRepositorie>();
                    //services.AddLogging(configure => configure.AddConsole());
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
                }
            }

            //DUM: injectar servicios
            //var services = new ServiceCollection();
            //ConfigureServices(services);

            //Application.Run(new frmSettingFile());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            //services.AddLogging(c)
            //services.a
        }
    }
}