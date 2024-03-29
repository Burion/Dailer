﻿// using System;
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
using DailerApp.AppCore.Services;
using DailerApp.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;



namespace DailerApp.Controllers
{
    public class HomeController : Controller
    {
        readonly ITraitService _traitService;
        readonly IMarkManager _markManager;
        INoteManager _noteManager {get;}
        readonly Random _random;
        public HomeController(ITraitService traitService, IMarkManager markManager, Random random, INoteManager noteManager)
        {
            _traitService = traitService;
            _markManager = markManager;
            _random = random;
            _noteManager = noteManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            var note = _noteManager.GetTodaysCurrentUserNote();
            var Model = new IndexModel()
            {
                Title = "Hello",
                Traits = _traitService.GetAllTraits().ToList(),
                Note = note != null ? note.Text : ""
            };
            return View(Model);
        }

        [Route("getstring")]
        public IActionResult GetString()
        {
            string[][] responce = new string[4][];            
            var _thisMonthMarks = _traitService.GetAllTraits().GroupJoin(
                _markManager.GetAllCurrentUserMarks(),
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
        public IActionResult GetMarks(string day, string month, string year)
        {
            DateTime date = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            return new JsonResult(GetMarks(date));

        }
        public string[][] GetMarks(DateTime date){
            var marks = _markManager.GetMarksByDate(date);
            var currentUsersMarks = _markManager.GetAllCurrentUserMarks();
            var _marks = marks.Intersect(currentUsersMarks);
            //TODO add new overloaded methods to Mark Manager
            string[][] responce = new string[2][];
            string[] traitsIds = _marks.Select(m => m.Trait.Id.ToString()).ToArray();
            string[] marksToResp = _marks.Select(m => m.Value.ToString()).ToArray();
            responce[0] = traitsIds;
            responce[1] = marksToResp;
            return responce;

        }
        [Route("createnote")]
        public IActionResult AddNote(string text)
        {
            if(_noteManager.GetTodaysCurrentUserNote() == null)
                _noteManager.CreateNoteForCurrentUser(text);
            else
                _noteManager.UpdateCurrentUsersTodayNote(text);
            return Ok();
        }
        [Route("clearnotes")]
        public IActionResult ClearAllNotes()
        {
            _noteManager.ClearAllNotes();
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
