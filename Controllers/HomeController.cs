using Catopia.Data;
using Catopia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Catopia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ArticleContext _context;

        public HomeController(ILogger<HomeController> logger, ArticleContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Resources()
        {
            return View();
        }

        public IActionResult News()
        {
            List<Article> articles = _context.Articles.ToList();
            articles.Reverse(); // reverses their order, so the most recently submitted article is first

            return View(articles);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article a)
        {
            if (ModelState.IsValid)
            {
                _context.Articles.Add(a);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"'{a.Title}' has been posted!";
                return RedirectToAction("News");
            }

            return View(a);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}