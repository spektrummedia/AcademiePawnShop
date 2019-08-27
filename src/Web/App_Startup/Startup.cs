using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Academie.PawnShop.Application;
using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Entities;
using Academie.PawnShop.Persistence;

namespace Academie.PawnShop.Web.App_Startup
{
    public class Startup
    {
        public Startup(
            IConfiguration configuration, 
            IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            MailingServices.Configure(services, HostingEnvironment, Configuration.GetSection("Mailing"));
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

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizeFolder("/Backstore");
                    options.Conventions.AuthorizePage("/Account/Logout");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (!HostingEnvironment.IsProduction())
                app.Map("/.dev", dev => DevPipeline.Configure(dev, HostingEnvironment));

            app.Map("/api", api => ApiPipeline.Configure(api, HostingEnvironment));

            AppPipeline.Configure(app, HostingEnvironment);
        }
    }
}