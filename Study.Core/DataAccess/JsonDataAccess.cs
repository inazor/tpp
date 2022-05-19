using Study.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Study.Persistence
{
    public class JsonDataAccess : IDataAccess
    {

        public T GetById<T>(int id) where T : IModel
        {
            var items = GetEntitites<T>();
            var item = items.FirstOrDefault(i => i.Id == id);
            return item;
        }

        public IEnumerable<T> GetEntitites<T>() where T : IModel
        {
            var fileName = GetFileNameOfType<T>();
            var json = JsonUtil.ReadJsonFile(fileName);
            var result = JsonUtil.DeserializeJsonToType<T>(json);
            return result;
        }

        public void Remove<T>(int id) where T : IModel
        {
            var items = GetEntitites<T>().ToList();
            var item = items.FirstOrDefault(i => i.Id == id);

            var isRemoved = items.Remove(item);

            var fileName = GetFileNameOfType<T>();
            var content = JsonUtil.SerializeJson(items);

            File.WriteAllText(fileName, content);
        }

        public int SaveEntity<T>(T entity) where T : IModel
        {
            var items = GetEntitites<T>().OrderByDescending(i => i.Id).ToList();
            if(entity.Id == 0)
            {
                entity.Id = items[0].Id + 1;
            }

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

            return entity.Id;
        }

        public void Update<T>(int id, T entity) where T : IModel
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
            if(propertyInfo.PropertyType == typeof(int?))
            {
                return true;
            }

            return false;
        }
    }
}