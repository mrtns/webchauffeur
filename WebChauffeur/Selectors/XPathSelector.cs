using OpenQA.Selenium;

namespace WebChauffeur
{
    public class XPathSelector : BaseSelector
    {
        public XPathSelector(string selectorString) : base(selectorString) {}

        public override IWebElement Select() {
            return Driver.FindElement(By.XPath(Selector));
        }
    }
}