using System;
using DailerApp.Data;
using DailerApp.Services;
using System.Linq;
using DailerApp.Models;
using DailerApp.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DailerApp.Services
{
    public class DbWriter<T>: DbHendler<T>, IDbWriter<T> where T: class
    {
        public DbWriter(ApplicationDbContext db): base (db)
        {
               
        }
        public void WriteToDb(T item)
        {
            dbSet.Add(item);
            _db.SaveChanges();
            Console.WriteLine($"Written type was: {typeof(T)}");
        }
    }
}