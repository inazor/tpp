using NUnit.Framework;
using Study.Models;
using Study.Persistence;
using Study.Persistence.Repositories;

namespace Study.UnitTests
{
    [TestFixture]
    public class UtilTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var result = Util.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheLargerNumber(int a, int b, int expected)
        {
            var result = Util.Max(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = Util.GetOddNumbers(5);

            //Assert.That(result, Is.Not.Empty);

            //Assert.That(result.Count(), Is.EqualTo(3));

            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);
        }


        [Test]
        [Ignore("Helper seeder")]
        public void Test1()
        {
            //var coursesRepo = new CourseRepository(new SqliteDataAccess<Course>());

            //coursesRepo.Add(new Course { Name = "OOP", Description = "Objektno orijentirano programiranje" });

            //var studentRepo = new StudentRepository();
            //studentRepo.Update(1, new Student { Name = "Mate Matić", CourseId = 3 });

            //var student = studentRepo.GetById(1);

            //studentRepo.Add(new Student { Name = "Jure Jurić" });
            //studentRepo.Add(new Student { Name = "Marko Livaja" });
        }
    }
}