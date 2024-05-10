using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quadlab.Models;
using Quadlab.Models.appdbContext;

namespace Quadlab.Controllers
{
    public class modelClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public modelClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: modelClasses
        public async Task<IActionResult> Index()
        {
              return _context.UserTable1 != null ? 
                          View(await _context.UserTable1.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserTable1'  is null.");
        }

        // GET: modelClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserTable1 == null)
            {
                return NotFound();
            }

            var modelClass = await _context.UserTable1
                .FirstOrDefaultAsync(m => m.userId == id);
            if (modelClass == null)
            {
                return NotFound();
            }

            return View(modelClass);
        }

        // GET: modelClasses/Create
        public IActionResult Create()
        {
            ViewBag.CountryList = _context.CountryTable1.ToList();
            ViewBag.CityList= _context.CitiesTable1.ToList();
            return View();
        }

        // POST: modelClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("userId,firstName,lastName,email,gender,phone,city,country")] modelClass modelClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelClass);
        }

        // GET: modelClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserTable1 == null)
            {
                return NotFound();
            }
            ViewBag.CountryList = _context.CountryTable1.ToList();
            ViewBag.CityList = _context.CitiesTable1.ToList();
            var modelClass = await _context.UserTable1.FindAsync(id);
            if (modelClass == null)
            {
                return NotFound();
            }
            return View(modelClass);
        }

        // POST: modelClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("userId,firstName,lastName,email,gender,phone,city,country")] modelClass modelClass)
        {
            if (id != modelClass.userId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!modelClassExists(modelClass.userId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(modelClass);
        }

        // GET: modelClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserTable1 == null)
            {
                return NotFound();
            }

            var modelClass = await _context.UserTable1
                .FirstOrDefaultAsync(m => m.userId == id);
            if (modelClass == null)
            {
                return NotFound();
            }

            return View(modelClass);
        }

        // POST: modelClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserTable1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserTable1'  is null.");
            }
            var modelClass = await _context.UserTable1.FindAsync(id);
            if (modelClass != null)
            {
                _context.UserTable1.Remove(modelClass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool modelClassExists(int id)
        {
          return (_context.UserTable1?.Any(e => e.userId == id)).GetValueOrDefault();
        }

        public IActionResult GetCitiesByCountry(int countryId)
        {
            var cities = _context.CitiesTable1
                                .Where(c => c.CountryId == countryId)
                                .ToList();

            return Json(cities);
        }
    }
}
