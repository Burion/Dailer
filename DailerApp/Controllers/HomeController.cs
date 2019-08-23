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
            var Model = new IndexModel()
            {
                Title = "Hello",
                Labels = _traitService.GetAllTraits().Select(t => t.Title).ToList()
            };
            return View(Model);
        }

        [Route("getstring")]
        public IActionResult GetString()
        {
            string[][] responce = new string[3][];            
            var _thisMonthMarks = _traitService.GetAllTraits().GroupJoin(
                _markManager.GetAllMarks(),
                t => t,
                m => m.Trait,
                (trait, mrks) => new
                {
                    Label = trait.Title,
                    Marks = mrks.Select(m => m.Value)
                })
                .Select(tmrks => new { 
                    Label = tmrks.Label, 
                    Mark = tmrks.Marks.DefaultIfEmpty(0)
                    .Sum()
                    })
                .OrderBy(v => v.Label).ToArray();

            responce[0] = _thisMonthMarks.Select(m => m.Label).ToArray();
            responce[1] = _thisMonthMarks.Select(m => m.Mark.ToString()).ToArray();
            responce[2] = _thisMonthMarks.Select(m => m.Mark.ToString()).ToArray();
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
