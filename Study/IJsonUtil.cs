using System.Collections.Generic;

namespace Study
{
    public interface IJsonUtil
    {
        List<T> DeserializeJson<T>(string json);
        string ReadFile(string fileName);
        string SerializeJson(object value);
        void WriteAllText(string fileName, string content);
    }
}