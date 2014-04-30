using System;
using System.Diagnostics;
using OpenQA.Selenium;

namespace WebChauffeur
{
    public class Page : ElementBase
    {
        public string UrlRelativeToRootOfSite { get; protected set; }
        public Uri UrlOfPageOnSite { get; set; }
        public string Title { get { return Driver.Title; } }
        public string BodyText { get { return Driver.FindElement(By.CssSelector("body")).Text; } }

        public bool VerifyThatBrowserIsOnPage() {
            var expectedUrlOfPage = UrlOfPageOnSite;
            var actualBrowserUrl = new Uri(Driver.Url);

            return VerifyUsingAbsolutePathComparison(expectedUrlOfPage, actualBrowserUrl);
        }

        protected bool VerifyUsingAbsolutePathComparison(Uri expectedUrlOfPageOnSite, Uri actualBrowserUrl) {
            if (String.Equals(expectedUrlOfPageOnSite.AbsolutePath, actualBrowserUrl.AbsolutePath, StringComparison.InvariantCultureIgnoreCase) == false) {
                Trace.WriteLine(String.Format("Validating Page {0} failed. The browser is not on the page. Tried to match by absolute URL. Expected page URL is {1}. Browser URL is {2}.", Name, expectedUrlOfPageOnSite, actualBrowserUrl));
                return false;
            }

            return true;
        }

        public new IElement FindElementByName(string elementName) {
            var result = base.FindElementByName(elementName);

            if (result == null) {
                Trace.WriteLine(String.Format("Page '{0}': Child element with name '{1}' not found.", Name, elementName));
            }

            return result;
        }

        
    }
}