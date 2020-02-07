using System.IO;
using FluentEmail.Core.Defaults;
using FluentEmail.Core.Interfaces;
using FluentEmail.Razor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Academie.PawnShop.Application.Mailing;
using Academie.PawnShop.Application.Settings;
using Microsoft.Extensions.Hosting;

namespace Academie.PawnShop.Web.App_Startup
{
    internal static class MailingServices
    {
        internal static void Configure(
            IServiceCollection services,
            IWebHostEnvironment hostingEnvironment,
            IConfiguration mailingConfig)
        {
            services.Configure<MailingSettings>(mailingConfig);

            if (hostingEnvironment.IsDevelopment())
            {
                var emailsPath = Path.Combine(hostingEnvironment.WebRootPath, @".dev/inbox");
                Directory.CreateDirectory(emailsPath);
                services.AddSingleton<ISender>(new SaveToDiskSender(emailsPath));
            }
            else
            {
                services.Configure<AwsSesMailingSettings>(mailingConfig.GetSection("AwsSes"));
                services.AddSingleton<ISender, AwsSesSender>();
            }

            services.AddSingleton<ITemplateRenderer, RazorRenderer>();
            services.AddSingleton<IEmailFactory, EmailFactory>();
        }
    }
}