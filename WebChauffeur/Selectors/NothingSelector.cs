using System;
using OpenQA.Selenium;

namespace WebChauffeur
{
    public class NothingSelector : BaseSelector
    {
        public NothingSelector() : base(String.Empty) {}

        public override IWebElement Select() {
            return null;
        }
    }
}