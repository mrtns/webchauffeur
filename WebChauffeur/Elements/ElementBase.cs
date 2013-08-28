using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Script.Serialization;
using OpenQA.Selenium;

namespace WebChauffeur
{
    public class ElementBase : IElement
    {
        protected ElementBase() {
            Selector = new NothingSelector();
            Elements = Enumerable.Empty<IElement>();
        }

        public ISelector Selector { get; set; }

        public string Name { get; set; }

        public IEnumerable<IElement> Elements { get; set; }

        public IElement FindElementByName(string elementName) {
            var result = Elements.FirstOrDefault(e => String.Equals(e.Name, elementName, StringComparison.InvariantCultureIgnoreCase));

            if (result == null) {
                foreach (var childElement in Elements) {
                    result = childElement.FindElementByName(elementName);
                    if (result != null)
                        break;
                }
            }

            if (result == null) {
                Trace.WriteLine(String.Format("Could not find child element with name '{0}' on the current element '{1}'.", elementName, Name));
                return null;
            }

            return result;
        }

        public IWebElement GetWebElement(IWebDriver driver) {
            IWebElement result;
            try {
                result = Selector.Select(driver);
            }
            catch (Exception e) {
                Trace.WriteLine(String.Format("The WebElement for Element with name '{0}' was not found in the actual browser page via the driver. Driver exception: {1}", Name, e));
                throw;
            }
            return result;
        }

        public override string ToString() {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}