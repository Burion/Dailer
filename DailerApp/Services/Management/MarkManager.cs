using System;
using System.Collections.Generic;
using System.Linq;
using DailerApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DailerApp.Services
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
        public void CreateMark(DailerUser user, Trait trait)
        {
            _dbWriter.WriteToDb(
                new Mark() { User = user, Trait = trait }
            );
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

        public Mark GetMark(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateMark(DailerUser user, Trait trait, int mark)
        {
            throw new NotImplementedException();
        }

        public void CreateMarkForCurrentUser(Trait trait, int mark)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _dbWriter.WriteToDb(
                new Mark()
                {
                    User = _userMananager.FindByIdAsync(userId).Result,
                    Trait = trait,
                    Value = mark,
                    CreationTime = DateTime.Now
                }
            );
        }

        public List<Mark> GetMarksByDate(DateTime date)
        {
            var marks = _dbReader.GetAllItems();
            return marks.Where(m => m.CreationTime.Date == date.Date).ToList();

        }

        public bool WasAlreadySetTodayByCurrentUser(Trait trait)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _userMananager.FindByIdAsync(userId).Result;
            return WasAlreadySetTodayBy(user, trait);
        }
        public bool WasAlreadySetTodayBy(DailerUser user, Trait trait)
        {
            return GetTodaysMark(user, trait) != null;
        }

        public Mark GetTodaysMark(DailerUser user, Trait trait)
        {
            return _dbReader.GetAllItems().SingleOrDefault(m => m.User.Id == user.Id 
            && m.CreationTime.Date == DateTime.Now.Date 
            && m.Trait == trait);
        }

        public Mark GetTodaysMarkByCurrentUser(Trait trait)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _userMananager.FindByIdAsync(userId).Result;
            return GetTodaysMark(user, trait);
        }

        public void ChangeMark(Mark mark, int value)
        {
            
            _dbWriter.DeleteFromDb(mark);
            _dbWriter.WriteToDb(
                new Mark 
                {
                    Trait = mark.Trait,
                    User = mark.User,
                    CreationTime = DateTime.Now,
                    Value = value
                }
            );
        }
    }
}