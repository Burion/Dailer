using System;
using System.Collections.Generic;
using DailerApp.Models;

namespace DailerApp.Infrastructure.Services
{
    public interface IMarkManager
    {
        void CreateMark(string userId, Trait trait, int mark);
        void CreateMarkForCurrentUser(Trait trait, int mark);
        void DeleteMark(Mark mark);
        void DeleteAllMarks();
        Mark GetMark(int id);
        List<Mark> GetAllMarks();
        List<Mark> GetAllUserMarks(string userId);
        List<Mark> GetAllCurrentUserMarks();
        bool WasAlreadySetTodayBy(string userId, Trait trait);
        bool WasAlreadySetTodayByCurrentUser(Trait trait);
        List<Mark> GetMarksByDate(DateTime date);
        Mark GetTodaysMark(string userId, Trait trat);
        Mark GetTodaysMarkByCurrentUser(Trait trait);
        void ChangeMark(Mark mark, int value);
        
    }
}