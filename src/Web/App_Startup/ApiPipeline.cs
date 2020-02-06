using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Academie.PawnShop.Web.Areas;

namespace Academie.PawnShop.Web.App_Startup
{
    internal static class ApiPipeline
    {
        public static void Configure(IApplicationBuilder api, IWebHostEnvironment env)
        {            
            api.UseRouting();         
                  

            api.UseEndpoints(endpoints =>
                endpoints.MapAreaControllerRoute("api_route", AreaNames.Api, "{controller=Home}/{action=Index}")
            );
        }
    }
}