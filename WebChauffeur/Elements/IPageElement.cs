using System;
using System.Collections.Generic;

namespace WebChauffeur
{
    public interface IPageElement : IDisposable
    {
        ISelector Selector { get; }
        string Name { get; }
        IEnumerable<IPageElement> Elements { get; }

        IPageElement FindElementByName(string elementName);
    }
}