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
using Microsoft.AspNetCore.Identity;

namespace DailerApp.Controllers
{
    public class ArchiveController : Controller
    {
        INoteManager _noteManager {get;}
        IMarkManager _markManager {get;}
        IHttpContextHendler _httpContextHendler {get;}
        UserManager<DailerUser> _userManager {get;}
        public ArchiveController(INoteManager noteManager, IMarkManager markManager, IHttpContextHendler httpContextHendler, UserManager<DailerUser> userManager)
        {
            _noteManager = noteManager;
            _markManager = markManager;
            _httpContextHendler = httpContextHendler;
        }

        public IActionResult ArchivePage()
        {
            var id = _httpContextHendler.GetCurrrentUserId();
            
            ArchivePageModel model = new ArchivePageModel()
            {
                Notes = _noteManager.GetUserNotes(id).OrderByDescending(n => n.Date).ToList()
            };
            
            return View(model);
        }
    }
}