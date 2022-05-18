using NUnit.Framework;
using Study.Persistence;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.IntegrationTests
{
    [TestFixture]
    public class StudentDriverTests
    {
        private StudentDriver _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new StudentDriver(new StudentRepository(new SqliteDataAccess()));
        }

        [Test]
        public void GetStudentsOrderedByName_WhenCalled_ReturnStudentsOrderedByName()
        {
            var result = _sut.GetStudentsOrderedByName();

            Assert.That(result, Is.Ordered.By("Name"));
        }

        [Test]
        public void GetStudentsOrderedByLevel_WhenCalled_ReturnStudentsOrderedByLevel()
        {
            var result = _sut.GetStudentsOrderedByLevel();

            Assert.That(result, Is.Ordered.By("Level"));
        }
    }
}
