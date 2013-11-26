using System.Collections.Generic;
using WebChauffeur;

namespace GoogleSitePageObjects
{
    public class HomePage : Page
    { 
        public HomePage() {
            Name = "Home";
            UrlRelativeToRootOfSite = "/?gl=us";
            Elements = new List<IPageElement> {
                new Component {
                    Name = "Search Form",
                    ElementSelector = new IdSelector("#gbqf"),
                    Elements = new List<IPageElement> {
                        new Button {
                            Name = "Search",
                            ElementSelector = new IdSelector("#gbqfba")
                        },
                        new Button {
                            Name = "I'm Feeling Lucky",
                            ElementSelector = new IdSelector("#gbqfbb")
                        }
                    }
                },
                new Component {
                    Name = "Footer",
                    ElementSelector = new IdSelector("footer"),
                    Elements = new List<IPageElement> {
                        new Link {
                            Name = "About Google Link",
                            LinksToPage = typeof(AboutPage),
                            ElementSelector = new CssSelector(@"#fsl a:last")
                        }
                    }
                }
            };
        }
    }
}