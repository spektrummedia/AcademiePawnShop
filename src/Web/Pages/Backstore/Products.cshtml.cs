using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Spk.Common.Helpers.Guard;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Academie.PawnShop.Web.Pages.Backstore
{
    [Authorize(Roles = "Administrator, Super Administrator")]
    public class ProductsModel : PageModel
    {
        private readonly PawnShopDbContext _db;

        public IEnumerable<Product> Products { get; set; }

        public ProductsModel(PawnShopDbContext db)
        {
            _db = db.GuardIsNotNull(nameof(db));
        }

        public void OnGet()
        {
            Products = _db.Products;
        }
    }
}