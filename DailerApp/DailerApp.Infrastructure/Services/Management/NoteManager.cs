using System;
using DailerApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using DailerApp.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using DailerApp.AppCore.Services;
using DailerApp.AppCore.Models;
using System.Linq;
using System.Collections.Generic;

namespace DailerApp.Services
{
    public class NoteManager : INoteManager
    {
        UserManager<DailerUser> _userManager {get;}
        public IHttpContextHendler _httpContextHendler {get;}
        IDbReader<Note> _dbReader {get;}
        IDbWriter<Note> _dbWriter {get;}
        public NoteManager(UserManager<DailerUser> userManager, IHttpContextHendler httpContextHendler, IDbReader<Note> dbReader, IDbWriter<Note> dbWriter)
        {
            _userManager = userManager;
            _httpContextHendler = httpContextHendler;
            _dbReader = dbReader;
            _dbWriter = dbWriter;
        }
        public void CreateNote(string text, string userId)
        {
            
            var user = _userManager.FindByIdAsync(userId).Result;
            Note note = new Note()
            {
                Text = text,
                Date = DateTime.Now
                
            };
            user.Notes.Add(note);
            _dbWriter.WriteToDb(note);
            //TODO flag point (fix if necessary )
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
            var note = _dbReader.dbSet.SingleOrDefault(n => n.Date.Date == DateTime.Now.Date); //TODO refactore exception
            return note;
        }

        public void UpdateNote(int noteId, string text)
        {
            var oldNote = _dbReader.GetById(noteId);
            oldNote.Text = text;
            _dbWriter.SaveChanges();
        }

        public void UpdateCurrentUsersTodayNote(string text)
        {
            var note = GetTodaysCurrentUserNote();
            note.Text = text;
            _dbWriter.SaveChanges();
        }
        public void ClearAllNotes()
        {
            _dbWriter.DeleteAllFromDb();
        }

        public List<Note> GetUserNotes(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).Result;
            return user.Notes;
        }
        //TODO dbWriter SaveChanges() - not its concesn
    }
}