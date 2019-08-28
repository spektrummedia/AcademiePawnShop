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

namespace Academie.PawnShop.Web.Pages.Backstore.Products
{
    [Authorize(Roles = "Administrator, Super Administrator")]
    public class IndexModel : PageModel
    {
        private readonly PawnShopDbContext _db;
        private readonly IInventoryService _inventoryService;

        public IndexModel(PawnShopDbContext db, IInventoryService inventoryService)
        {
            _db = db;
            _inventoryService = inventoryService;
        }

        public IList<Product> Products { get;set; }

        public async Task OnGetAsync()
        {
            Products = await _db.Products.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return NotFound();

            product.SoftDelete();

            await _db.SaveChangesAsync();
            return RedirectToPage("/Backstore/Products/Index");
        }

        public async Task<IActionResult> OnPostReorderAsync(Guid id)
        {
            await _inventoryService.ReplenishInventory(id);

            return RedirectToPage("/Backstore/Products/Index");
        }
    }
}
