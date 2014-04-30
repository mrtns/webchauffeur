using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;

namespace WebChauffeur
{
    static public class Driver
    {
        private static IWebDriver driver;
        private const int DefaulTimeOutSeconds = 10;

        private static void SetDriverDefaults()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(DefaulTimeOutSeconds));
        }

        public static void Init(DriverType driverType = DriverType.FireFox, string userAgent = null)
        {
            switch (driverType)
            {

                case DriverType.PhantomJS:
                    var driverService = PhantomJSDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;                    
                    driver = new PhantomJSDriver(driverService);
                    break;
                
                case DriverType.FireFox:

                    if (userAgent == null)
                    {
                        driver = new FirefoxDriver();
                    }
                    else
                    {
                        var profile = new FirefoxProfile();
                        profile.SetPreference("general.useragent.override", userAgent);
                        driver = new FirefoxDriver(profile);
                    }
                    break;

                //TODO:  FireFox should always be default browser.  
                default:
                    break;
            }
            SetDriverDefaults();

        }

        public static IWebDriver GetInstance()
        {
            return driver;
        }

        public static void CleanUp()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Close();
            driver.Quit();
        }
    }

}
