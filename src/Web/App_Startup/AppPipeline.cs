using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Academie.PawnShop.Application;
using Microsoft.Extensions.Hosting;

namespace Academie.PawnShop.Web.App_Startup
{
    internal static class AppPipeline
    {
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapRazorPages()
               );

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