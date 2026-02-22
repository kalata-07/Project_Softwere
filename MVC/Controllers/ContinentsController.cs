using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;
using DataLayer;

namespace MVC.Controllers
{
    public class ContinentsController : Controller
    {
        private readonly DBLibraryContext _context;

        public ContinentsController(DBLibraryContext context)
        {
            _context = context;
        }

        // GET: Continents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Continents.ToListAsync());
        }

        // GET: Continents/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var continent = await _context.Continents
                .FirstOrDefaultAsync(m => m.ContinentCode == id);
            if (continent == null)
            {
                return NotFound();
            }

            return View(continent);
        }

        // GET: Continents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Continents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContinentCode,ContinentName")] Continent continent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(continent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(continent);
        }

        // GET: Continents/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var continent = await _context.Continents.FindAsync(id);
            if (continent == null)
            {
                return NotFound();
            }
            return View(continent);
        }

        // POST: Continents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ContinentCode,ContinentName")] Continent continent)
        {
            if (id != continent.ContinentCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(continent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContinentExists(continent.ContinentCode))
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
            return View(continent);
        }

        // GET: Continents/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var continent = await _context.Continents
                .FirstOrDefaultAsync(m => m.ContinentCode == id);
            if (continent == null)
            {
                return NotFound();
            }

            return View(continent);
        }

        // POST: Continents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var continent = await _context.Continents.FindAsync(id);
            if (continent != null)
            {
                _context.Continents.Remove(continent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContinentExists(string id)
        {
            return _context.Continents.Any(e => e.ContinentCode == id);
        }
    }
}
