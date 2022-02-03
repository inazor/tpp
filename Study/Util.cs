using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study
{
    public static class Util
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public static IEnumerable<int> GetOddNumbers(int limit)
        {
            for (var i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    yield return i;
        }
    }
}