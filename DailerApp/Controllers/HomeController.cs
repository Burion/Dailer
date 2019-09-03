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
                Traits = _traitService.GetAllTraits().ToList()
            };
            return View(Model);
        }

        [Route("getstring")]
        public IActionResult GetString()
        {
            string[][] responce = new string[4][];            
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
            var marks = GetMarks(DateTime.Now);
            responce[2] = marks[0];
            responce[3] = marks[1];
            return new JsonResult(responce);
        }
        [Route("setmark/{trait}/{mark}")]
        public IActionResult SetMark(string trait, string mark)
        {
            var _trait = _traitService.GetTraitById(int.Parse(trait));

            if(_markManager.WasAlreadySetTodayByCurrentUser(_trait))
            {
                var _mark = _markManager.GetTodaysMarkByCurrentUser(_trait);
                _markManager.ChangeMark(_mark, int.Parse(mark));
                
            }
            else
            {
                _markManager.CreateMarkForCurrentUser(
                    _trait,
                    int.Parse(mark)
                );
            }
            
            return GetString();
        }
        [Route("clearmarks")]
        public IActionResult ClearMarks()
        {
            _markManager.DeleteAllMarks();
            return Ok();
        }
        [Route("getmarks/{day}/{month}/{year}")]
        public IActionResult GetMarks(string day, string month, string year){
            DateTime date = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            var marks = _markManager.GetMarksByDate(date);
            string[][] responce = new string[2][];
            string[] traitsIds = marks.Select(m => m.Trait.Id.ToString()).ToArray();
            string[] marksToResp = marks.Select(m => m.Value.ToString()).ToArray();
            responce[0] = traitsIds;
            responce[1] = marksToResp;
            return new JsonResult(responce);

        }
        public string[][] GetMarks(DateTime date){
            var marks = _markManager.GetMarksByDate(date);
            string[][] responce = new string[2][];
            string[] traitsIds = marks.Select(m => m.Trait.Id.ToString()).ToArray();
            string[] marksToResp = marks.Select(m => m.Value.ToString()).ToArray();
            responce[0] = traitsIds;
            responce[1] = marksToResp;
            return responce;

        }

        public IActionResult AddNote(string text)
        {
            
            return Ok();
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
