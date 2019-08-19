using System;
using DailerApp.Data;

namespace DailerApp.Services
{
    public interface IDbWriter<T>: IDbHendler where T: class
    {
        void WriteToDb(T item);
    }
}