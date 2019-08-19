using System;
using DailerApp.Data;

namespace DailerApp.Services
{
    public class DbWriterFake<T> : IDbWriter<T> where T: class
    {
        public ApplicationDbContext _db => throw new NotImplementedException();

        public void WriteToDb(T item)
        {
            Console.WriteLine($"Written type was: {typeof(T)}");
        }
    }
}