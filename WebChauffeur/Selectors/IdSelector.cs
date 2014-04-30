using OpenQA.Selenium;

namespace WebChauffeur
{
    public class IdSelector : BaseSelector
    {
        public IdSelector(string selectorString) : base(selectorString) {}

        public override IWebElement Select() {
            return Driver.FindElement(By.Id(Selector));
        }
    }
}