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
            if(a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public static IEnumerable<int> GetOddNumbers(int limit)
        {
            for (var i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    yield return i;
        }

        public static int Factorial(int value)
        {
            if (value < 0 || value > 12)
                throw new ArgumentOutOfRangeException("Value must be <= 12");
            int result = 1;
            for (int i = 1; i <= value; i++)
            {
                result *= i;
            }
            return result;
        }

        public static int SumMatrix(int[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);
            if (rowCount > 5 || columnCount > 5)
                throw new ArgumentOutOfRangeException();

            int result = 0;
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < columnCount; j++)
                    result += matrix[i, j];

            return result;
        }

        public static int[] AddConstantToVector(int constant, int[] vector)
        {
            if (vector.Length > 5)
                throw new ArgumentOutOfRangeException();

            int[] C = new int[vector.Length];
            for (int i = 0; i < vector.Length; i++)
                C[i] = constant;

            int[] result = new int[vector.Length];
            for (int i = 0; i < vector.Length; i++)
                result[i] = vector[i] + C[i];

            return result;
        }

        public static int[,] AddConstantToMatrix(int constant, int[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);
            if (rowCount > 5 || columnCount > 5)
                throw new ArgumentOutOfRangeException();

            int[,] C = new int[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < columnCount; j++)
                    C[i, j] = constant;
                
            int[,] result = new int[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < columnCount; j++)
                    result[i, j] = matrix[i, j] + C[i, j];

            return result;
        }
    }
}