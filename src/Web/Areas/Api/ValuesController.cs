using Microsoft.AspNetCore.Mvc;

namespace Academie.PawnShop.Web.Areas.Api
{
    [Area(AreaNames.Api)]
    public class ValuesController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Json(new[] {"value1", "value2"});
        }
    }
}