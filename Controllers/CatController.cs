using Catopia.Data;
using Catopia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catopia.Controllers
{
    public class CatController : Controller
    {
        private CatContext _context;

        public CatController(CatContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Cat> cats = _context.Cats.ToList();
            return View(cats);
        }
    }
}
