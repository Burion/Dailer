using System;
using DailerApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using DailerApp.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using DailerApp.AppCore.Services;
using DailerApp.AppCore.Models;
using System.Linq;

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

        public Note FindNoteById(int id)
        {
            throw new NotImplementedException();
        }

        public Note FindNoteByUserDate(DateTime date, string userId)
        {
            throw new NotImplementedException();
        }

        public Note GetTodaysCurrentUserNote()
        {
            var note = _dbReader.dbSet.SingleOrDefault(n => n.Date.Date == DateTime.Now.Date);
            if(note == null)
                throw new Exception(); //TODO refactore exception
            return note;
        }
    }
}