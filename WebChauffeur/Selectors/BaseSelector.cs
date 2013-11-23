using OpenQA.Selenium;

namespace WebChauffeur
{
    public abstract class BaseSelector : ISelector
    {
        protected BaseSelector(string selectorString) {
            Selector = selectorString;
        }

        public string Selector { get; private set; }
    }
}