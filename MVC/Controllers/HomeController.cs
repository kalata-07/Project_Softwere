using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
    {
        public class HomeController : Controller
        {
            private readonly IdentityContext _identityContext;
            public HomeController(IdentityContext identityContext)
            {
                _identityContext = identityContext;
            }

            public async Task<IActionResult> Index()
            {
                //await _identityContext.SeedDataAsync("Admin4o_", "admin@abv.bg");
                return View();
            }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
            }
        }
    }


