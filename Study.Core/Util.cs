using System;
using System.Collections.Generic;
using System.Linq;

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

        public static Func<int, int, int> Multiply = (x, y) => x * y;

        public static List<int> GetOddNumbers(int limit)
        {
            var result = new List<int>();

            for (var i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    result.Add(i);

            return result;
        }
    }
}