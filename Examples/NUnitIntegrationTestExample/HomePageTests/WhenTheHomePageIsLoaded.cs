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
            Assert.That(_sut.VerifyThatBrowserIsOnPage(), Is.True);
        }

        [Test]
        public void ItShouldContainAnAboutGoogleLink() {
            Assert.That(_sut.FindElementByName("About Google Link").GetWebElement(), Is.Not.Null);
        }
    }
}