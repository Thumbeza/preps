using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Invstec.Assessment.Browser
{
    public class BrowserFactory : IBrowserFactory
    {
        public IWebDriver GetBrowser()
        {
            return GetChrome();
        }

        public IWebDriver GetBrowser(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
            {
                return GetChrome();
            }
            else if (browserType == BrowserType.Firefox)
            {
                return GetFirefox();
            }
            else
                throw new ArgumentException($"Invalid selection {nameof(browserType)}, only Chrome and Firefox xan be selected");
        }

        private static IWebDriver GetChrome()
        {
            var options = new ChromeOptions
            {
                AcceptInsecureCertificates = true

            };

            options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);

            return new ChromeDriver(options);
        }

        private static IWebDriver GetFirefox()
        {
            var options = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };

            return new FirefoxDriver(options);
        }
    }
}
