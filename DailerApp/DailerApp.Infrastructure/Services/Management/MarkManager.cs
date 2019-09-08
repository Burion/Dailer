using System;
using System.Collections.Generic;
using System.Linq;
using DailerApp.Models;
using DailerApp.AppCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;



namespace DailerApp.Infrastructure.Services
{
    public class MarkManager : IMarkManager
    {
        public IDbWriter<Mark> _dbWriter { get; }
        public IDbReader<Mark> _dbReader { get; }
        public UserManager<DailerUser> _userMananager { get; }
        public IHttpContextAccessor _httpContextAccessor {get;}
        public MarkManager(IDbWriter<Mark> dbWriter, IDbReader<Mark> dbReader, UserManager<DailerUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _dbReader = dbReader;
            _dbWriter = dbWriter;
            _userMananager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async void CreateMark(string userId, Trait trait)
        {
            var user = _userMananager.FindByIdAsync(userId).Result;
            var mark = new Mark() { Trait = trait };
            _dbWriter.WriteToDb(mark);
            user.Marks.Add(mark);
            await _userMananager.UpdateAsync(user);
            
            
        }

        public void DeleteAllMarks()
        {
            _dbWriter.DeleteAllFromDb();
        }
        

        public void DeleteMark(Mark mark)
        {
            _dbWriter.DeleteFromDb(mark);
        }

        public List<Mark> GetAllMarks()
        {
            return _dbReader.GetAllItems();
        }
        public List<Mark> GetAllUserMarks(string userId)
        {
            var user = _userMananager.FindByIdAsync(userId).Result;
            return user.Marks;
        }
        public List<Mark> GetAllCurrentUserMarks()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return GetAllUserMarks(userId);
        }

        public Mark GetMark(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateMark(string userId, Trait trait, int mark)
        {
            var _mark = new Mark() { Trait = trait, Value = mark, CreationTime = DateTime.Now };
            _dbWriter.WriteToDb(_mark);
            var user = _userMananager.FindByIdAsync(userId).Result;
            user.Marks.Add(_mark);
            _userMananager.UpdateAsync(user);
        }

        public void CreateMarkForCurrentUser(Trait trait, int mark)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            CreateMark(userId, trait, mark);
        }

        public List<Mark> GetMarksByDate(DateTime date)
        {
            var marks = _dbReader.GetAllItems();
            return marks.Where(m => m.CreationTime.Date == date.Date).ToList();

        }

        public bool WasAlreadySetTodayByCurrentUser(Trait trait)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            return WasAlreadySetTodayBy(userId, trait);
        }
        public bool WasAlreadySetTodayBy(string userId, Trait trait)
        {
            var user = _userMananager.FindByIdAsync(userId).Result;
            return GetTodaysMark(user.Id, trait) != null;
        }

        public Mark GetTodaysMark(string userId, Trait trait)
        {
            var user = _userMananager.FindByIdAsync(userId).Result;
            return user.Marks.SingleOrDefault(m => m.CreationTime.Date == DateTime.Now.Date 
            && m.Trait == trait);
        }

        public Mark GetTodaysMarkByCurrentUser(Trait trait)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return GetTodaysMark(userId, trait);
        }

        public void ChangeMark(Mark mark, int value)
        {
            //var user = _userMananager.Users.SingleOrDefault(u => u.Marks.Contains(mark));
            mark.Value = value;
            _dbWriter.SaveChanges();
        }
    }
}