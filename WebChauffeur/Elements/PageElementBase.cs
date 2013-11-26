using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Script.Serialization;
using FluentAutomation.Interfaces;

namespace WebChauffeur
{
    public class PageElementBase : IPageElement
    {
        protected PageElementBase() {
            ElementSelector = new NothingSelector();
            Elements = Enumerable.Empty<IPageElement>();
        }

        public ISelector ElementSelector { get; set; }

        public string Name { get; set; }

        public IEnumerable<IPageElement> Elements { get; set; }

        public IPageElement FindElementByName(string elementName) {
            var result = Elements.FirstOrDefault(e => String.Equals(e.Name, elementName, StringComparison.InvariantCultureIgnoreCase));

            if (result != null) {
                Trace.WriteLine(String.Format("Page Element '{0}': Found child element with name '{1}'.", Name, elementName));
            }

            if (result == null) {
                foreach (var childElement in Elements) {
                    result = childElement.FindElementByName(elementName);
                    if (result != null)
                        break;
                }
            }

            if (result == null) {
                return null;
            }

            return result;
        }

        public IElement GetWebElement(INativeActionSyntaxProvider fluentAutomationWebDriver) {
            return fluentAutomationWebDriver.Find(ElementSelector.Selector)();
        }

        public override string ToString() {
            return new JavaScriptSerializer().Serialize(this);
        }

        public void Dispose() {
            // do nothing
        }
    }
}