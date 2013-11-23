using System;
using GoogleSitePageObjects;
using NUnit.Framework;

namespace NUnitIntegrationTestExample
{
    public class GivenTheGoogleSite : UsingABrowser
    {
        protected GoogleSite _site;

        [SetUp]
        public void Given() {
            _site = new GoogleSite(new Uri("https://www.google.com"));
        }
    }
}