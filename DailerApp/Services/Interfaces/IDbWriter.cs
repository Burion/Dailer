using System;

namespace DailerApp.Services
{
    public interface IDbWriter<T> where T: class
    {
        void WriteToDb(T item);
    }
}