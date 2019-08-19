using System;

namespace DailerApp.Services
{
    public class DbWriterFake<T> : IDbWriter<T> where T: class
    {
        public void WriteToDb(T item)
        {
            Console.WriteLine($"Written type was: {typeof(T)}");
        }
    }
}