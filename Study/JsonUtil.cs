using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Study
{
    public class JsonUtil : IJsonUtil
    {
        public List<T> DeserializeJson<T>(string json)
        {
            var result = JsonConvert.DeserializeObject<List<T>>(json);
            return result;
        }

        public string SerializeJson(object value)
        {
            var content = JsonConvert.SerializeObject(value);
            return content;
        }

        public string ReadFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }

        public void WriteAllText(string fileName, string content)
        {
            File.WriteAllText(fileName, content);
        }
    }
}