using System;
using DailerApp.Data;
using Microsoft.EntityFrameworkCore;
using DailerApp.AppCore.Services;

namespace DailerApp.Services
{
    public class DbWriterFake<T> : IDbWriter<T> where T: class
    {
        public DbContext _db => throw new NotImplementedException();

        public DbSet<T> dbSet => throw new NotImplementedException();

        public void DeleteAllFromDb()
        {
            throw new NotImplementedException();
        }

        public void DeleteFromDb(T item)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void WriteToDb(T item)
        {
            Console.WriteLine($"Written type was: {typeof(T)}");
        }
    }
}