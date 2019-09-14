using System;
using DailerApp.AppCore.Models;

namespace DailerApp.Services
{
    public interface INoteManager
    {
        void CreateNote(string text, string userId);
        void CreateNoteForCurrentUser(string text);
        Note FindNoteById(int id);
        Note FindNoteByUserDate (DateTime date, string userId);
        Note GetTodaysCurrentUserNote();

        
    }
}