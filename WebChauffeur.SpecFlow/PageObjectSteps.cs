using NUnit.Framework;
using TechTalk.SpecFlow;

namespace WebChauffeur.SpecFlow
{
    [Binding]
    public class PageObjectSteps
    {
        [Given(@"I load the ""([^""]*)"" page")]
        public void GivenILoadThePage(string pageName) {
            Context.CurrentPage = Context.Site.LoadPage(Context.Driver, pageName);
        }

        [When(@"I load the ""([^""]*)"" page")]
        public void WhenILoadThePage(string pageName) {
            GivenILoadThePage(pageName);
        }

        [Then(@"I should see the ""([^""]*)"" page")]
        public void ThenIShouldSeeThePage(string pageName) {
            Assert.That(Context.Site.GetPage(pageName).VerifyThatBrowserIsOnPage(Context.Driver), Is.True);
        }
    }

    [Binding]
    public class ElementSteps
    {
        [Then(@"I should see the ""([^""]*)""")]
        public void ThenIShouldSeeThe(string elementName) {
            Assert.That(Context.CurrentPage.FindElementByName(elementName).GetWebElement(Context.Driver), Is.Not.Null);
        }
        [When(@"I click the ""([^""]*)""")]
        public void WhenIClickTheElement(string elementName) {
            Context.CurrentPage.FindElementByName(elementName).GetWebElement(Context.Driver).Click();
        }
    }
}