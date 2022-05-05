using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.UnitTests
{
    [TestFixture]
    public class UtilTests
    {
        [Test]
        public void Add_OneAndOne_ReturnTwo()
        {
            var a = 1;
            var b = 1;

            var result = Util.Add(a, b);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Add_TwoAndThree_ReturnFive()
        {
            var a = 2;
            var b = 3;

            var result = Util.Add(a, b);

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Max_TwoAndThree_ReturnThree()
        {
            var a = 2;
            var b = 3;

            var result = Util.Max(a, b);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_ThreeAndTwo_ReturnThree()
        {
            var a = 3;
            var b = 2;

            var result = Util.Max(a, b);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(2, 3, 5)]
        public void Add_TwoIntegers_ReturnSum(int a, int b, int expected)
        {
            var result = Util.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 3, 3)]
        [TestCase(3, 2, 3)]
        public void Max_TwoIntegers_ReturnTheLargerNumber(int a, int b, int expected)
        {
            var result = Util.Max(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, 5, 5)]
        [TestCase(2, 5, 10)]
        public void Multiply_WhenCalled_ReturnProduct(int a, int b, int expected)
        {
            var result = Util.Multiply(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnCollectionIncludingOne()
        {
            var result = Util.GetOddNumbers(5);
            Assert.That(result, Does.Contain(1));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnCorrectNumberOfElements()
        {
            var result = Util.GetOddNumbers(5);
            Assert.That(result, Has.Count.EqualTo(3));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbers()
        {
            var result = Util.GetOddNumbers(5);
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnNumbersInAscendingOrder()
        {
            var result = Util.GetOddNumbers(5);
            Assert.That(result, Is.Ordered.Ascending);
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnNumbersUnique()
        {
            var result = Util.GetOddNumbers(5);
            Assert.That(result, Is.Unique);
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(5, 120)]
        [TestCase(11, 39916800)]
        [TestCase(12, 479001600)]
        public void Factorial_ValidValues_ReturnsFactorial(int value, int expected)
        {
            var result = Util.Factorial(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-3)]
        public void Factorial_NegativeValue_ThrowsArgumentOutOfRangeException(int value)
        {
            Assert.That(() => Util.Factorial(value), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(13)]
        public void Factorial_GreaterThanMaxValue_ThrowsArgumentOutOfRangeException(int value)
        {
            Assert.That(() => Util.Factorial(value), Throws.TypeOf<ArgumentOutOfRangeException>());
        }


        public static IEnumerable<TestCaseData> SumMatrix_InnerLoopWhenOuterLoopSetToMinimalValues_ReturnCorrectValue_Data
        {
            get
            {
                yield return new TestCaseData(new int[,] { { } }, 0);
                yield return new TestCaseData(new int[,] { { 5 } }, 5);
                yield return new TestCaseData(new int[,] { { 5, 3 } }, 8);
                yield return new TestCaseData(new int[,] { { 5, 3, 1 } }, 9);
                yield return new TestCaseData(new int[,] { { 5, 3, 1, 4 } }, 13);
                yield return new TestCaseData(new int[,] { { 5, 3, 1, 4, 7 } }, 20);
            }
        }

        [Test]
        [TestCaseSource("SumMatrix_InnerLoopWhenOuterLoopSetToMinimalValues_ReturnCorrectValue_Data")]
        public void SumMatrix_InnerLoopWhenOuterLoopSetToMinimalValues_ReturnCorrectValue(int[,] matrix, int expected)
        {
            var result = Util.SumMatrix(matrix);
            Assert.That(result, Is.EqualTo(expected));
        }


        public static IEnumerable<TestCaseData> SumMatrix_InnerLoopWhenOuterLoopSetToMinimalValues_ThrowArgumentOutOfRangeException_Data
        {
            get
            {
                yield return new TestCaseData(new int[,] { { 5, 3, 1, 4, 7, 1 } });
            }
        }

        [Test]
        [TestCaseSource("SumMatrix_InnerLoopWhenOuterLoopSetToMinimalValues_ThrowArgumentOutOfRangeException_Data")]
        public void SumMatrix_InnerLoopWhenOuterLoopSetToMinimalValues_ThrowArgumentOutOfRangeException(int[,] matrix)
        {
            Assert.That(() => Util.SumMatrix(matrix), Throws.TypeOf<ArgumentOutOfRangeException>());
        }


        public static IEnumerable<TestCaseData> SumMatrix_OuterLoopWhenInnerLoopSetToTypicalValues_ReturnCorrectValue_Data
        {
            get
            {
                yield return new TestCaseData(new int[,] { }, 0);
                yield return new TestCaseData(new int[,] { { 5, 3, 1 } }, 9);
                yield return new TestCaseData(new int[,] { { 5, 3, 1 }, { 5, 3, 1 } }, 18);
                yield return new TestCaseData(new int[,] { { 5, 3, 1 }, { 5, 3, 1 }, { 5, 3, 1 } }, 27);
                yield return new TestCaseData(new int[,] { { 5, 3, 1 }, { 5, 3, 1 }, { 5, 3, 1 }, { 5, 3, 1 } }, 36);
                yield return new TestCaseData(new int[,] { { 5, 3, 1 }, { 5, 3, 1 }, { 5, 3, 1 }, { 5, 3, 1 }, { 5, 3, 1 } }, 45);
            }
        }

        [Test]
        [TestCaseSource("SumMatrix_OuterLoopWhenInnerLoopSetToTypicalValues_ReturnCorrectValue_Data")]
        public void SumMatrix_OuterLoopWhenInnerLoopSetToTypicalValues_ReturnCorrectValue(int[,] matrix, int expected)
        {
            var result = Util.SumMatrix(matrix);
            Assert.That(result, Is.EqualTo(expected));
        }

        public static IEnumerable<TestCaseData> SumMatrix_OuterLoopWhenInnerLoopSetToTypicalValues_ThrowArgumentOutOfRangeException_Data
        {
            get
            {
                yield return new TestCaseData(new int[,] { { 5, 3, 1 }, { 5, 3, 1 }, { 5, 3, 1 }, { 5, 3, 1 }, { 5, 3, 1 }, { 5, 3, 1 } });
            }
        }

        [Test]
        [TestCaseSource("SumMatrix_OuterLoopWhenInnerLoopSetToTypicalValues_ThrowArgumentOutOfRangeException_Data")]
        public void SumMatrix_OuterLoopWhenInnerLoopSetToTypicalValues_ThrowArgumentOutOfRangeException(int[,] matrix)
        {
            Assert.That(() => Util.SumMatrix(matrix), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(5, new int[] { }, new int[] { })]
        [TestCase(5, new int[] { 0 }, new int[] { 5 })]
        [TestCase(5, new int[] { 0, 0 }, new int[] { 5, 5 })]
        [TestCase(5, new int[] { 0, 0, 0 }, new int[] { 5, 5, 5 })]
        [TestCase(5, new int[] { 0, 0, 0, 0 }, new int[] { 5, 5, 5, 5 })]
        [TestCase(5, new int[] {0, 0, 0, 0, 0}, new int[] {5, 5, 5, 5, 5})]
        public void AddConstantToVector_FirstLoopWhenSecondLoopDoesntAddAnything_ReturnCorrectValue(int constant, int[] vector, int[] expected)
        {
            var result = Util.AddConstantToVector(constant, vector);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(5, new int[] { 0, 0, 0, 0, 0, 0})]
        public void AddConstantToVector_FirstLoopWhenSecondLoopDoesntAddAnything_ThrowArgumentOutOfRangeException(int constant, int[] vector)
        {
            Assert.That(() => Util.AddConstantToVector(constant, vector), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(5, new int[] { }, new int[] { })]
        [TestCase(5, new int[] { 1 }, new int[] { 6 })]
        [TestCase(5, new int[] { 1, 2 }, new int[] { 6, 7 })]
        [TestCase(5, new int[] { 1, 2, 3 }, new int[] { 6, 7, 8 })]
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 6, 7, 8, 9 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 10 })]
        public void AddConstantToVector_SecondLoop_ReturnCorrectValue(int constant, int[] vector, int[] expected)
        {
            var result = Util.AddConstantToVector(constant, vector);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void AddConstantToVector_SecondLoop_ThrowArgumentOutOfRangeException(int constant, int[] vector)
        {
            Assert.That(() => Util.AddConstantToVector(constant, vector), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
