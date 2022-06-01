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
            NavigateHome();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        private void NavigateHome()
        {
            _driver.Navigate().GoToPage("");
        }

        private void NavigateToPage(string page)
        {
            _driver.Navigate().GoToPage(page);
        }
    }
}