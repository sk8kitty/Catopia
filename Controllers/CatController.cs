﻿using Catopia.Data;
using Catopia.Models;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
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


        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Cat? catToEdit = await _context.Cats.FindAsync(id);

            if (catToEdit == null)
            {
                return NotFound();
            }

            return View(catToEdit);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Cat c)
        {
            if (ModelState.IsValid)
            {
                _context.Cats.Update(c);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{c.Name} was updated successfully!";
                return RedirectToAction("Index");
            }

            return View(c);
        }


        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            Cat? catToDelete = await _context.Cats.FindAsync(id);

            if (catToDelete == null)
            {
                return NotFound();
            }

            return View(catToDelete);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Cat? catToDelete = await _context.Cats.FindAsync(id);

            if (catToDelete != null)
            {
                _context.Cats.Remove(catToDelete);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{catToDelete.Name}'s listing was deleted successfully!";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "This listing was already deleted.";
            return RedirectToAction("Index");
        }


        
        public async Task<IActionResult> AdoptionApp(int id)
        {
            Cat? catToAdopt = await _context.Cats.FindAsync(id);
            if (catToAdopt == null)
            {
                return NotFound();
            }

            return View(catToAdopt);
        }

        [HttpPost]
        public IActionResult AdoptionApp()
        {
            TempData["Message"] = $"Your application was submitted successfully!";
            return RedirectToAction("Index");
        }
    }
}
