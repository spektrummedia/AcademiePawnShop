using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spk.Common.Helpers.Guard;
using Academie.PawnShop.Application;
using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Authorization;
using Academie.PawnShop.Domain.Entities;
using Academie.PawnShop.Domain.Fakers;

namespace Academie.PawnShop.Web.Areas.Dev
{
    [Area(AreaNames.Dev)]
    public class DbController : Controller
    {
        private readonly PawnShopDbContext _db;
        private readonly DatabaseMigrator _migrator;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        private StringBuilder _output;

        public DbController(PawnShopDbContext db, UserManager<User> userManager, RoleManager<Role> roleManager, DatabaseMigrator migrator)
        {
            _roleManager = roleManager;
            _db = db.GuardIsNotNull(nameof(db));
            _userManager = userManager.GuardIsNotNull(nameof(userManager));
            _roleManager = roleManager.GuardIsNotNull(nameof(roleManager));
            _migrator = migrator.GuardIsNotNull(nameof(migrator));
        }

        public IActionResult Migrate()
        {
            _output = new StringBuilder();
            _output.AppendLine(_migrator.Execute());

            return Ok(_output.ToString());
        }

        public async Task<IActionResult> Seed(bool reset = false)
        {
            _output = new StringBuilder("---DATABASE SEED---\n");

            if (reset)
                await DeleteAllDatabaseObjects();

            _migrator.Execute();

            _output.AppendLine("Ensured database is created and applied all pending migrations");

            foreach (var role in Roles.GetAllRoles())
                await CreateRole(role);

            foreach (var superAdmin in SuperAdmins.GetAllSuperAdmins())
                await CreateUser(superAdmin, Constants.Authorization.Roles.SUPER_ADMIN);

            foreach (var fakeUser in UserFaker.DefaultInstance.Generate(5))
                await CreateUser(fakeUser, Constants.Authorization.Roles.USER);

            await _db.SaveChangesAsync();

            _output.AppendLine("Done!");

            return Ok(_output.ToString());
        }

        private async Task CreateRole(Role role)
        {
            await _roleManager.CreateAsync(role);
            _output.AppendLine($"Created role '{role}'");
        }

        private async Task CreateUser(User superAdmin, string roleName, string password = "123qwe")
        {
            await _userManager.CreateAsync(superAdmin);
            await _userManager.AddPasswordAsync(superAdmin, password);
            await _userManager.AddToRoleAsync(superAdmin, roleName);
            _output.AppendLine($"Created user '{superAdmin.UserName}' with password '{password}' and role '{roleName}'");
        }

        private async Task DeleteAllDatabaseObjects()
        {
            await _db.Database.ExecuteSqlCommandAsync(@"
                declare @str varchar(max)
                declare cur cursor for

                SELECT 'ALTER TABLE ' + '[' + s.[NAME] + '].[' + t.name + '] DROP CONSTRAINT ['+ c.name + ']'
                FROM sys.objects c, sys.objects t, sys.schemas s
                WHERE c.type IN ('C', 'F', 'PK', 'UQ', 'D')
                 AND c.parent_object_id=t.object_id and t.type='U' AND t.SCHEMA_ID = s.schema_id
                ORDER BY c.type

                open cur
                FETCH NEXT FROM cur INTO @str
                WHILE (@@fetch_status = 0) BEGIN
                 PRINT @str
                 EXEC (@str)
                 FETCH NEXT FROM cur INTO @str
                END

                close cur
                deallocate cur

                EXEC sp_MSforeachtable @command1 = ""DROP TABLE ? ""
            ");
        }
    }
}