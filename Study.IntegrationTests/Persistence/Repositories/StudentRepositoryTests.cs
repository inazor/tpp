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
        [Test]
        public void Add_SqliteDataAccess_AddStudentToDatabase()
        {   
            // Arrange
            var sut = new StudentRepository(new SqliteDataAccess());

            var student = new Student() { 
                Name = "Mate",
                Level = 5,
            };

            // Act
            sut.Add(student);

            // Assert
            var students = sut.GetAll();
            var newestStudent = students.OrderByDescending(s => s.Id).FirstOrDefault();

            Assert.That(newestStudent.Name == student.Name && newestStudent.Level == student.Level);

            // Tear down
            sut.Remove(newestStudent.Id);
        }

        [Test]
        public void Remove_JsonDataAccess_RemoveStudentFromDatabase()
        {
            // Arrange
            var sut = new StudentRepository(new JsonDataAccess());

            var student = sut.GetById(1);

            // Act
            sut.Remove(1);

            // Assert
            var students = sut.GetAll();
            var deletedStudent = students.FirstOrDefault(s => s.Id == 1);

            Assert.That(deletedStudent, Is.Null);

            // Tear down
            sut.Add(student);
        }
    }
}
