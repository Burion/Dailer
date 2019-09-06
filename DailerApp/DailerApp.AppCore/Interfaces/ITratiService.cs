using System;
using System.Collections.Generic;
using DailerApp.Models;
using DailerApp.Services;
namespace DailerApp.AppCore.Services
{
    public interface ITraitService
    {
        void CreateTrait(string title, string desc);
        Trait GetTraitById(int id);
        void DeleteTrait(Trait trait);
        void DeleteTrait(int id);
        List<Trait> GetAllTraits();
        int GetTraitCount();
        void DeleteAllTraits();
    }
}