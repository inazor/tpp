using NUnit.Framework;
using Study.Models;
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

        [SetUp]
        public void SetUp()
        {
            _sut = new Student()
            {
                Name = "Mate",
                Level = 1,
            };
        }
    }
}

