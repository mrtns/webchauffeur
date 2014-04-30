using OpenQA.Selenium;

namespace WebChauffeur
{
    public class CssSelector : BaseSelector
    {
        public CssSelector(string selectorString) : base(selectorString) {}

        public override IWebElement Select() {
            return Driver.FindElement(By.CssSelector(Selector));
        }
    }
}