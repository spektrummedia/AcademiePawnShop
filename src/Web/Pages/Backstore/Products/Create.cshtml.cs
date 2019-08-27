using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Academie.PawnShop.Domain;
using Academie.PawnShop.Domain.Entities;

namespace Academie.PawnShop.Web.Pages.Backstore.Products
{
    public class CreateModel : PageModel
    {
        private readonly Academie.PawnShop.Domain.PawnShopDbContext _context;

        public CreateModel(Academie.PawnShop.Domain.PawnShopDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}