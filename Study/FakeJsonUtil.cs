using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study
{
    public class FakeJsonUtil : IJsonUtil
    {
        public List<T> DeserializeJson<T>(string json)
        {
            return new List<T>();
        }

        public string ReadFile(string fileName)
        {
            return "";
        }

        public string SerializeJson(object value)
        {
            return "";
        }

        public void WriteAllText(string fileName, string content)
        {
            
        }
    }
}