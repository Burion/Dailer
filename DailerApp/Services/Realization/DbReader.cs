using System;
using DailerApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace DailerApp.Services
{
    public class DbReader<T> : DbHendler<T>, IDbReader<T> where T: class, Models.IEntityModel
    {
        public DbReader(ApplicationDbContext db): base (db)
        {

        }

        public List<T> GetAllItems()
        {
            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Single( i => i.Id == id);
        }

        public int GetRowsCount()
        {
            return dbSet.Count();   
        }
    }
}