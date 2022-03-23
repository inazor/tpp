using Moq;
using NUnit.Framework;
using Study.Models;
using Study.Persistence;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.UnitTests.Persistence.Repositories
{
    [TestFixture]
    public class StudentRepositoryTests
    {
        private Mock<IDataAccess> _sqliteDataAccess;
        private StudentRepository _sut;

        [SetUp]
        public void SetUp()
        {
            _sqliteDataAccess = new Mock<IDataAccess>();

            var student = new Student
            {
                Id = 1,
                Name = "Mate",
                Level = 4,
                CourseId = 5
            };
            _sqliteDataAccess.Setup(sqlDA => sqlDA.GetById<Student>(It.IsAny<int>())).Returns(student);

            var course = new Course
            {
                Id = 5,
                Name = "Specijalistički Računarstvo"
            };
            _sqliteDataAccess.Setup(sqlDA => sqlDA.GetById<Course>(5)).Returns(course);

            _sut = new StudentRepository(_sqliteDataAccess.Object);
        }


        [Test]
        public void GetStudentWithCourse_WhenCalled_ReturnStudentObjectWithPopulatedCourseField()
        {
            var student = _sut.GetStudentWithCourseAndCity(1);
            Assert.That(student.Course, Is.Not.Null);
        }
    }
}
