using Academie.PawnShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Academie.PawnShop.Domain;

namespace Academie.PawnShop.Web.Pages.Backstore.Products
{
    public class EditModel : PageModel
    {
        private readonly PawnShopDbContext _db;

        public EditModel(Academie.PawnShop.Domain.PawnShopDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _db.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(m => m.Id == id);


            product.Name = Product.Name;
            product.Quantity = Product.Quantity;
            product.Price = Product.Price;

            await _db.SaveChangesAsync();

            return RedirectToPage("/Backstore/Products/Index");
        }

        private bool ProductExists(Guid id)
        {
            return _db.Products.Any(e => e.Id == id);
        }
    }
}
