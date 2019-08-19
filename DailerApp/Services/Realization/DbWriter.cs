using System;
using DailerApp.Data;
using DailerApp.Services;
using System.Linq;
using DailerApp.Models;

namespace DailerApp.Services
{
    public class DbWriter<T>:  IDbWriter<T> where T: class
    {
        readonly ApplicationDbContext _db;
        public DbWriter(ApplicationDbContext db)
        {
            _db = db;
        }
        public void WriteToDb(T item)
        {
            
            var dbSet = _db.Set<T>();
            dbSet.Add(item);
            Console.WriteLine($"Written type was: {typeof(T)}");
        }
    }
}