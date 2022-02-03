using System.Collections.Generic;

namespace Study.Persistence
{
    public interface ISqliteDataAccess
    {
        IEnumerable<T> GetEntitites<T>() where T : class;
        void SaveEntity<T>(T entity) where T : class;
        T GetById<T>(int id) where T : class;
        void Update<T>(int id, T entity) where T : class;
        void Remove<T>(int id) where T : class;
    }
}