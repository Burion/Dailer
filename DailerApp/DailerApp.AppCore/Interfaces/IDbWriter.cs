using System;

using DailerApp;

namespace DailerApp.AppCore.Services
{
    public interface IDbWriter<T>: IDbHendler<T> where T: class
    {
        void WriteToDb(T item);
        void DeleteFromDb(T item);
        void DeleteAllFromDb();
        void SaveChanges();
        
    }
}