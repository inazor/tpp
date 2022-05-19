using Moq;
using NUnit.Framework;
using Study.Core.Repositories;
using Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.UnitTests.Core.Models
{
    [TestFixture]
    public class StudentTests
    {
        private Mock<IStudentRepository> _studentRepository;
        private Course _course;
        private Student _sut;

        [SetUp]
        public void SetUp()
        {
            _studentRepository = new Mock<IStudentRepository>();
            _course = new Course
            {
                Id = 1,
                Name = "Specijalistički računarstvo",
                Level = 6
            };
            var studentsWithCourses = new List<Student>()
            {
                new Student()
                {
                    Id = 2,
                    Name = "Jure",
                    Level = 1,
                    Course = _course,
                    CourseId = _course.Id
                },
                new Student()
                {
                    Id = 3,
                    Name = "Ante",
                    Level = 1,
                    Course = _course,
                    CourseId = _course.Id
                }
            };
            _studentRepository.Setup(repo => repo.GetStudentsWithCourses()).Returns(studentsWithCourses);
            _sut = new Student(_studentRepository.Object)
            {
                Id = 1,
                Name = "Mate",
                Level = 1,
                Course = _course,
                CourseId = _course.Id
            };
        }

        [Test]
        public void CanEnrollToCourse_CourseLevelIsGreaterByOneThanStudentLevel_ReturnTrue()
        {
            var courseLevel = 2;

            var result = _sut.CanEnrollToCourse(courseLevel);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanEnrollToCourse_CourseLevelIsTheSameAsStudentLevel_ReturnFalse()
        {
            _sut.Level = 2;
            var courseLevel = 2;
            var result = _sut.CanEnrollToCourse(courseLevel);
            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase(1, 2, true)]
        [TestCase(1, 1, false)]
        [TestCase(1, 3, false)]
        [TestCase(3, 1, false)]
        public void CanEnrollToCourse_WhenCalled_ReturnsCorrectValue(int studentLevel, int courseLevel, bool expectedValue)
        {
            _sut.Level = studentLevel;

            var result = _sut.CanEnrollToCourse(courseLevel);
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        // Specific Fragile test
        [Test]
        public void Introduce_WhenCalled_ReturnsIntroductionString()
        {
            var result = _sut.Introduce();
            Assert.That(result, Is.EqualTo("Hello! My name is Mate and my knowledge level is 1."));
        }

        // General test
        [Test]
        public void Introduce_WhenCalled_ReturnsStringContainingNameAndLevel()
        {
            var result = _sut.Introduce();
            Assert.That(result, Does.Contain("mate").IgnoreCase.And.Contain("1"));
        }

        [Test]
        public void Introduce_ShortNameAndLowLevel_ReturnCorrectString()
        {
            var student = new Student() { Name = "Igor", Level = 1 };
            var result = student.Introduce();
            Assert.That(result, Does.Not.Contain("long name").And.Not.Contain("level is high"));
        }

        [Test]
        public void Introduce_ShortNameAndHighLevel_ReturnCorrectString()
        {
            var student = new Student() { Name = "Marko", Level = 50 };
            var result = student.Introduce();
            Assert.That(result, Does.Not.Contain("long name").And.Contain("level is high"));
        }

        [Test]
        public void Introduce_LongNameAndLowLevel_ReturnCorrectString()
        {
            var student = new Student() { Name = "Archibald", Level = 4 };
            var result = student.Introduce();
            Assert.That(result, Does.Contain("long name").And.Not.Contain("level is high"));
        }

        [Test]
        public void Introduce_LongNameAndHighLevel_ReturnCorrectString()
        {
            var student = new Student() { Name = "Zvonimir", Level = 9999 };
            var result = student.Introduce();
            Assert.That(result, Does.Contain("long name").And.Contain("level is high"));
        }

        [Test]
        public void Enroll_StudentLevelIsCorrect_CallUpdate()
        {
            _sut.Level = 5;
            _course.Level = 6;

            _sut.Enroll(_course);
            _studentRepository.Verify(repo => repo.Update(It.IsAny<int>(), It.IsAny<Student>()));
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(1, 3)]
        [TestCase(2, 1)]
        [TestCase(5, 2)]
        public void Enroll_StudentLevelIsIncorrect_ThrowArgumentException(int studentLevel, int courseLevel)
        {
            _sut.Level = studentLevel;
            _course.Level = courseLevel;

            Assert.That(() => _sut.Enroll(_course), Throws.ArgumentException);
        }

        [Test]
        public void GetNumberOfCourseMates_WhenCalled_ReturnNumberOfCourseMates()
        {
            Assert.That(_sut.GetNumberOfCourseMates(), Is.EqualTo(2));
        }
    }
}