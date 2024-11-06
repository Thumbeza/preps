using Invstec.Assessment.Browser;
using OpenQA.Selenium;

namespace Invstec.Assessment.Tests
{
    public class BaseFixture : IDisposable
    {        
        public BaseFixture() 
        {
            var browserFactory = new BrowserFactory();

            Driver = browserFactory.GetBrowser(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
        }

        public IWebDriver Driver;

        public void Dispose()
        {
            Driver?.Dispose();
        }
    }
}
