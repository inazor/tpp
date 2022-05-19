using NUnit.Framework;
using Study.Models;
using Study.Persistence;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.IntegrationTests.Core.Models
{
    [TestFixture]
    public class StudentTests
    {
        private Student _sut;
        private StudentRepository _studentRepository;
        private CourseRepository _courseRepository;

        [SetUp]
        public void SetUp()
        {
            _sut = new Student(new StudentRepository(new SqliteDataAccess()))
            {
                Name = "Mate",
                Level = 1,
            };

            _studentRepository = new StudentRepository(new SqliteDataAccess());
            _courseRepository = new CourseRepository(new SqliteDataAccess());
        }

        [Test]
        public void Enroll_LevelsCorrect_SetCourseId()
        {
            var studentId = _studentRepository.Add(_sut);

            var course = new Course()
            {
                Name = "TPP",
                Level = 2
            };
            var courseId = _courseRepository.Add(course);

            _sut.Enroll(course);

            Assert.That(_sut.CourseId, Is.EqualTo(courseId));

            var student = _studentRepository.GetById(studentId);
            Assert.That(student.CourseId, Is.EqualTo(courseId));

            _studentRepository.Remove(studentId);
            _courseRepository.Remove(courseId);
        }

        [Test]
        public void GetNumberOfCourseMates_ThreeStudentsWithSameCourse_ReturnTwo()
        {
            var studentId = _studentRepository.Add(_sut);

            var student2 = new Student()
            {
                Name = "Jure",
                Level = 1
            };
            var student2Id = _studentRepository.Add(student2);
            
            var student3 = new Student()
            {
                Name = "Ante",
                Level = 1
            };
            var student3Id = _studentRepository.Add(student3);

            var course = new Course()
            {
                Name = "TPP",
                Level = 2
            };
            var courseId = _courseRepository.Add(course);

            _sut.Enroll(course);
            student2.Enroll(course);
            student3.Enroll(course);

            var result = _sut.GetNumberOfCourseMates();
            Assert.That(result, Is.EqualTo(2));

            _studentRepository.Remove(studentId);
            _studentRepository.Remove(student2Id);
            _studentRepository.Remove(student3Id);

            _courseRepository.Remove(courseId);
        }
    }
}

