using Study.Models.Interfaces;
using System.Collections.Generic;

namespace Study.Persistence
{
    public interface IDataAccess
    {
        IEnumerable<T> GetEntitites<T>() where T : IModel;
        int SaveEntity<T>(T entity) where T : IModel;
        T GetById<T>(int id) where T : IModel;
        void Update<T>(int id, T entity) where T : IModel;
        void Remove<T>(int id) where T : IModel;
    }
}