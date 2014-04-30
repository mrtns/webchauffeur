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
                throw new InvalidOperationException(String.Format("Could not find Page with name '{0}' in Site '{1}'. Pages defined: {2}.", pageName, Name, String.Join(",", Pages.Select(p => p.Name))));

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

        public Page LoadPage(string pageName) {
            return LoadPage(GetPage(pageName).GetType());
        }

        public Page LoadPage(Type pageType) {
            var thePage = GetPage(pageType);
            Driver.GetInstance().Navigate().GoToPage(thePage);

            thePage.VerifyThatBrowserIsOnPage();

            return thePage;
        }

        private static void BindPageToSite(Page page, Uri rootUrlOfSite) {
            page.UrlOfPageOnSite = new Uri(rootUrlOfSite, page.UrlRelativeToRootOfSite);
        }
    }
}