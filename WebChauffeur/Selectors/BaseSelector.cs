using OpenQA.Selenium;

namespace WebChauffeur
{
    public abstract class BaseSelector : ISelector
    {
        public IWebDriver Driver { get { return WebChauffeur.Driver.GetInstance();  } }

        protected BaseSelector(string selectorString) {
            Selector = selectorString;
        }

        public string Selector { get; private set; }

        public abstract IWebElement Select();
    }
}