using System;
using System.Diagnostics;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Academie.PawnShop.Web.App_Startup;

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

        public static IWebHost BuildWebHost(string[] args) => CreateWebHostBuilder(args).Build();


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .ConfigureAppConfiguration(config => config.AddJsonFile("appsettings.local.json", true))
                .ConfigureLogging((ctx, logging) =>
                {
                    Logging.Configure(
                        logging,
                        ctx.HostingEnvironment,
                        ctx.Configuration.GetSection("Logging"));
                })
                .UseKestrel()
                .UseUrls(
                    "https://Academie.PawnShop.local:5000"
                )
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
