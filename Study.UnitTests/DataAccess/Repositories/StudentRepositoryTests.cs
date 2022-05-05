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

namespace Study.UnitTests.DataAccess.Repositories
{
    [TestFixture]
    public class StudentRepositoryTests
    {
        [Test]
        public void GetStudentWithCourse_WhenCalled_CallsGetById()
        {
            var dataAccess = new Mock<IDataAccess>();
            dataAccess.Setup(da => da.GetById<Student>(It.IsAny<int>())).Returns(new Student() { CourseId = 5 });
            dataAccess.Setup(da => da.GetById<Course>(5)).Returns(new Course() { Id = 5 });

            var sut = new StudentRepository(dataAccess.Object);

            var result = sut.GetStudentWithCourse(1);

            dataAccess.Verify(da => da.GetById<Student>(It.IsAny<int>()));
            dataAccess.Verify(da => da.GetById<Course>(It.IsAny<int>()));
        }
    }
}
