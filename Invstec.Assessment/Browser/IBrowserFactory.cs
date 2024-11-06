using OpenQA.Selenium;

namespace Invstec.Assessment.Browser;

public interface IBrowserFactory
{
    IWebDriver GetBrowser();
    IWebDriver GetBrowser(BrowserType browserType);
}
