using FluentAutomation;
using TechTalk.SpecFlow;

namespace WebChauffeur.SpecFlow
{
    public static class Context
    {
        private const string SiteKey = "Site";
        private const string CurrentPageKey = "CurrentPage";
        private const string FluentAutomationKey = "FluentAutomation";

        public static FluentTest FluentAutomation {
            get {
                FluentTest result;
                ScenarioContext.Current.TryGetValue(FluentAutomationKey, out result);
                return result;
            }
            set { ScenarioContext.Current.Set(value, FluentAutomationKey );}
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