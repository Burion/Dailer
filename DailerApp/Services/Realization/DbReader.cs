using System;
using DailerApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace DailerApp.Services
{
    public class DbReader<T> : DbHendler<T>, IDbReader<T> where T: class
    {
        public DbReader(ApplicationDbContext db): base (db)
        {

        }
        public int GetRowsCount()
        {
            return dbSet.Count();   
        }
    }
}