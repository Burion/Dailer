using System;
using DailerApp.Data;

namespace DailerApp.Services
{
    public interface IDbHendler
    {
        ApplicationDbContext _db { get; }
    }
}