using System;
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
            _driver.Open(_sut.UrlOfPageOnSite);
        }

        [Test]
        public void ItShouldLoadTheHomePage() {
            Assert.That(_sut.VerifyThatBrowserIsOnPage(_driver), Is.True);
        }

        [Test]
        public void ItShouldContainAnAboutGoogleLink() {
            var link = _sut.FindElementByName("About Google Link");
            Assert.DoesNotThrow(() => _driver.Expect.Exists(link.Selector.Selector));
        }
    }
}