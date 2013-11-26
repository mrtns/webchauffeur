using NUnit.Framework;
using WebChauffeur;

namespace NUnitIntegrationTestExample.HomePageTests
{
    public class WhenTheAboutGoogleLinkIsClicked : GivenTheHomePage
    {
        private Link _aboutGoogleLink;

        [SetUp]
        public void When() {
            _aboutGoogleLink = _homePage.FindElementByName("About Google Link") as Link;
            _driver.Click(_aboutGoogleLink.ElementSelector.Selector);
        }

        [Test]
        public void ItShouldLoadTheAboutGooglePage() {
            Assert.That(_site.GetPage(_aboutGoogleLink.LinksToPage).VerifyThatBrowserIsOnPage(_driver), Is.True);
        }
    }
}