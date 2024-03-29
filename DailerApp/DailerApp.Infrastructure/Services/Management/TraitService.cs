using System;
using System.Collections.Generic;
using System.Linq;
using DailerApp.Data;
using DailerApp.Models;
using DailerApp.AppCore.Services;


namespace DailerApp.Services
{
    public class TraitService : ITraitService
    {
        readonly IDbWriter<Trait> _dbWriter;
        readonly IDbReader<Trait> _dbReader;
        public TraitService(IDbWriter<Trait> dbWriter, IDbReader<Trait> dbReader)
        {
            _dbWriter = dbWriter;
            _dbReader = dbReader;
        }
        public void AddTraitToDb(Trait trait)
        {
            //
        }

        public void CreateTrait(string title, string desc)
        {
            _dbWriter.WriteToDb(
                new Trait() { Title = title, Description = desc } 
            );
        }

        public void DeleteTrait(Trait trait)
        {
            throw new NotImplementedException();
            // _db.Traits.Remove(
            //     _db.Traits.Single(t => t.Id == trait.Id)
            // );
        }
        public int GetTraitCount()
        {
            return _dbReader.GetRowsCount();
        }
        public void DeleteTrait(int id)
        {
            // _db.Traits.Remove(
            //     _db.Traits.Single(t => t.Id == id)
            // );
        }

        public List<Trait> GetAllTraits()
        {
            return _dbReader.GetAllItems();
        }

        public Trait GetTraitById(int id)
        {
            return _dbReader.GetById(id);
        }

        public void DeleteAllTraits()
        {
            _dbWriter.DeleteAllFromDb();
        }
    }
}