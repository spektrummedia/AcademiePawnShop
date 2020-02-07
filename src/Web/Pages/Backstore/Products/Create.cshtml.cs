using Academie.PawnShop.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Academie.PawnShop.Domain;

namespace Academie.PawnShop.Web.Pages.Backstore.Products
{
    [Authorize(Roles = "Super Administrator")]
    public class CreateModel : PageModel
    {
        private readonly PawnShopDbContext _context;

        [BindProperty]
        public Product Product { get; set; }

        public CreateModel(PawnShopDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

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