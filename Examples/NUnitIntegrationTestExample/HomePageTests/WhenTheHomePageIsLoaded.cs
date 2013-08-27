using GoogleSitePageObjects;
using NUnit.Framework;
using WebChauffeur;

namespace NUnitIntegrationTestExample.HomePageTests
{
    public class WhenTheHomePageIsLoaded : GivenTheGoogleSite
    {
        private Page _sut;

        [SetUp]
        public void When() {
            _sut = _site.GetPage(typeof (HomePage));
            _driver.Navigate().GoToPage(_sut);
        }

        [Test]
        public void ItShouldLoadTheHomePage() {
            Assert.That(_sut.VerifyThatBrowserIsOnPage(_driver), Is.True);
        }

        [Test]
        public void ItShouldContainAnAboutGoogleLink() {
            Assert.That(_sut.FindElementByName(_driver, "About Google Link"), Is.Not.Null);
        }
    }
}