using System;
using System.Collections.Generic;

namespace WebChauffeur
{
    public interface IElement : IDisposable
    {
        ISelector Selector { get; }
        string Name { get; }
        IEnumerable<IElement> Elements { get; }

        IElement FindElementByName(string elementName);
    }
}