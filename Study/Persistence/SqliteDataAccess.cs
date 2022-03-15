using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace Study.Persistence
{
    public class SqliteDataAccess : IDataAccess
    {
        public IEnumerable<T> GetEntitites<T>() where T: class
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                var tableName = typeof(T).Name;
                var output = connection.Query<T>($"select * from {tableName}", new DynamicParameters());
                return output;
            }
        }

        public void SaveEntity<T>(T entity) where T : class
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                var type = typeof(T);
                var tableName = type.Name;
                var properties = type.GetProperties().Where(prop => ShouldSave(prop));
                var propertyNames = properties.Select(info => info.Name);
                var propertyNamesWithAt = propertyNames.Select(name => $"@{name}");
                var sql = $"insert into {tableName} ({string.Join(",", propertyNames)}) values ({string.Join(",", propertyNamesWithAt)})";

                connection.Execute(sql, entity);
            }
        }

        public T GetById<T>(int id) where T : class
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                var tableName = typeof(T).Name;
                var output = connection.Query<T>($"select * from {tableName} where Id = {id}", new DynamicParameters());
                return output.FirstOrDefault();
            }
        }

        public void Update<T>(int id, T entity) where T : class
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                var type = typeof(T);
                var tableName = type.Name;
                var properties = type.GetProperties().Where(prop => ShouldSave(prop));
                var propertyNamePairs = properties.Select(info => $"{info.Name} = @{info.Name}");
                var sql = $"update {tableName} set {string.Join(",", propertyNamePairs)} where Id = {id}";

                connection.Execute(sql, entity);
            }
        }
        
        public void Remove<T>(int id) where T : class
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                var tableName = typeof(T).Name;
                var sql = $"delete from {tableName} where Id = {id}";
                connection.Execute(sql);
            }
        }

        private bool ShouldSave(PropertyInfo propertyInfo)
        {
            if(propertyInfo.Name == "Id")
            {
                return false;
            }
            if (propertyInfo.PropertyType.IsPrimitive)
            {
                return true;
            }
            if(propertyInfo.PropertyType == typeof(string))
            {
                return true;
            }

            return false;
        }

        private static string GetConnectionString(string id = "Default")
        {
            //var connectionStrings = ConfigurationManager.ConnectionStrings;
            //var a = WebConfigurationManager.ConnectionStrings;
            //var b = ConfigurationManager.AppSettings;
            //return ConfigurationManager.ConnectionStrings[id].ConnectionString;

            return $"Data Source={Path.Combine(Config.RootDirectory, "Study\\StudyDB.db")};Version=3";
        }
    }
}