using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Academie.PawnShop.Web.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly PawnShopDbContext _db;

        public IEnumerable<Product> Products { get; set; }


        public ProductsModel(PawnShopDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            Products = await _db.Products.ToListAsync();
        }
    }
}