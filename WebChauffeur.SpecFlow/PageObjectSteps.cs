using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace WebChauffeur.SpecFlow
{
    [Binding]
    public class PageObjectSteps
    {
        private IWebElement GetWebElementForInput(string elementName)
        {
            var theElement = Context.CurrentPage.FindElementByName(elementName);
            Assert.That(theElement, Is.Not.Null);

            var theElementAsInput = theElement as Input;
            Assert.That(theElementAsInput, Is.Not.Null);

            var inputElement = theElementAsInput.InputElement;
            Assert.That(inputElement, Is.Not.Null);

            var inputElementWebElement = inputElement.GetWebElement();
            Assert.That(inputElementWebElement, Is.Not.Null);

            return inputElementWebElement;
        }

        [Given(@"I select ""([^""]*)"" on the ""([^""]*)"" field")]
        public void GivenISelectTheValueOnTheField(string text, string elementName)
        {
            var theElement = Context.CurrentPage.FindElementByName(elementName);
            Assert.That(theElement, Is.Not.Null);

            var theElementAsInput = theElement as Input;
            Assert.That(theElementAsInput, Is.Not.Null);

            var inputElement = theElementAsInput.InputElement;
            Assert.That(inputElement, Is.Not.Null);

            var inputElementWebElement = inputElement.GetWebElement();
            Assert.That(inputElementWebElement, Is.Not.Null);

            var inputElementWebElementAsSelect = new SelectElement(inputElementWebElement);
            inputElementWebElementAsSelect.SelectByText(text);
        }

        [Then(@"I should see the ""([^""]*)"" with value ""([^""]*)""")]
        public void ThenIShouldSeeTheFieldWithValue(string elementName, string valueText)
        {
            var theElement = Context.CurrentPage.FindElementByName(elementName);
            Assert.That(theElement, Is.Not.Null);

            // TODO: push all this conditional shit into the elements themselves

            var theElementAsButton = theElement as Button;
            if (theElementAsButton != null)
            {
                Assert.That(theElementAsButton.GetWebElement().GetAttribute("value"), Is.StringMatching(valueText));
                return;
            }

            var theElementAsInput = theElement as Input;
            Assert.That(theElementAsInput, Is.Not.Null);

            var labelElement = theElementAsInput.Label;
            if (labelElement != null)
            {
                Assert.That(labelElement, Is.Not.Null);
            }

            var inputElement = theElementAsInput.InputElement;
            Assert.That(inputElement, Is.Not.Null);

            var inputElementWebElement = inputElement.GetWebElement();
            Assert.That(inputElementWebElement, Is.Not.Null);

            var isSelect = inputElementWebElement.TagName.ToLower() == "select";
            if (isSelect == false)
            {
                Assert.That(inputElementWebElement.GetAttribute("value"), Is.StringMatching(valueText));
            }
            else
            {
                var inputElementWebElementAsSelect = new SelectElement(inputElementWebElement);
                if (inputElementWebElementAsSelect.IsMultiple)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    Assert.That(inputElementWebElementAsSelect.SelectedOption.Text, Is.StringMatching(valueText));
                }
            }
        }

        [When(@"I type ""(.*)"" in the ""(.*)"" field")]
        [Given(@"I type ""(.*)"" in the ""(.*)"" field")]
        public void GivenITypeTheValueInTheField(string text, string elementName)
        {
            GetWebElementForInput(elementName).SendKeys(text);
        }

        [Given(@"I clear the value in the ""(.*)"" field")]
        public void GivenIClearTheValueInTheField(string textInputElementName)
        {
            GetWebElementForInput(textInputElementName).Clear();
        }

        [Then(@"I should see the ""([^""]*)"" with text([^""]+)""([^""]*)""")]
        public void ThenIShouldSeeTheText(string elementName, string textComparisonType, string text)
        {
            var theElement = Context.CurrentPage.FindElementByName(elementName);
            var theElementText = theElement.GetWebElement().Text;
            AssertText(textComparisonType, theElementText, text);
        }

        [Then(@"I should see the ""([^""]*)"" with label ""([^""]*)"" and value ""([^""]*)""")]
        public void ThenIShouldSeeTheInput(string elementName, string labelText, string valueText)
        {
            var theElement = Context.CurrentPage.FindElementByName(elementName);
            Assert.That(theElement, Is.Not.Null);

            var theElementAsInput = theElement as Input;
            Assert.That(theElementAsInput, Is.Not.Null);

            var labelElement = theElementAsInput.Label;
            Assert.That(labelElement, Is.Not.Null);

            var labelElementWebElement = labelElement.GetWebElement();
            Assert.That(labelElementWebElement, Is.Not.Null);
            Assert.That(labelElementWebElement.Text.Replace(Environment.NewLine, String.Empty), Is.EqualTo(labelText));

            var inputElement = theElementAsInput.InputElement;
            Assert.That(inputElement, Is.Not.Null);

            var inputElementWebElement = inputElement.GetWebElement();
            Assert.That(inputElementWebElement, Is.Not.Null);

            var isSelect = inputElementWebElement.TagName.ToLower() == "select";
            if (isSelect == false)
            {
                Assert.That(inputElementWebElement.GetAttribute("value"), Is.StringMatching(valueText));
            }
            else
            {
                var inputElementWebElementAsSelect = new SelectElement(inputElementWebElement);
                if (inputElementWebElementAsSelect.IsMultiple)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    Assert.That(inputElementWebElementAsSelect.SelectedOption.Text, Is.StringMatching(valueText));
                }
            }
        }

        [Given(@"I see the ""([^""]*)""")]
        [Then(@"I should see the ""([^""]*)""")]
        public void IShouldSeeThe(string elementName)
        {
            Assert.That(Context.CurrentPage.FindElementByName(elementName).GetWebElement(), Is.Not.Null);
        }

        [Then(@"I should not see the ""([^""]*)""")]
        public void ThenIShouldNotSeeThe(string elementName)
        {
            Assert.Throws<NoSuchElementException>(() => Context.CurrentPage.FindElementByName(elementName).GetWebElement());
        }

        [Given(@"I load the ""([^""]*)"" page")]
        [When(@"I load the ""([^""]*)"" page")]
        public void GivenILoadThePage(string pageName)
        {
            Context.CurrentPage = Context.Site.LoadPage(pageName);
        }

        [Then(@"I should see the ""([^""]*)"" page")]
        public void ThenIShouldSeeThePage(string pageName)
        {
            Assert.That(Context.Site.GetPage(pageName).VerifyThatBrowserIsOnPage(), Is.True);
        }

        [Then(@"I should see the browser page title with text([^""]+)""([^""]*)""")]
        public void ThenIShouldSeeTheBrowserPageTitleWithValue(string textComparisonType, string text)
        {
            var browserTitleText = Driver.GetInstance().Title;
            AssertText(textComparisonType, browserTitleText, text);
        }

        [Then(@"I should see the page with text([^""]+)""([^""]*)""")]
        public void ThenIShouldSeeThePageWithText(string textComparisonType, string text)
        {
            var pageText = Driver.GetInstance().FindElement(By.CssSelector("body")).Text;
            AssertText(textComparisonType, pageText, text);
        }

        [Given(@"I click the ""([^""]*)""")]
        [When(@"I click the ""([^""]*)""")]
        public void WhenIClickTheElement(string elementName)
        {
            Context.CurrentPage.FindElementByName(elementName).GetWebElement().Click();
        }


        private void AssertText(string textComparisonType, string text, string textToAssert)
        {
            switch (textComparisonType)
            {
                case " ":
                    Assert.That(text, Is.EqualTo(textToAssert));
                    break;
                case " containing ":
                    Assert.That(text, Is.StringContaining(textToAssert));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}