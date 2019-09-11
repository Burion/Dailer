using System;

namespace DailerApp.Services
{
    public interface INoteManager
    {
        void CreateNote(string text, string userId);
        void CreateNoteForCurrentUser(string text);
        
    }
}