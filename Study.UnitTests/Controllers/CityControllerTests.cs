using NUnit.Framework;
using Study.Controllers;
using Study.DataAccess.Repositories;
using Study.Models;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.UnitTests.Controllers
{
    [TestFixture]
    public class CityControllerTests
    {
        [Test]
        public void CityRepository_OnRead_ReturnValueOfTypeCityRepository()
        {
            var sut = new CityController();
            var result = sut.CityRepository;
            Assert.That(result, Is.TypeOf<CityRepository>());
            Assert.That(result, Is.InstanceOf<Repository<City>>());
        }


    }
}
