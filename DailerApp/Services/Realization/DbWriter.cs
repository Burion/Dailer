using System;
using DailerApp.Data;
using DailerApp.Services;
using System.Linq;
using DailerApp.Models;
using DailerApp.Exceptions;
namespace DailerApp.Services
{
    public class DbWriter<T>:  IDbWriter<T> where T: class
    {
        public ApplicationDbContext _db { get; }
        readonly Microsoft.EntityFrameworkCore.DbSet<T> dbSet;

        public DbWriter(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
            if(dbSet == null)
            {
                throw new NoSuchTypeInDbContextException(typeof(T));
            }
        }
        public void WriteToDb(T item)
        {
            dbSet.Add(item);
            Console.WriteLine($"Written type was: {typeof(T)}");
        }
    }
}