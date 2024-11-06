using OpenQA.Selenium;

namespace Invstec.Assessment.PageObjects
{
    public class SignUpInformationPage : BasePage
    {
        public SignUpInformationPage(IWebDriver driver) : base(driver)
        {
            IsPageVisible = IsSignUpInformationPageVisible();
        }

        private static By NameInput => By.XPath("//input[@name='name']");
        private static By SurnameInput => By.XPath("//input[@name='surname']");
        private static By EmailInput => By.XPath("//input[@name='email']");
        private static By ServiceDropdown => By.Id("service");
        private static By YearOfBirthInput => By.XPath("//input[@name='year_of_birth']");
        private static By SubmitButton => By.XPath("//button[contains(text(),'email')]");

        private bool IsSignUpInformationPageVisible()
        {
            return WaitForElementVisible(NameInput);
        }

        public void AddName(string name)
        {
            InserText(NameInput, name);
        }

        public void AddSurname(string surname)
        {
            InserText(SurnameInput, surname);
        }

        public void AddEmail(string email)
        {
            InserText(EmailInput, email);
        }

        public void SelectService(string investecService)
        {
            SelectFromDropdown(ServiceDropdown, investecService);
        }

        public void AddYearOfBirth(int yearOfBirth)
        {
            InserText(YearOfBirthInput, yearOfBirth.ToString());
        }

        public bool IsSubmitButtonClickable()
        {
            return WaitForElementClickable(SubmitButton, 3);
        }

        public void Sumbit()
        {
            ClickElement(SubmitButton);
        }
    }
}
