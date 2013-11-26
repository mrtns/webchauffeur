using System.Collections.Generic;
using WebChauffeur;

namespace GoogleSitePageObjects
{
    public class AboutPage : Page
    {
        public AboutPage() {
            Name = "About Google";
            UrlRelativeToRootOfSite = "/intl/en/about/";
            Elements = new List<IPageElement> {
                new Component {
                    Name = "Summary",
                    ElementSelector = new IdSelector("about-mission"),
                    Elements = new List<IPageElement> {
                        new Component {
                            Name = "Mission Statement Headline",
                            ElementSelector = new IdSelector("#about-mission")
                        }
                    }
                }
            };
        }
    }
}