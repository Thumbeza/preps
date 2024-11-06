using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Invstec.Assessment.PageObjects
{
    public class BasePage
    {
        private readonly IWebDriver _driver;
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private const int DefaultWaitTime = 15;
        public bool IsPageVisible;

        public void ClickElement(By by)
        {
            WaitForElementClickable(by);
            _driver.FindElement(by).Click();
        }


        public void InserText(By by, string inputText)
        {
            WaitForElementVisible(by);
            _driver.FindElement(by).SendKeys(inputText);
        }

        public bool WaitForElementVisible(By by, int waitTimeInSeconds = DefaultWaitTime)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTimeInSeconds));

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool WaitForElementClickable(By by, int waitTimeInSeconds = DefaultWaitTime)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTimeInSeconds));

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool WaitForElementPresent(By by, int waitTimeInSeconds = DefaultWaitTime)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTimeInSeconds));

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SelectFromDropdown(By by, string textOption)
        {
            var element = _driver.FindElement(by);

            var selectElement = new SelectElement(element);

            selectElement.SelectByText(textOption);
        }

        public void ScrollIntoView(By by)
        {
            WaitForElementPresent(by);

            var element = _driver.FindElement(by);
            var jsExecutor = (IJavaScriptExecutor)_driver;

            jsExecutor.ExecuteScript("arguments[0].scrollIntoView()", element);
        }


    }
}
