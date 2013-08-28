using System;
using System.Diagnostics;
using OpenQA.Selenium;

namespace WebChauffeur
{
    public class Page : ElementBase
    {
        public string UrlRelativeToRootOfSite { get; protected set; }
        public Uri UrlOfPageOnSite { get; set; }

        public bool VerifyThatBrowserIsOnPage(IWebDriver driver) {
            var expectedUrlOfPage = UrlOfPageOnSite;
            var actualBrowserUrl = new Uri(driver.Url);

            return VerifyUsingAbsolutePathComparison(expectedUrlOfPage, actualBrowserUrl);
        }

        protected bool VerifyUsingAbsolutePathComparison(Uri expectedUrlOfPageOnSite, Uri actualBrowserUrl) {
            if (String.Equals(expectedUrlOfPageOnSite.AbsolutePath, actualBrowserUrl.AbsolutePath, StringComparison.InvariantCultureIgnoreCase) == false) {
                Trace.WriteLine(String.Format("Validating Page {0} failed. The browser is not on the page. Tried to match by absolute URL. Expected page URL is {1}. Browser URL is {2}.", Name, expectedUrlOfPageOnSite, actualBrowserUrl));
                return false;
            }

            return true;
        }
    }
}