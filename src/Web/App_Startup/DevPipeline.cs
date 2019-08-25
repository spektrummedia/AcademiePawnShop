using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Academie.PawnShop.Web.Areas;

namespace Academie.PawnShop.Web.App_Startup
{
    internal static class DevPipeline
    {
        public static void Configure(IApplicationBuilder dev, IHostingEnvironment hostingEnvironment)
        {
            dev.UseStatusCodePages();

            if (hostingEnvironment.IsDevelopment())
            {
                dev.UseDeveloperExceptionPage();
                dev.UseDatabaseErrorPage();
            }

            var devFileProvider = new PhysicalFileProvider(Path.Combine(hostingEnvironment.WebRootPath, ".dev"));

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

            dev.UseMvc(mvc => { mvc.MapAreaRoute("dev_route", AreaNames.Dev, "{controller}/{action}"); });
        }
    }
}