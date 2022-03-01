using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace Study.EndToEndTests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Config.RootDirectory);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        [Test]
        public void Test1()
        {
            NavigateHome();

            var studentListLinkElement = _driver.FindElement(By.LinkText("Studenti"));

            studentListLinkElement.Click();

            var jumbotronTitleElement = _driver.FindElement(By.XPath("//h1"));

            Assert.That(jumbotronTitleElement.Text, Is.EqualTo("studenti").IgnoreCase);
        }

        private void NavigateHome()
        {
            _driver.Navigate().GoToUrl("http://localhost:63671");
        }
    }
}