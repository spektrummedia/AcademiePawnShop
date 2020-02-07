using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Academie.PawnShop.Application;
using Academie.PawnShop.Application.Services;
using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Entities;
using Academie.PawnShop.Persistence;
using Microsoft.Extensions.Hosting;

namespace Academie.PawnShop.Web.App_Startup
{
    public class Startup
    {
        public Startup(
            IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
       

          //  MailingServices.Configure(services, Configuration.GetSection("Mailing"));
            services.AddTransient<DatabaseMigrator>();

            services.AddDbContext<PawnShopDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(DesignTimeDbContextFactory).Assembly.FullName)));

            services.AddIdentity<User, Role>(options =>
                {
                    options.SignIn.RequireConfirmedEmail = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 1;
                })
                .AddEntityFrameworkStores<PawnShopDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddControllersWithViews();

            services.AddRazorPages()
                .AddNewtonsoftJson()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizeFolder("/Backstore");
                    options.Conventions.AuthorizePage("/Account/Logout");
                });

            // Register services
            services
                .AddScoped<IInventoryManager, InventoryManager>(); // Scoped, Transient, Singleton
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsProduction())
                app.Map("/.dev", dev => DevPipeline.Configure(dev, env));

            app.Map("/api", api => ApiPipeline.Configure(api, env));

            AppPipeline.Configure(app, env);
            
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}