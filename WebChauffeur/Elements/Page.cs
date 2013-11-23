using System;
using FluentAutomation.Exceptions;
using FluentAutomation.Interfaces;

namespace WebChauffeur
{
    public class Page : ElementBase
    {
        public string UrlRelativeToRootOfSite { get; protected set; }
        public Uri UrlOfPageOnSite { get; set; }

        public bool VerifyThatBrowserIsOnPage(INativeActionSyntaxProvider fluentAutomation) {
            var expectedUrlOfPage = UrlOfPageOnSite;

            try {
                fluentAutomation.Expect.Url(expectedUrlOfPage);
            }
            catch (FluentExpectFailedException) {
                return false;
            }

            return true;
        }
    }
}