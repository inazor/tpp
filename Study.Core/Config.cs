using Study.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Study
{
    public static class Config
    {
        public const string RootDirectory = "D:\\TPP\\Study";
        public static IDataAccess DataAccess => new SqliteDataAccess();
    }
}