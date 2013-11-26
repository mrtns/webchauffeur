# The WebChauffeur Project


Ride the web in style.


# WebChauffeur

A PageObjects abstraction layer that sits on top of FluentAutomation.

## Overview

Using [Examples/GoogleSitePageObjects/](Examples/GoogleSitePageObjects/)

### Site

"Google Search" is a site. It has two pages: a HomePage, and an AboutPage. 

It also lives on many environments (local, staging, production, etc), so we allow a pass-through rootUrl for the instance we're testing:

[GoogleSiteExamples/GoogleSitePageObjects/GoogleSite.cs](Examples/GoogleSitePageObjects/GoogleSite.cs)
```
namespace GoogleSitePageObjects
{
    public class GoogleSite : Site
    {
        private static readonly Page[] _pages = {
            new HomePage(),
            new AboutPage()
        };

        public GoogleSite(Uri rootUrl) : base("Google Search", rootUrl, _pages) {}
    }
}
```

### Page

The HomePage is a page on the site. It has a name, and a URL relative to the site root.

It also has a set of elements:

[GoogleSiteExamples/GoogleSitePageObjects/HomePage.cs](Examples/GoogleSitePageObjects/HomePage.cs)
```
namespace GoogleSitePageObjects
{
    public class HomePage : Page
    { 
        public HomePage() {
            Name = "Home";
            UrlRelativeToRootOfSite = "/";
            Elements = new List<IElement>();
        }
    }
}
```

### Element

There are two main elements on the HomePage: a "Search Form", and a "Footer". We call these elements components to indicate that they are a semantic grouping or division on the page.

Each of these components, in turn, are made up of other elements.

The "Search Form" has a "Search Button", and a "I'm Feeling Lucky Button". The "Footer" has an "About Google Link":

[GoogleSiteExamples/GoogleSitePageObjects/HomePage.cs](Examples/GoogleSitePageObjects/HomePage.cs)
```
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
                            Selector = new XPathSelector(@"//div[@id='flrs']/a[contains(@href, 'about.html')]")
                        }
                    }
                }
            };
        }
    }
}
```

Just as a Component is just an element:

[WebChauffeur/Elements/Component.cs](WebChauffeur/Elements/Component.cs)
```
namespace WebChauffeur
{
    public class Component : ElementBase {}
}
```

a button is also just an element:

[WebChauffeur/Elements/Button.cs](WebChauffeur/Elements/Button.cs)
```
namespace WebChauffeur
{
    public class Button : ElementBase {}
}
```

and so on for all the other element types:

[WebChauffeur/Elements/](WebChauffeur/Elements/)

TODO: list all the predefined element types

At it's core, the element abstraction is used to:

* define the hierarchy of elements (page -> component -> element -> ...)
* define a name for the element
* define the selector that uniquely identifies the element on the page
* define a method GetWebElement that, when passed a browser driver, will return the instance of the element on the page from the browser

[WebChauffeur/Elements/IElement.cs](WebChauffeur/Elements/IElement.cs)
```
namespace WebChauffeur
{
    public interface IElement
    {
        ISelector Selector { get; }
        string Name { get; }
        IEnumerable<IElement> Elements { get; }

        IElement FindElementByName(string elementName);
        IWebElement GetWebElement(IWebDriver driver);
    }
}
```

TODO: document the separate concerns better here

TODO: document how this fusion of pageobjects pattern and browser dsl is the core of webchauffeur

TODO: show how creating custom elements is useful

TODO: incorporate nunit integration tests into this walkthrough

# WebChauffeur.SpecFlow

SpecFlow porcelain for WebChauffeur.

TODO: document

TODO: UAT vs UI test

# Resources

## Browser Drivers

DSLs or APIs that represent abstractions for driving a web browser.   

* Selenium WebDriver (.NET, ...)
http://www.seleniumhq.org/docs/03_webdriver.jsp
* FluentAutomation (.NET)
http://fluent.stirno.com/
https://github.com/stirno/FluentAutomation
* coypu (.NET)
https://github.com/featurist/coypu
* Capybara (ruby)
https://github.com/jnicklas/capybara
* Watir
http://watir.com/frameworks/
* casper.js (JavaScript)
http://casperjs.org/
