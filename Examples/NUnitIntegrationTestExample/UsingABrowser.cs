using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace NUnitIntegrationTestExample
{
    public class UsingABrowser
    {
        protected IWebDriver _driver;

        [SetUp]
        public void Using() {
            _driver = new FirefoxDriver();
        }

        [TearDown]
        public void TearDown() {
            _driver.Quit();
        }
    }
}