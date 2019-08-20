using System;
using System.Collections.Generic;
using DailerApp.Models;
namespace DailerApp.Services
{
    public interface ITraitService
    {
        void CreateTrait(string title, string desc);
        void AddTraitToDb(Trait trait);
        Trait GetTraitById(int id);
        void DeleteTrait(Trait trait);
        void DeleteTrait(int id);
        List<Trait> GetAllTraits();
        int GetTraitCount();
    }
}