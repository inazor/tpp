using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Study
{
    public static class JsonUtil
    {
        public static List<T> ReadJsonFile<T>()
        {
            var fileName = Path.Combine(Config.RootDirectory, "Study", "DataAccess", "JsonData", $"{typeof(T).Name}.json");

            using (StreamReader reader = new StreamReader(fileName))
            {
                string json = reader.ReadToEnd();
                List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
                return items;
            }
        }
    }
}