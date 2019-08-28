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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Paid> Paid { get; set; }
        public DbSet<Billing> Billing { get; set; }
        public DbSet<BillingProduct> BillingProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Employee>()
               .OwnsOne(x => x.Address);
        }
    }
}
