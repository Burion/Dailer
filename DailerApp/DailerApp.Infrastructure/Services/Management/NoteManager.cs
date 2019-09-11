using System;
using DailerApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using DailerApp.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using DailerApp.AppCore.Services;
using DailerApp.AppCore.Models;

namespace DailerApp.Services
{
    public class NoteManager : INoteManager
    {
        UserManager<DailerUser> _userManager {get;}
        public IHttpContextHendler _httpContextHendler {get;}
        DbReader<Note> _dbReader {get;}
        DbWriter<Note> _dbWriter {get;}
        public NoteManager(UserManager<DailerUser> userManager, IHttpContextHendler httpContextHendler, DbReader<Note> dbReader, DbWriter<Note> dbWriter)
        {
            _userManager = userManager;
            _httpContextHendler = httpContextHendler;
            _dbReader = dbReader;
            _dbWriter = dbWriter;
        }
        public void CreateNote(string text, string userId)
        {
            
            _userManager.FindByIdAsync(userId);
            Note note = new Note()
            {
                Text = text,
                Date = DateTime.Now
                
            };
            _dbWriter.WriteToDb(note);
        }

        public void CreateNoteForCurrentUser(string text)
        {
            var _userId = _httpContextHendler.GetCurrrentUserId();
            CreateNote(text, _userId);
        }

        public void DeleteNote(int id)
        {
            throw new NotImplementedException();
        }
    }
}