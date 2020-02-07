using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Academie.PawnShop.Domain.Entities;

namespace Academie.PawnShop.Domain
{
    public class PawnShopDbContext : IdentityDbContext<User, Role, string>
    {
        public PawnShopDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // This QueryFilter is applied on every query unless specifically ignore 
            builder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<User>()
               .OwnsOne(x => x.Address);
        }
    }
}
