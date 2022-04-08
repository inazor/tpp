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

    }
}
