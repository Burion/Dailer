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
    public class ArchiveController : Controller
    {
        INoteManager _noteManager {get;}
        IMarkManager _markManager {get;}

        public ArchiveController(INoteManager noteManager, IMarkManager markManager)
        {
            _noteManager = noteManager;
            _markManager = markManager;
        }

        public IActionResult ArchivePage()
        {
            return View();
        }
    }
}