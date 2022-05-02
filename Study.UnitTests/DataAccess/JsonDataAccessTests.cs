using Moq;
using NUnit.Framework;
using Study.Models;
using Study.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.UnitTests.DataAccess
{
    [TestFixture]
    public class JsonDataAccessTests
    {
        [Test]
        public void GetEntities_WithMock_ReturnEmptyList()
        {
            var sut = new JsonDataAccess(new FakeJsonUtil());
            var students = sut.GetEntitites<Student>();
            Assert.That(students, Is.Empty);
        }

        [Test]
        public void Remove_WhenCalled_CallsSerializeJson()
        {
            var jsonUtil = new Mock<IJsonUtil>();
            jsonUtil.Setup(ju => ju.DeserializeJson<Student>(It.IsAny<string>())).Returns(new List<Student>());
            jsonUtil.Setup(ju => ju.ReadFile(It.IsAny<string>())).Returns("");
            jsonUtil.Setup(ju => ju.SerializeJson(It.IsAny<object>())).Returns("");
           
            var sut = new JsonDataAccess(jsonUtil.Object);
            sut.Remove<Student>(1);

            jsonUtil.Verify(ju => ju.SerializeJson(It.IsAny<object>()));
        }
    }
}
