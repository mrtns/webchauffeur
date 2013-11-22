using System.Collections.Generic;
using WebChauffeur;

namespace GoogleSitePageObjects
{
    public class HomePage : Page
    { 
        public HomePage() {
            Name = "Home";
            UrlRelativeToRootOfSite = "/";
            Elements = new List<IElement> {
                new Component {
                    Name = "Search Form",
                    Selector = new IdSelector("gbqf"),
                    Elements = new List<IElement> {
                        new Button {
                            Name = "Search",
                            Selector = new IdSelector("gbqfba")
                        },
                        new Button {
                            Name = "I'm Feeling Lucky",
                            Selector = new IdSelector("gbqfbb")
                        }
                    }
                },
                new Component {
                    Name = "Footer",
                    Selector = new IdSelector("footer"),
                    Elements = new List<IElement> {
                        new Link {
                            Name = "About Google Link",
                            LinksToPage = typeof(AboutPage),
                            Selector = new XPathSelector(@"//div[@id='fbar']//a[contains(@href, 'about.html')]")
                        }
                    }
                }
            };
        }
    }
}