using System;
using System.Security.Claims;
using DailerApp.AppCore.Services;
using DailerApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace DailerApp.Infrastructure.Services
{
    public class HttpContextHendler : IHttpContextHendler
    {
        IHttpContextAccessor _httpContextAccessor {get;}
        UserManager<DailerUser> _userManager {get;}
        public HttpContextHendler(IHttpContextAccessor httpContextAccessor, UserManager<DailerUser> userManger)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManger;

        }
        public string GetCurrrentUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}