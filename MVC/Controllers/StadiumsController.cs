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
    public class StadiumsController : Controller
    {
        private readonly DBLibraryContext _context;

        public StadiumsController(DBLibraryContext context)
        {
            _context = context;
        }

        // GET: Stadiums
        public async Task<IActionResult> Index()
        {
            var dBLibraryContext = _context.Stadiums.Include(s => s.CountryCodeNavigation);
            return View(await dBLibraryContext.ToListAsync());
        }

        // GET: Stadiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stadium = await _context.Stadiums
                .Include(s => s.CountryCodeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stadium == null)
            {
                return NotFound();
            }

            return View(stadium);
        }

        // GET: Stadiums/Create
        public IActionResult Create()
        {
            ViewData["CountryCode"] = new SelectList(_context.Countries, "CountryCode", "CountryCode");
            return View();
        }

        // POST: Stadiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Capacity,CountryCode,TownName")] Stadium stadium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stadium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryCode"] = new SelectList(_context.Countries, "CountryCode", "CountryCode", stadium.CountryCode);
            return View(stadium);
        }

        // GET: Stadiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium == null)
            {
                return NotFound();
            }
            ViewData["CountryCode"] = new SelectList(_context.Countries, "CountryCode", "CountryCode", stadium.CountryCode);
            return View(stadium);
        }

        // POST: Stadiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Capacity,CountryCode,TownName")] Stadium stadium)
        {
            if (id != stadium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stadium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StadiumExists(stadium.Id))
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
            ViewData["CountryCode"] = new SelectList(_context.Countries, "CountryCode", "CountryCode", stadium.CountryCode);
            return View(stadium);
        }

        // GET: Stadiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stadium = await _context.Stadiums
                .Include(s => s.CountryCodeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stadium == null)
            {
                return NotFound();
            }

            return View(stadium);
        }

        // POST: Stadiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium != null)
            {
                _context.Stadiums.Remove(stadium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StadiumExists(int id)
        {
            return _context.Stadiums.Any(e => e.Id == id);
        }
    }
}
