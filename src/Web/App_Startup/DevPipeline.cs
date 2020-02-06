using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Academie.PawnShop.Web.Areas;
using Microsoft.Extensions.Hosting;

namespace Academie.PawnShop.Web.App_Startup
{
    internal static class DevPipeline
    {
        public static void Configure(IApplicationBuilder dev, IWebHostEnvironment env)
        {
            dev.UseStatusCodePages();

            if (env.IsDevelopment())
            {
                dev.UseDeveloperExceptionPage();
                dev.UseDatabaseErrorPage(); 
            }

            var devFileProvider = new PhysicalFileProvider(Path.Combine(env.WebRootPath, ".dev"));

            dev.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = devFileProvider,
                DefaultContentType = "text/html",
                ServeUnknownFileTypes = true
            });

            dev.UseDirectoryBrowser(
                new DirectoryBrowserOptions
                {
                    RequestPath = "",
                    FileProvider = devFileProvider
                });

            dev.UseRouting();
            dev.UseEndpoints(endpoints =>
                               endpoints.MapAreaControllerRoute("dev_route", AreaNames.Dev, "{controller}/{action}")
                           );
        }
    }
}