using Microsoft.AspNetCore.Mvc;

namespace Catopia.Controllers
{
    public class CatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
