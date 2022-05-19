using Study.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Study
{
    public static class Config
    {
        public const string RootDirectory = "C:\\Study";
        public static IDataAccess DataAccess => new SqliteDataAccess();
    }
}