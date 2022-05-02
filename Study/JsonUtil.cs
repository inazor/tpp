using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Study
{
    public class JsonUtil
    {
        public List<T> DeserializeJsonToType<T>(string json)
        {
            List<T> result = JsonConvert.DeserializeObject<List<T>>(json);
            return result;
        }

        public string SerializeJson(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public string ReadJsonFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string result = reader.ReadToEnd();
            reader.Close();
            return result;
        }
    }
}