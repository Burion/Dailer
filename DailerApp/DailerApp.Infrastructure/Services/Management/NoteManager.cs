using System;
using DailerApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
namespace DailerApp.Services
{
    public class NoteManager : INoteManager
    {
        UserManager<DailerUser> _userManager {get;}
        public NoteManager(UserManager<DailerUser> userManager)
        {
            _userManager = userManager;
        }
        public void CreateNote(string text, DailerUser user)
        {
            // var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // var User = _userManager.FindByNameAsync(User.Identity.Name).GetAwaiter,
            // Note note = new Note()
            // {
            //     Text = text,
            //     CreationDate = DateTime.Now,
                
            // }
            throw new NotImplementedException();
        }

        public void CreateNoteForCurrentUser(string text)
        {
            throw new NotImplementedException();
        }

        public void DeleteNote(int id)
        {
            throw new NotImplementedException();
        }
    }
}