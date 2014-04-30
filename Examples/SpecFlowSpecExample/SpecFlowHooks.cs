using System;
using GoogleSitePageObjects;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using WebChauffeur;

namespace SpecFlowSpecExample
{
    [Binding]
    public class SpecFlowHooks
    {
        [BeforeScenario]
        public void BeforeScenario() {
            WebChauffeur.Driver.Init();
            WebChauffeur.SpecFlow.Context.Site = new GoogleSite(new Uri("http://google.com"));
        }

        [AfterScenario]
        public void AfterScenario() {
            WebChauffeur.Driver.CleanUp();
        }
    }
}