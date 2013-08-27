using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Script.Serialization;
using OpenQA.Selenium;

namespace WebChauffeur
{
    public abstract class BaseElement : IElement
    {
        protected BaseElement() {
            Selector = new NothingSelector();
            Elements = Enumerable.Empty<IElement>();
        }

        public ISelector Selector { get; set; }

        public string Name { get; set; }

        public IEnumerable<IElement> Elements { get; set; }

        public IElement FindElementByName(IWebDriver driver, string elementName) {
            IElement resultPageObjectElement = Elements.FirstOrDefault(e => String.Equals(e.Name, elementName, StringComparison.InvariantCultureIgnoreCase));

            if (resultPageObjectElement == null) {
                foreach (IElement childElement in Elements) {
                    resultPageObjectElement = childElement.FindElementByName(driver, elementName);
                    if (resultPageObjectElement != null)
                        break;
                }
            }

            if (resultPageObjectElement == null) {
                Debug.Write(String.Format("Could not find child element with name '{0}' on the current element '{1}'.", elementName, Name));
                return null;
            }

            IWebElement browserElement = null;
            Exception browserElementSelectException = null;
            try {
                browserElement = resultPageObjectElement.Selector.Select(driver);
            }
            catch (Exception e) {
                browserElementSelectException = e;
            }

            if (browserElement == null) {
                Debug.Write(String.Format("Element with name '{0}' exists in the page object '{1}' definition, but it was not found in the actual browser page via the driver. Driver exception: {2}", elementName, Name, browserElementSelectException == null ? String.Empty : browserElementSelectException.ToString()));
                return null;
            }

            return resultPageObjectElement;
        }

        public virtual Page Click(IWebDriver driver, Site currentSite, Page currentPage) {
            Selector.Select(driver).Click();
            return currentPage;
        }

        public override string ToString() {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}