
using System;
using Microsoft.EntityFrameworkCore;

namespace DailerApp.Services
{
    public class DbSetRetriever<T> where T: class
    {
        public DbSet<T> RetrieveDdSet(DbContext db)
        {
            return db.Set<T>();
            
        }
    }
}