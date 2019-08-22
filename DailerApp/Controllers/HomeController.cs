// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DailerApp.Models;
using DailerApp.Services;
using DailerApp.ViewModels;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DailerApp.Controllers
{
    public class HomeController : Controller
    {
        readonly ITraitService _traitService;
        readonly IMarkManager _markManager;
        readonly Random _random;
        public HomeController(ITraitService traitService, IMarkManager markManager, Random random)
        {
            _traitService = traitService;
            _markManager = markManager;
            _random = random;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("getstring")]
        public IActionResult GetString()
        {
            var traits = _traitService.GetAllTraits();
            var labels = traits.Select(t => t.Title).OrderBy(title => title).ToArray();
            string[][] responce = new string[3][];
            responce[0] = labels;
            
            var thisMonthMarks = _markManager.GetAllMarks()
            .GroupBy(m => m.Trait)
            .OrderBy(group => group.Key.Title)
            .Select(g => g.Sum(mark => mark.Value).ToString()).ToArray();


            responce[1] = thisMonthMarks;
            responce[2] = thisMonthMarks;
            return new JsonResult(responce);
        }
        [Route("setmark/{mark}")]
        public IActionResult SetMark(string mark)
        {

            int traitId = _random.Next(1, 5);
            _markManager.CreateMarkForCurrentUser(
                _traitService.GetTraitById(traitId),
                int.Parse(mark)
            );
            return new JsonResult("Mark was created");
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
