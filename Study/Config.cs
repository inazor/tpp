using Study.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Study
{
    public static class Config
    {
        public const string RootDirectory = "D:\\TPP\\Study";
        public static IDataAccess DataAccess => new SqliteDataAccess();
    }
}