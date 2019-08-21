using System;
using DailerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DailerApp.Services
{
    public class DbWriterFake<T> : IDbWriter<T> where T: class
    {
        public ApplicationDbContext _db => throw new NotImplementedException();

        public DbSet<T> dbSet => throw new NotImplementedException();

        public void DeleteAllFromDb()
        {
            throw new NotImplementedException();
        }

        public void DeleteFromDb(T item)
        {
            throw new NotImplementedException();
        }

        public void WriteToDb(T item)
        {
            Console.WriteLine($"Written type was: {typeof(T)}");
        }
    }
}