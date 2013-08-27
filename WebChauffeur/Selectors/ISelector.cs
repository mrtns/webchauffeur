using OpenQA.Selenium;

namespace WebChauffeur
{
    public interface ISelector
    {
        string Selector { get; }
        IWebElement Select(IWebDriver driver);
    }
}