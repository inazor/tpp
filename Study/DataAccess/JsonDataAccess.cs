using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var json = JsonUtil.ReadJsonFile(fileName);
            var result = JsonUtil.DeserializeJsonToType<T>(json);
            return result;
        }

        public void Remove<T>(int id) where T : class
        {
            var items = GetEntitites<T>().ToList();
            var idProperty = typeof(T).GetProperty("Id");
            var item = items.FirstOrDefault(i => (int)idProperty.GetValue(i) == id);

            var isRemoved = items.Remove(item);

            var fileName = GetFileNameOfType<T>();
            var content = JsonUtil.SerializeJson(items);

            File.WriteAllText(fileName, content);
        }

        public void SaveEntity<T>(T entity) where T : class
        {
            var items = GetEntitites<T>().ToList();
            items.Add(entity);

            var type = typeof(T);
            var properties = type.GetProperties().Where(prop => ShouldSave(prop));
            var mappedItems = items.Select(item => {
                var res = new Dictionary<string, object> { };
                foreach (var property in properties)
                {
                    res[property.Name] = property.GetValue(item);
                }
                return res;
            }).ToList();

            var fileName = GetFileNameOfType<T>();
            var content = JsonUtil.SerializeJson(mappedItems);

            File.WriteAllText(fileName, content);
        }

        public void Update<T>(int id, T entity) where T : class
        {
            throw new NotImplementedException();
        }

        private string GetFileNameOfType<T>()
        {
            var specificClass = typeof(T);
            var className = specificClass.Name;
            var fileName = Path.Combine(Config.RootDirectory, "Study", "DataAccess", "JsonData", $"{className}.json");
            return fileName;
        }

        private bool ShouldSave(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType.IsPrimitive)
            {
                return true;
            }
            if (propertyInfo.PropertyType == typeof(string))
            {
                return true;
            }
            if(propertyInfo.PropertyType == typeof(Nullable<int>))
            {
                return true;
            }

            return false;
        }
    }
}