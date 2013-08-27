using OpenQA.Selenium;

namespace WebChauffeur
{
    public class IdSelector : BaseSelector
    {
        public IdSelector(string selectorString) : base(selectorString) {}

        public override IWebElement Select(IWebDriver driver) {
            return driver.FindElement(By.Id(Selector));
        }
    }
}