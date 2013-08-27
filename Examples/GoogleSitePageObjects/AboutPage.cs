using System.Collections.Generic;
using WebChauffeur;

namespace GoogleSitePageObjects
{
    public class AboutPage : Page
    {
        public AboutPage() {
            Name = "About Google";
            UrlRelativeToRootOfSite = "/intl/en/about/";
            Elements = new List<IElement> {
                new Component {
                    Name = "Summary",
                    Selector = new IdSelector("about-mission"),
                    Elements = new List<IElement> {
                        new Component {
                            Name = "Mission Statement Headline",
                            Selector = new XPathSelector(@"//div[@id='about-mission']/blockquote")
                        }
                    }
                }
            };
        }
    }
}