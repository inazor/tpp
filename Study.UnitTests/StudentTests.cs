using NUnit.Framework;
using Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.UnitTests
{
    [TestFixture]
    public class StudentTests
    {
        private Student _student;

        [SetUp]
        public void SetUp()
        {
            _student = new Student()
            {
                Name = "Marko",
                Level = 5
            };
        }


        [Test]
        [TestCase(1, 2, true)]
        [TestCase(2, 2, false)]
        [TestCase(3, 2, false)]
        [TestCase(1, 3, false)]
        public void CanEnrollToCourse_WhenCalled_ReturnIfStudentCanEnrollToCourse(int studentLevel, int courseLevel, bool expected)
        {
            _student.Level = studentLevel;

            var result = _student.CanEnrollToCourse(courseLevel);
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        public void Introduce_WhenCalled_ReturnExactIntroductionString()
        {
            var result = _student.Introduce();
            Assert.That(result, Is.EqualTo("Hello! My name is Marko and my knowledge level is 5"));
        }

        [Test]
        public void Introduce_WhenCalled_ReturnStringContainingHelloAndStudentName()
        {
            var result = _student.Introduce();
            Assert.That(result, Does.Contain("marko").IgnoreCase.And.Contain("hello").IgnoreCase);
        }
    }
}
