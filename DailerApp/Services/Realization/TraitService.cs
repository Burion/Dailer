using System;
using System.Collections.Generic;
using System.Linq;
using DailerApp.Data;
using DailerApp.Models;

namespace DailerApp.Services
{
    public class TraitService : ITraitService
    {
        readonly IDbWriter<Trait> _dbWriter;
        public TraitService(IDbWriter<Trait> dbWriter)
        {
            _dbWriter = dbWriter;
        }
        public void AddTraitToDb(Trait trait)
        {
            //
        }

        public Trait CreateTrait(string title, string desc)
        {
            Console.WriteLine(_dbWriter.GetType());
            return new Trait() { Title = title, Description = desc }; 
        }

        public void DeleteTrait(Trait trait)
        {
            throw new NotImplementedException();
            // _db.Traits.Remove(
            //     _db.Traits.Single(t => t.Id == trait.Id)
            // );
        }

        public void DeleteTrait(int id)
        {
            // _db.Traits.Remove(
            //     _db.Traits.Single(t => t.Id == id)
            // );
        }

        public List<Trait> GetAllTraits()
        {
            throw new NotImplementedException();
            // return _db.Traits.ToList();
        }

        public Trait GetTraitById(int id)
        {
            throw new NotImplementedException();
            // return _db.Traits.Single(t => t.Id == id);
        }
    }
}