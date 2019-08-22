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
                    Value = mark
                }
            );
        }
    }
}