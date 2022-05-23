using Moq;
using NUnit.Framework;
using Study.Controllers;
using Study.DataAccess.Interfaces;
using Study.DataAccess.Repositories;
using Study.Models;
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
        public void Index_WithStub_FillViewBagWithData()
        {
            var countryRepositoryStub = new Mock<ICountryRepository>();
            countryRepositoryStub.Setup(repo => repo.GetAll()).Returns(new List<Country> { 
                new Country {
                    Id= 1 , Name= "Croatia"
                },
                new Country {
                    Id = 2, Name = "Slovenia"
                },
                new Country
                {
                    Id = 3, Name = "Germany"
                }
            });

            var sut = new HomeController(
                new StudentRepository(new SqliteDataAccess()),
                new CourseRepository(new SqliteDataAccess()),
                new CityRepository(new SqliteDataAccess()),
                countryRepositoryStub.Object);


            sut.Index();

            Assert.That(sut.ViewBag.Students.Count, Is.GreaterThan(0));
            Assert.That(sut.ViewBag.Courses.Count, Is.GreaterThan(0));
            Assert.That(sut.ViewBag.Cities.Count, Is.GreaterThan(0));
            Assert.That(sut.ViewBag.Countries.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Index_WithImplementation_FillViewBagWithData()
        {
            var sut = new HomeController(
                new StudentRepository(new SqliteDataAccess()),
                new CourseRepository(new SqliteDataAccess()),
                new CityRepository(new SqliteDataAccess()),
                new CountryRepository(new SqliteDataAccess()));

            sut.Index();

            Assert.That(sut.ViewBag.Students.Count, Is.GreaterThan(0));
            Assert.That(sut.ViewBag.Courses.Count, Is.GreaterThan(0));
            Assert.That(sut.ViewBag.Cities.Count, Is.GreaterThan(0));
            Assert.That(sut.ViewBag.Countries.Count, Is.GreaterThan(0));
        }
    }
}
