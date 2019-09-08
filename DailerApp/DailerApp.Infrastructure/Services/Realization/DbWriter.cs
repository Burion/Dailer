using System;
using DailerApp.Data;
using DailerApp.Services;
using System.Linq;
using DailerApp.Models;
using DailerApp.Exceptions;
using Microsoft.EntityFrameworkCore;
using DailerApp.AppCore.Services;

namespace DailerApp.Services
{
    public class DbWriter<T>: DbHendler<T>, IDbWriter<T> where T: class
    {
        public DbWriter(ApplicationDbContext db): base (db)
        {
               
        }

        public void DeleteAllFromDb()
        {
            foreach(var item in dbSet)
            {
                dbSet.Remove(item);
            }
            _db.SaveChanges();
        }

        public void DeleteFromDb(T item)
        {
            dbSet.Remove(item);
            _db.SaveChanges();
        }

        public void WriteToDb(T item)
        {
            dbSet.Add(item);
            _db.SaveChanges();
            Console.WriteLine($"Written type was: {typeof(T)}");
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}