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

    }
}
