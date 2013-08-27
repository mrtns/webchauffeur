using NUnit.Framework;
using WebChauffeur;

namespace NUnitIntegrationTestExample.HomePageTests
{
    public class WhenTheAboutGoogleLinkIsClicked : GivenTheHomePage
    {
        private Page _aboutGooglePage;

        [SetUp]
        public void When() {
            var aboutGoogleLink = _homePage.FindElementByName(_driver, "About Google Link");
            _aboutGooglePage = aboutGoogleLink.Click(_driver, _site, _homePage);
        }

        [Test]
        public void ItShouldLoadTheAboutGooglePage() {
            Assert.That(_aboutGooglePage.VerifyThatBrowserIsOnPage(_driver), Is.True);
        }
    }
}