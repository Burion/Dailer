using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DailerApp.Models;
using DailerApp.Services;

namespace DailerApp.Controllers
{
    public class HomeController : Controller
    {
        readonly ITraitService _traitService;
        public HomeController(ITraitService traitService)
        {
            _traitService = traitService;
        }
        public IActionResult Index()
        {
            var traits = _traitService.GetAllTraits();
            string x = String.Join("\n", traits.Select(t => $"{t.Title} - {t.Description}"));
            return Content(x);
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
