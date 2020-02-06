using System;
using System.Diagnostics;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Academie.PawnShop.Web.App_Startup;
using Microsoft.Extensions.Hosting;

namespace Academie.PawnShop.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine($"dotnet.exe process id: {Process.GetCurrentProcess().Id}");
            Console.WriteLine("****************************************");
            BuildWebHost(args).Run();
        }

        public static IHost BuildWebHost(string[] args) => CreateWebHostBuilder(args).Build();

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder
                      .ConfigureAppConfiguration(config => config.AddJsonFile("appsettings.local.json", true))
                      .ConfigureLogging((ctx, logging) =>
                       {
                           Logging.Configure(
                               logging,
                               ctx.HostingEnvironment,
                               ctx.Configuration.GetSection("Logging"));
                       })
                  .UseKestrel()
                  .UseIISIntegration()                  
                  .UseUrls("https://Academie.PawnShop.local:5000")
                  .UseStartup<Startup>();
              });
    }
}
