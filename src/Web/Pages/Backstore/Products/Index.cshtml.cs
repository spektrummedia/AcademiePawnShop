using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Entities;

namespace Academie.PawnShop.Web.Pages.Backstore.Products
{
    
    public class IndexModel : PageModel
    {
        private readonly Academie.PawnShop.Domain.PawnShopDbContext _context;

        public IndexModel(Academie.PawnShop.Domain.PawnShopDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
