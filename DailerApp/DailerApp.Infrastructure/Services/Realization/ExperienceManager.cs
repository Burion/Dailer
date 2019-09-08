using System;
using DailerApp.AppCore.Services;
using DailerApp.Models;
using Microsoft.AspNetCore.Identity;

namespace DailerApp.Infrastructure.Services
{
    
    public class ExperienceManager : IExperienceManager
    {
        UserManager<DailerUser> _userManager { get; }

        public ExperienceManager(UserManager<DailerUser> userManager)
        {
           _userManager = userManager;
        }
        public void AddExperience(string userId, int exp)
        {
            var user = _userManager.FindByIdAsync(userId).Result;
            user.Expierence += exp;
        }
    }
}