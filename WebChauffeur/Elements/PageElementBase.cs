using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Script.Serialization;

namespace WebChauffeur
{
    public class PageElementBase : IPageElement
    {
        protected PageElementBase() {
            Selector = new NothingSelector();
            Elements = Enumerable.Empty<IPageElement>();
        }

        public ISelector Selector { get; set; }

        public string Name { get; set; }

        public IEnumerable<IPageElement> Elements { get; set; }

        public IPageElement FindElementByName(string elementName) {
            var result = Elements.FirstOrDefault(e => String.Equals(e.Name, elementName, StringComparison.InvariantCultureIgnoreCase));

            if (result == null) {
                foreach (var childElement in Elements) {
                    result = childElement.FindElementByName(elementName);
                    if (result != null)
                        break;
                }
            }

            if (result == null) {
                Trace.WriteLine(String.Format("Element '{0}': searching for child element with name '{1}'. Not found.", Name, elementName));
                return null;
            }

            return result;
        }

        public override string ToString() {
            return new JavaScriptSerializer().Serialize(this);
        }

        public void Dispose() {
            // do nothing
        }
    }
}