using Academie.PawnShop.Application.Services;
using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Spk.Common.Helpers.Guard;

namespace Academie.PawnShop.Web.Pages.Backstore.Products
{
    [Authorize(Roles = "Administrator, Super Administrator")]
    public class IndexModel : PageModel
    {
        private readonly PawnShopDbContext _db;
        private readonly IInventoryManager _inventoryManager;

        public IList<Product> Products { get;set; }

        public IndexModel(PawnShopDbContext db, IInventoryManager inventoryManager)
        {
            _db = db.GuardIsNotNull(nameof(db));
            _inventoryManager = inventoryManager.GuardIsNotNull(nameof(inventoryManager));
            //_inventoryManager = new InventoryManager(_db); // Without dependency injection your code would look like this everytime you want to use an instance of InventoryManager
        }

        public async Task OnGetAsync()
        {
            Products = await _db.Products.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id) // Multiple handle in the same page.
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return NotFound();

            product.SoftDelete();

            await _db.SaveChangesAsync();
            return RedirectToPage("/Backstore/Products/Index");
        }

        public async Task<IActionResult> OnPostReorderAsync(Guid id) // Multiple handle in the same page.
        {
            await _inventoryManager.ReplenishInventory(id);

            return RedirectToPage("/Backstore/Products/Index");
        }
    }
}
