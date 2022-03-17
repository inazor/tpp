using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Study.Persistence
{
    public class JsonDataAccess : IDataAccess
    {

        public T GetById<T>(int id) where T : class
        {
            var items = GetEntitites<T>();
            var idProperty = typeof(T).GetProperty("Id");
            var item = items.FirstOrDefault(i => (int)idProperty.GetValue(i) == id);

            return item;
        }

        public IEnumerable<T> GetEntitites<T>() where T : class
        {
            var fileName = GetFileNameOfType<T>();
            var result = JsonUtil.DeserializeJsonToType<T>(fileName);
            return result;
        }

        public void Remove<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public void SaveEntity<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(int id, T entity) where T : class
        {
            throw new NotImplementedException();
        }

        private string GetFileNameOfType<T>()
        {
            var fileName = Path.Combine(Config.RootDirectory, "Study", "DataAccess", "JsonData", $"{typeof(T).Name}.json");
            return fileName;
        }
    }
}