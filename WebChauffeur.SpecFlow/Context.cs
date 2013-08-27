using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace WebChauffeur.SpecFlow
{
    public static class Context
    {
        private const string DriverKey = "Driver";
        private const string SiteKey = "Site";
        private const string CurrentPageKey = "CurrentPage";

        public static IWebDriver Driver {
            get {
                IWebDriver result;
                ScenarioContext.Current.TryGetValue(DriverKey, out result);
                return result;
            }
            set { ScenarioContext.Current.Set(value, DriverKey); }
        }

        public static Site Site {
            get {
                Site result;
                ScenarioContext.Current.TryGetValue(SiteKey, out result);
                return result;
            }
            set { ScenarioContext.Current.Set(value, SiteKey); }
        }

        public static Page CurrentPage {
            get {
                Page result;
                ScenarioContext.Current.TryGetValue(CurrentPageKey, out result);
                return result;
            }
            set { ScenarioContext.Current.Set(value, CurrentPageKey); }
        }
    }
}