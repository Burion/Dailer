
using DailerApp.Data;
using DailerApp.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DailerApp.Services
{
    public class DbHendler<T> : IDbHendler<T> where T : class
    {
        public ApplicationDbContext _db { get; }

        public DbSet<T> dbSet { get; }

        public DbHendler(ApplicationDbContext db)
        {
            _db = db;
            DbSetRetriever<T> dbSetRetriever = new DbSetRetriever<T>();
            dbSet = dbSetRetriever.RetrieveDdSet(_db);
            if(dbSet == null)
            {
                throw new NoSuchTypeInDbContextException(typeof(T));
            }
        }
    }
}