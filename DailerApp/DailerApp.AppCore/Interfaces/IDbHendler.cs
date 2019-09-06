using System;
using Microsoft.EntityFrameworkCore;

namespace DailerApp.AppCore.Services
{
    public interface IDbHendler<T> where T: class
    {
        DbContext _db { get; }
        DbSet<T> dbSet { get; }
    }
}