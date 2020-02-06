using Academie.PawnShop.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Academie.PawnShop.Web.Pages.Backstore.Products
{
 //   [Authorize(Roles = "Super Administrator")]
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