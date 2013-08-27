using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace WebChauffeur
{
    public class Site
    {
        public Site(string name, Uri rootUrl, IEnumerable<Page> pages) {
            Name = name;
            RootUrl = rootUrl;
            Pages = new List<Page>(pages);
        }

        public string Name { get; private set; }
        public Uri RootUrl { get; private set; }
        public List<Page> Pages { get; private set; }

        public Page GetPage(string pageName) {
            var result = Pages.FirstOrDefault(p => String.Equals(pageName, p.Name, StringComparison.InvariantCultureIgnoreCase));
            if (result == null)
                throw new InvalidOperationException(String.Format("Could not find page with name {0}. Pages defined: {1}.", pageName, String.Join(",", Pages.Select(p => p.Name))));

            BindPageToSite(result, RootUrl);
            return result;
        }

        public Page GetPage(Type pageType) {
            var result = Activator.CreateInstance(pageType) as Page;
            if (result == null)
                throw new Exception(String.Format("Failed to instantiate an Page of type {0}. Type needs to exist, needs to implement Page and PageObjectBase.", pageType));
            
            BindPageToSite(result, RootUrl);
            return result;
        }

        public Page LoadPage(IWebDriver driver, string pageName) {
            return LoadPage(driver, GetPage(pageName).GetType());
        }

        public Page LoadPage(IWebDriver driver, Type pageType) {
            var thePage = GetPage(pageType);
            driver.Navigate().GoToPage(thePage);

            thePage.VerifyThatBrowserIsOnPage(driver);

            return thePage;
        }

        private static void BindPageToSite(Page page, Uri rootUrlOfSite) {
            page.UrlOfPageOnSite = new Uri(rootUrlOfSite, page.UrlRelativeToRootOfSite);
        }
    }
}