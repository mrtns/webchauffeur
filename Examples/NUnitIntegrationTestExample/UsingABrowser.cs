using FluentAutomation;
using FluentAutomation.Interfaces;
using NUnit.Framework;

namespace NUnitIntegrationTestExample
{
    public class UsingABrowser : FluentTest
    {
        protected INativeActionSyntaxProvider _driver { get { return base.I; } }

        [SetUp]
        public void Using() {
            FluentAutomation.SeleniumWebDriver.Bootstrap();
        }

        [TearDown]
        public void TearDown() {
        }
    }
}