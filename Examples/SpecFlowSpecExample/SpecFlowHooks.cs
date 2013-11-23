using System;
using FluentAutomation;
using GoogleSitePageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowSpecExample
{
    [Binding]
    public class SpecFlowHooks
    {
        [BeforeScenario]
        public void BeforeScenario() {
            WebChauffeur.SpecFlow.Context.Site = new GoogleSite(new Uri("https://www.google.com"));
            WebChauffeur.SpecFlow.Context.FluentAutomation = new FluentTest();
            FluentAutomation.SeleniumWebDriver.Bootstrap();
        }

        [AfterScenario]
        public void AfterScenario() {
            WebChauffeur.SpecFlow.Context.Site.Dispose();
            WebChauffeur.SpecFlow.Context.CurrentPage.Dispose();
            WebChauffeur.SpecFlow.Context.FluentAutomation.Dispose();
        }
    }
}