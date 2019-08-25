using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Spk.Common.Helpers.Guard;
using Academie.PawnShop.Domain;
using System.Text;

namespace Academie.PawnShop.Application
{
    public class DatabaseMigrator
    {
        private readonly ILogger<DatabaseMigrator> _logger;
        private readonly PawnShopDbContext _db;

        public DatabaseMigrator(ILogger<DatabaseMigrator> logger, PawnShopDbContext db)
        {
            _logger = logger.GuardIsNotNull(nameof(logger));
            _db = db.GuardIsNotNull(nameof(db));
        }

        public string Execute()
        {
            _logger.LogInformation("---DATABASE MIGRATION---\n");
            var output = new StringBuilder("---DATABASE MIGRATION---\n");

            foreach (var migration in _db.Database.GetPendingMigrations())
            {
                _logger.LogInformation(migration);
                output.AppendLine(migration);
            }

            _db.Database.Migrate();

            _logger.LogInformation("Done!");
            return output.AppendLine("Done!").ToString();
        }
    }
}