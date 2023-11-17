﻿using Catopia.Data;
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

        public async Task<IActionResult> Details(int id)
        {
            Cat? catDetails = await _context.Cats.FindAsync(id);
            if (catDetails == null)
            {
                return NotFound();
            }

            return View(catDetails);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cat c)
        {
            if (ModelState.IsValid)
            {
                _context.Cats.Add(c);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{c.Name} is now up for adoption!";

                return RedirectToAction("Index");
            }

            return View(c);
        }
    }
}
