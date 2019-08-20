using System;
using DailerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DailerApp.Services
{
    public interface IDbHendler<T> where T: class
    {
        ApplicationDbContext _db { get; }
        DbSet<T> dbSet { get; }
    }
}