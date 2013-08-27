using OpenQA.Selenium;

namespace WebChauffeur
{
    public class CssSelector : BaseSelector
    {
        public CssSelector(string selectorString) : base(selectorString) {}

        public override IWebElement Select(IWebDriver driver) {
            return driver.FindElement(By.CssSelector(Selector));
        }
    }
}