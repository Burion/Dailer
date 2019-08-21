using System;
using DailerApp.Data;

namespace DailerApp.Services
{
    public interface IDbWriter<T>: IDbHendler<T> where T: class
    {
        void WriteToDb(T item);
        void DeleteFromDb(T item);
        void DeleteAllFromDb();
        
    }
}