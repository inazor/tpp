using Study.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected IDataAccess DataAccess;

        public Repository(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        public void Add(T entity)
        {
            DataAccess.SaveEntity(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return DataAccess.GetEntitites<T>();
        }

        public T GetById(int id)
        {
            return DataAccess.GetById<T>(id);
        }

        public void Update(int id, T entity)
        {
            DataAccess.Update(id, entity);
        }

        public void Remove(int id)
        {
            DataAccess.Remove<T>(id);
        }
    }
}