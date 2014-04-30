using GoogleSitePageObjects;
using NUnit.Framework;
using WebChauffeur;

namespace NUnitIntegrationTestExample.HomePageTests
{
    public class GivenTheHomePage : GivenTheGoogleSite
    {
        protected Page _homePage;

        [SetUp]
        public new void Given() {
            base.Given();
            _homePage = _site.LoadPage(typeof (HomePage));
        }
    }
}