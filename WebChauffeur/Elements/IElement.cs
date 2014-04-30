using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebChauffeur
{
    public interface IElement
    {
        ISelector Selector { get; }
        string Name { get; }
        IEnumerable<IElement> Elements { get; }

        IElement FindElementByName(string elementName);
        IWebElement GetWebElement();
    }
}