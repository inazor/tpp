using NUnit.Framework;
using Study.Controllers;
using Study.DataAccess.Repositories;
using Study.Persistence;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.IntegrationTests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_WhenCalled_FillViewBagWithStudentsAndCourses()
        {
            var sut = new HomeController(
                new StudentRepository(new SqliteDataAccess()),
                new CourseRepository(new SqliteDataAccess()),
                new CityRepository(new SqliteDataAccess()));


            sut.Index();

            Assert.That(sut.ViewBag.Students.Count, Is.GreaterThan(0));
            Assert.That(sut.ViewBag.Courses.Count, Is.GreaterThan(0));
            Assert.That(sut.ViewBag.Cities.Count, Is.GreaterThan(0));
        }
    }
}
