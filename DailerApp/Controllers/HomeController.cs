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
        public HomeController(ITraitService traitService)
        {
            _traitService = traitService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("getstring")]
        public IActionResult GetString()
        {
            var traits = _traitService.GetAllTraits();
            var labels = traits.Select(t => t.Title).ToArray();
            string[][] responce = new string[3][];
            responce[0] = labels;
            responce[1] = new string[] {"43","34","34", "84", "24", "31", "37", "44" };
            responce[2] = new string[] {"43","24","84", "31", "37", "44", "34","34" };
            return new JsonResult(responce);
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
