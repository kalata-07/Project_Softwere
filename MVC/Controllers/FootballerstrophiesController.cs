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
    public class FootballerstrophiesController : Controller
    {
        private readonly DBLibraryContext _context;

        public FootballerstrophiesController(DBLibraryContext context)
        {
            _context = context;
        }

        // GET: Footballerstrophies
        public async Task<IActionResult> Index()
        {
            var dBLibraryContext = _context.Footballerstrophies.Include(f => f.Footballer).Include(f => f.Trophy);
            return View(await dBLibraryContext.ToListAsync());
        }

        // GET: Footballerstrophies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballerstrophy = await _context.Footballerstrophies
                .Include(f => f.Footballer)
                .Include(f => f.Trophy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballerstrophy == null)
            {
                return NotFound();
            }

            return View(footballerstrophy);
        }

        // GET: Footballerstrophies/Create
        public IActionResult Create()
        {
            ViewData["FootballerId"] = new SelectList(_context.Footballers, "Id", "CountryCode");
            ViewData["TrophyId"] = new SelectList(_context.Trophies, "Id", "ContinentCode");
            return View();
        }

        // POST: Footballerstrophies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FootballerId,TrophyId")] Footballerstrophy footballerstrophy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footballerstrophy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FootballerId"] = new SelectList(_context.Footballers, "Id", "CountryCode", footballerstrophy.FootballerId);
            ViewData["TrophyId"] = new SelectList(_context.Trophies, "Id", "ContinentCode", footballerstrophy.TrophyId);
            return View(footballerstrophy);
        }

        // GET: Footballerstrophies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballerstrophy = await _context.Footballerstrophies.FindAsync(id);
            if (footballerstrophy == null)
            {
                return NotFound();
            }
            ViewData["FootballerId"] = new SelectList(_context.Footballers, "Id", "CountryCode", footballerstrophy.FootballerId);
            ViewData["TrophyId"] = new SelectList(_context.Trophies, "Id", "ContinentCode", footballerstrophy.TrophyId);
            return View(footballerstrophy);
        }

        // POST: Footballerstrophies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FootballerId,TrophyId")] Footballerstrophy footballerstrophy)
        {
            if (id != footballerstrophy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footballerstrophy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballerstrophyExists(footballerstrophy.Id))
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
            ViewData["FootballerId"] = new SelectList(_context.Footballers, "Id", "CountryCode", footballerstrophy.FootballerId);
            ViewData["TrophyId"] = new SelectList(_context.Trophies, "Id", "ContinentCode", footballerstrophy.TrophyId);
            return View(footballerstrophy);
        }

        // GET: Footballerstrophies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballerstrophy = await _context.Footballerstrophies
                .Include(f => f.Footballer)
                .Include(f => f.Trophy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballerstrophy == null)
            {
                return NotFound();
            }

            return View(footballerstrophy);
        }

        // POST: Footballerstrophies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var footballerstrophy = await _context.Footballerstrophies.FindAsync(id);
            if (footballerstrophy != null)
            {
                _context.Footballerstrophies.Remove(footballerstrophy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootballerstrophyExists(int id)
        {
            return _context.Footballerstrophies.Any(e => e.Id == id);
        }
    }
}
