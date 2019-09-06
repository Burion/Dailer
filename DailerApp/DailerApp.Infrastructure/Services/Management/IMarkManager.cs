using System;
using System.Collections.Generic;
using DailerApp.Models;

namespace DailerApp.Infrastructure.Services
{
    public interface IMarkManager
    {
        void CreateMark(DailerUser user, Trait trait, int mark);
        void CreateMarkForCurrentUser(Trait trait, int mark);
        void DeleteMark(Mark mark);
        void DeleteAllMarks();
        Mark GetMark(int id);
        List<Mark> GetAllMarks();
        bool WasAlreadySetTodayBy(DailerUser user, Trait trait);
        bool WasAlreadySetTodayByCurrentUser(Trait trait);
        List<Mark> GetMarksByDate(DateTime date);
        Mark GetTodaysMark(DailerUser user, Trait trat);
        Mark GetTodaysMarkByCurrentUser(Trait trait);
        void ChangeMark(Mark mark, int value);
        
    }
}