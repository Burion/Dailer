using System;
using System.Collections.Generic;
using DailerApp.Models;

namespace DailerApp.Services
{
    public interface IMarkManager
    {
        void CreateMark(DailerUser user, Trait trait);
        void DeleteMark(Mark mark);
        void DeleteAllMarks();
        Mark GetMark(int id);
        List<Mark> GetAllMarks();
        
    }
}