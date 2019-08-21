using System;
using System.Collections.Generic;

namespace DailerApp.Services
{
    public interface IDbReader<T>: IDbHendler<T> where T: class
    {
        int GetRowsCount();
        T GetById(int id);
        List<T> GetAllItems();
    }
}