using System;
using System.Diagnostics;
using FluentAutomation.Exceptions;
using FluentAutomation.Interfaces;

namespace WebChauffeur
{
    public class Page : PageElementBase
    {
        public string UrlRelativeToRootOfSite { get; protected set; }
        public Uri UrlOfPageOnSite { get; set; }

        public bool VerifyThatBrowserIsOnPage(INativeActionSyntaxProvider fluentAutomation) {
            var expectedUrlOfPage = UrlOfPageOnSite;

            try {
                fluentAutomation.Expect.Url(expectedUrlOfPage);
            }
            catch (FluentExpectFailedException) {
                return false;
            }

            return true;
        }

        public IPageElement FindElementByName(string elementName) {
            var result = base.FindElementByName(elementName);

            if (result == null) {
                Trace.WriteLine(String.Format("Page '{0}': Child element with name '{1}' not found.", Name, elementName));
            }

            return result;
        }
    }
}