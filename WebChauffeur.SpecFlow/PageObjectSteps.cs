using NUnit.Framework;
using TechTalk.SpecFlow;

namespace WebChauffeur.SpecFlow
{
    [Binding]
    public class PageObjectSteps
    {
        [Given(@"I load the ""([^""]*)"" page")]
        [When(@"I load the ""([^""]*)"" page")]
        public void WhenILoadThePage(string pageName) {    
            Context.CurrentPage = Context.Site.LoadPage(Context.FluentAutomation.I, pageName);
        }

        [Then(@"I should see the ""([^""]*)"" page")]
        public void ThenIShouldSeeThePage(string pageName) {
            Assert.That(Context.Site.GetPage(pageName).VerifyThatBrowserIsOnPage(Context.FluentAutomation.I), Is.True);
        }
    }

    [Binding]
    public class ElementSteps
    {
        [Then(@"I should see the ""([^""]*)""")]
        public void ThenIShouldSeeThe(string elementName) {
            var pageElement = Context.CurrentPage.FindElementByName(elementName);
            Assert.DoesNotThrow(() => pageElement.GetWebElement(Context.FluentAutomation.I));
        }

        [When(@"I click the ""([^""]*)""")]
        public void WhenIClickTheElement(string elementName) {
            var pageElement = Context.CurrentPage.FindElementByName(elementName);
            Context.FluentAutomation.I.Click(pageElement.ElementSelector.Selector);
        }
    }
}