using System;
using WebChauffeur;

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