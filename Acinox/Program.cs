using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using File.Business.Business;
using File.Business.IBusiness;
using File.Repositorie.IRepositorie;
using File.Repositorie.Repositorie;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;

namespace Acinox
{
    public class Program
    {
        //DUM: pagina de como se puede publicar el servicio de windows
        //Url:https://geeks.ms/jorge/2020/03/02/creando-un-servicio-windows-con-net-core-3-1/
        public static void Main(string[] args)
        {
            NlogConfig();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ISocietieRepositorie, SocietieRepositorie>();
                    services.AddSingleton<ISocietieBusiness, SocietieBusiness>();
                    services.AddHostedService<Worker>();
                    
                });

        public static void NlogConfig()
        {
            //se utiliza nlog para crear un archivo de log, Install-Package NLog -Version 4.6.7.
            //linea que permite optener la configuracion para nlog, por ejemplo ruta archivo nombre archivo.
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        }
    }
}
