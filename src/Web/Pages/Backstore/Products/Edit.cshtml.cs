using System;
using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Spk.Common.Helpers.Guard;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Academie.PawnShop.Web.Pages.Backstore.Products
{
    public class EditModel : PageModel
    {
        private readonly PawnShopDbContext _db;

        public Product Product { get; set; }

        public EditModel(PawnShopDbContext db)
        {
            _db = db.GuardIsNotNull(nameof(db));
        }
        public void OnGet(string slug)
        {
            Product = _db.Products.FirstOrDefault(x => x.Id == Guid.Parse(slug));
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == Product.Id);

            product.Name = Product.Name;
            product.Price = Product.Price;
            product.Quantity = Product.Quantity;

            await _db.SaveChangesAsync();

            return RedirectToPage("/backstore/products");
        }
    }
}