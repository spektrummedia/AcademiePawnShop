using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Academie.PawnShop.Domain;

namespace Academie.PawnShop.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PawnShopDbContext>
    {
        public PawnShopDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<PawnShopDbContext>()
                .UseSqlServer(
                    @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Academie.PawnShop;Integrated Security=True;", 
                    optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(DesignTimeDbContextFactory).Assembly.FullName))
                .Options;

            return new PawnShopDbContext(options);
        }
    }
}