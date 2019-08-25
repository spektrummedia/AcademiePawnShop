using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Academie.PawnShop.Application;

namespace Academie.PawnShop.Web.App_Startup
{
    internal static class AppPipeline
    {
        public static void Configure(IApplicationBuilder app, IHostingEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller}/{action=Index}/{id?}");
            });

            var serviceScopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
            using (IServiceScope scope = serviceScopeFactory.CreateScope())
            {
                IServiceProvider serviceProvider = scope.ServiceProvider;

                // Migrate database
                var migrator = serviceProvider.GetRequiredService<DatabaseMigrator>();
                migrator.Execute();
            }
        }
    }
}