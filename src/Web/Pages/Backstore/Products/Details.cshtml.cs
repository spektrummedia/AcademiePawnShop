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
    public class DetailsModel : PageModel
    {
        private readonly Academie.PawnShop.Domain.PawnShopDbContext _context;

        public DetailsModel(Academie.PawnShop.Domain.PawnShopDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
