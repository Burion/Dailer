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

        void UpdateNote(int noteId, string text);
        void UpdateCurrentUsersTodayNote(string text);
        void ClearAllNotes();


        
    }
}