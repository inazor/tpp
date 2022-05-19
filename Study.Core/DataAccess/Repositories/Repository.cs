using Study.Core.Repositories;
using Study.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Study.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : IModel
    {
        protected IDataAccess DataAccess;

        public Repository(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        public int Add(T entity)
        {
            entity.Id = DataAccess.SaveEntity(entity);
            return entity.Id;
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