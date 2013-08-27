using System;
using GoogleSitePageObjects;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace SpecFlowSpecExample
{
    [Binding]
    public class SpecFlowHooks
    {
        [BeforeScenario]
        public void BeforeScenario() {
            WebChauffeur.SpecFlow.Context.Driver = new FirefoxDriver();
            WebChauffeur.SpecFlow.Context.Site = new GoogleSite(new Uri("http://google.com"));
        }

        [AfterScenario]
        public void AfterScenario() {
            WebChauffeur.SpecFlow.Context.Driver.Quit();
        }
    }
}