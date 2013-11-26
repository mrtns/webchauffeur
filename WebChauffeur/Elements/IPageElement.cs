using System;
using System.Collections.Generic;
using FluentAutomation.Interfaces;

namespace WebChauffeur
{
    public interface IPageElement : IDisposable
    {
        ISelector ElementSelector { get; }
        string Name { get; }
        IEnumerable<IPageElement> Elements { get; }

        IPageElement FindElementByName(string elementName);

        IElement GetWebElement(INativeActionSyntaxProvider fluentAutomationWebDriver);
        
    }
}