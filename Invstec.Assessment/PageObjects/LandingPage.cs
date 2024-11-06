using OpenQA.Selenium;

namespace Invstec.Assessment.PageObjects
{
    public class LandingPage : BasePage
    {
        private readonly IWebDriver _driver;
        public LandingPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;

            IsPageVisible = IsLandingPageVisible();
        }

        private static By InterestRateDescription => By.XPath("//h1[contains(text(), 'Understanding cash investment interest rates')]");
        private static By SignUpButton =>
            By.XPath("//button[@class='button-primary content-hub-form-container__button js-content-hub-form-container-button' and contains(.,'Sign up')]");

        private bool IsLandingPageVisible()
        {
            if (_driver.Url != "https://www.investec.com/en_za/focus/money/understanding-interest-rates.html")
            {
                _driver.Navigate().GoToUrl("https://www.investec.com/en_za/focus/money/understanding-interest-rates.html");
            }

            return WaitForElementVisible(InterestRateDescription);
        }

        public void OpenSignUpInformationPage()
        {
            ClickElement(SignUpButton);
        }
    }
}
