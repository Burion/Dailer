using System;
using System.Collections.Generic;
using DailerApp.Models;

namespace DailerApp.Services
{
    public class MarkManager : IMarkManager
    {
        public IDbWriter<Mark> _dbWriter { get; }
        public IDbReader<Mark> _dbReader { get; }
        public MarkManager(IDbWriter<Mark> dbWriter, IDbReader<Mark> dbReader)
        {
            _dbReader = dbReader;
            _dbWriter = dbWriter;
        }
        public void CreateMark(DailerUser user, Trait trait)
        {
            _dbWriter.WriteToDb(
                new Mark() { User = user, Trait = trait }
            );
        }

        public void DeleteAllMarks()
        {
            _dbWriter.DeleteAllFromDb();
        }

        public void DeleteMark(Mark mark)
        {
            _dbWriter.DeleteFromDb(mark);
        }

        public List<Mark> GetAllMarks()
        {
            return _dbReader.GetAllItems();
        }

        public Mark GetMark(int id)
        {
            throw new NotImplementedException();
        }
    }
}