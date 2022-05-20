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

        [Test]
        public void NavigationBarHeader_WhenClicked_NavigateHome()
        {
            NavigateToPage("Home/Contact");

            var navigationHeaderButton = _driver.FindElement(By.XPath("//a[contains(text(),'Application name')]"));
            navigationHeaderButton.Click();
            Assert.That(_driver.Title, Does.StartWith("Home Page"));
        }

        [Test]
        [TestCase(1, "Home", "Home Page")]
        [TestCase(2, "About", "About")]
        [TestCase(3, "Contact", "Contact")]
        [TestCase(4, "Studenti", "Studenti")]
        [TestCase(5, "Gradovi", "Gradovi")]
        [TestCase(6, "Kolegiji", "Kolegiji")]
        public void NavigationBar_WhenClicked_NavigateToPage(int sequence, string buttonText, string pageTitle)
        {
            var navigationBarButton = _driver.FindElement(By.XPath($"//ul[@class='nav navbar-nav']/li[{sequence}]/a[contains(text(),'{buttonText}')]"));
            navigationBarButton.Click();
            Assert.That(_driver.Title, Does.StartWith(pageTitle).IgnoreCase);
        }

        [Test]
        [TestCase("Studenti")]
        [TestCase("Kolegiji")]
        [TestCase("Gradovi")]
        public void HomePageButtonAll_WhenClicked_NavigateToPage(string tableTitle)
        {
            var buttonAll = _driver.FindElement(By.XPath($"//div[h2[contains(text(),'{tableTitle}')]]/p/a[contains(text(),'Svi')]"));
            buttonAll.Click();

            var jumbotronTitleElement = _driver.FindElement(By.XPath("//h1"));
            Assert.That(jumbotronTitleElement.Text, Is.EqualTo(tableTitle).IgnoreCase);
        }

        [Test]
        public void DoCRUDForStudent()
        {
            var navigationBarButton = _driver.FindElement(By.XPath($"//ul[@class='nav navbar-nav']/li[4]/a[contains(text(),'Studenti')]"));
            navigationBarButton.Click();

            // CREATE
            var createButton = _driver.FindElement(By.XPath($"//a[contains(text(),'Kreiraj')]"));
            createButton.Click();

            var testStudentName = "TEST STUDENT";
            _driver.FindElement(By.XPath("//input[@id='Name']")).SendKeys(testStudentName);

            var testStudentLevel = "99";
            var levelInput = _driver.FindElement(By.XPath("//input[@id='Level']"));
            levelInput.SendKeys(testStudentLevel);

            var saveButton = _driver.FindElement(By.XPath("//button[@type='submit']"));
            saveButton.Click();

            // UPDATE
            var createdStudentEditButton = _driver.FindElement(By.XPath($"//tr[td[2][contains(text(),'{testStudentName}')]]/td[3]/a"));
            createdStudentEditButton.Click();

            var newTestStudentName = "TEST STUDENT 1";
            var nameInput = _driver.FindElement(By.XPath("//input[@id='Name']"));
            nameInput.Clear();
            nameInput.SendKeys(newTestStudentName);

            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            // DELETE
            var createdStudentDeleteButton = _driver.FindElement(By.XPath($"//tr[td[2][contains(text(),'{newTestStudentName}')]]/td[4]/a"));
            createdStudentDeleteButton.Click();

            Assert.That(() => _driver.FindElement(By.XPath($"//tr[td[2][contains(text(),'{newTestStudentName}')]]")), Throws.InstanceOf<NoSuchElementException>());
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