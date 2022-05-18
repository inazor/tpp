using NUnit.Framework;
using Study.Models;
using Study.Persistence;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.IntegrationTests.Persistence.Repositories
{
    [TestFixture]
    public class StudentRepositoryTests
    {
        private StudentRepository _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new StudentRepository(new SqliteDataAccess());
        }

        [Test]
        public void Add_WhenCalled_AddStudentToDatabase()
        {
            // Arrange
            var student = new Student() { 
                Name = "Mate",
                Level = 5,
            };

            // Act
            _sut.Add(student);

            // Assert
            var students = _sut.GetAll();
            var newestStudent = students.OrderByDescending(s => s.Id).FirstOrDefault();

            Assert.That(newestStudent.Name == student.Name && newestStudent.Level == student.Level);

            // Tear down
            _sut.Remove(newestStudent.Id);
        }
    }
}
