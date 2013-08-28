using OpenQA.Selenium;

namespace WebChauffeur
{
    public static class WebDriverExtensions
    {
        public static void GoToPage(this INavigation webdriverNavigation, Page page) {
            webdriverNavigation.GoToUrl(page.UrlOfPageOnSite);
        }
    }
}