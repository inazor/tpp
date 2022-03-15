using Study.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDataAccess SqliteDataAccess;

        public Repository(IDataAccess sqliteDataAccess = null)
        {
            SqliteDataAccess = sqliteDataAccess ?? new SqliteDataAccess();
        }

        public void Add(T entity)
        {
            SqliteDataAccess.SaveEntity(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return SqliteDataAccess.GetEntitites<T>();
        }

        public T GetById(int id)
        {
            return SqliteDataAccess.GetById<T>(id);
        }

        public void Update(int id, T entity)
        {
            SqliteDataAccess.Update(id, entity);
        }

        public void Remove(int id)
        {
            SqliteDataAccess.Remove<T>(id);
        }
    }
}