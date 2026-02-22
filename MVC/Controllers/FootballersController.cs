using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC.Models;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class FootballersController : Controller
    {
        private readonly LibraryManager<Footballer, int> footballerManager;
        private readonly LibraryManager<Team, int> teamManager;
        private readonly LibraryManager<Country, string> countryManager;

        public FootballersController(LibraryManager<Footballer, int> footballerManager,
                                    LibraryManager<Team, int> teamManager,
                                    LibraryManager<Country, string> countryManager)
        {
            this.footballerManager = footballerManager;
            this.teamManager = teamManager;
            this.countryManager = countryManager;
        }
        // Get Footballer 
        public async Task<IActionResult> Index()
        {
            IEnumerable<Footballer> footballers = await footballerManager.ReadAllAsync(true, false);
            return View(footballers);
        }

        //Get Footballer/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Footballer footballer = await footballerManager.ReadAsync(id, true, false);
            return View(footballer);
        }

        //Get Footballer/Create
        [Authorize(Roles = "Administator")]
        public async Task<IActionResult> Create()
        {
            IEnumerable<Team> teams = await teamManager.ReadAllAsync(false, true);
            IEnumerable<Country> countries = await countryManager.ReadAllAsync(false, true);
            ViewBag.Teams = new SelectList(teams, "Id", "Name");
            ViewBag.Countries = new SelectList(countries, "CountryCode", "CountryName");
            return View();
        }

        //Post Footballer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Age,TeamId,TeamPosition,CountryCode,Price,Salary,ShirtNumber,Captain")] Footballer footballer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await footballerManager.CreateAsync(footballer);
                    return RedirectToAction(nameof(Index));
                }
                return View(footballer);
            }
            catch (Exception ex)
            {
                HelperController.AddError("DB", ex.Message);
                return View("~/Views/Shared/Error.cshtml", HelperController.Errors);
            }
        }

        // get footballer update admin only
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            Footballer footballer = await footballerManager.ReadAsync((int)id, true);
            if (footballer == null) return NotFound();

            ViewBag.Teams = new SelectList(await teamManager.ReadAllAsync(), "Id", "Name", footballer.TeamId);
            ViewBag.Countries = new SelectList(await countryManager.ReadAllAsync(), "CountryCode", "CountryName", footballer.CountryCode);
            return View(footballer);
        }

        // post footballer update admin only
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age,TeamId,TeamPosition,CountryCode,Price,Salary,ShirtNumber,Captain,Trophies")] Footballer footballer)
        {
            if (id != footballer.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await footballerManager.UpdateAsync(footballer);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballerExists(footballer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        HelperController.AddError("Concurrency", "Another user is updating the same footballer!");
                        return View("~/Views/Shared/Error.cshtml", HelperController.Errors);
                    }
                }
            }
            return View(footballer);
        }

        // get footballer delete admin only
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            Footballer footballer = await footballerManager.ReadAsync((int)id, true, true);
            if (footballer == null) return NotFound();

            return View(footballer);
        }

        // post footballer delete admin only
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await footballerManager.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                HelperController.AddError("Concurrency", ex.Message);
                return View("~/Views/Shared/Error.cshtml", HelperController.Errors);
            }
        }
        private bool FootballerExists(int id)
        {
            return footballerManager.ReadAsync(id, false, true) != null;
        }
    }
}