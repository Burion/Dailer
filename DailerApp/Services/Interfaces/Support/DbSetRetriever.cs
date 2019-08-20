
using System;
using DailerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DailerApp.Services
{
    public class DbSetRetriever<T> where T: class
    {
        public DbSet<T> RetrieveDdSet(ApplicationDbContext db)
        {
            return db.Set<T>();
            
        }
    }
}