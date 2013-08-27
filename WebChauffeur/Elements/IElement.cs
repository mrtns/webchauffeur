using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebChauffeur
{
    public interface IElement
    {
        ISelector Selector { get; }
        string Name { get; }
        IEnumerable<IElement> Elements { get; }

        Page Click(IWebDriver driver, Site currentSite, Page currentPage);
        IElement FindElementByName(IWebDriver driver, string elementName);
    }
}