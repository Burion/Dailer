using System;

namespace DailerApp.AppCore.Services
{
    public interface IExperienceManager
    {
        void AddExperience(string userId, int exp);
    }
}