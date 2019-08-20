using System;

namespace DailerApp.Services
{
    public interface IDbReader<T>: IDbHendler<T> where T: class
    {
        int GetRowsCount();
    }
}