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
            var fileName = Path.Combine(Config.RootDirectory, "Study", "Persistence", "JsonData", $"{typeof(T).Name}.json");

            using (StreamReader reader = new StreamReader(fileName))
            {
                string json = reader.ReadToEnd();
                List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
                return items;
            }
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
    }
}