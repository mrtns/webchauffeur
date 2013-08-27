using System;
using OpenQA.Selenium;

namespace WebChauffeur
{
    public class Link : BaseElement
    {
        public Type LinksToPage { get; set; }

        public override Page Click(IWebDriver driver, Site currentSite, Page currentPage) {
            base.Click(driver, currentSite, currentPage);
            return currentSite.GetPage(LinksToPage);
        }
    }
}