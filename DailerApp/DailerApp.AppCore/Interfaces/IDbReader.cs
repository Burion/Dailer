using System;
using System.Collections.Generic;

namespace DailerApp.AppCore.Services
{
    public interface IDbReader<T>: IDbHendler<T> where T: class
    {
        int GetRowsCount();
        T GetById(int id);
        List<T> GetAllItems();
    }
}