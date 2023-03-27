using HomeworkSpecFlow.Drivers;
using OpenQA.Selenium;

namespace HomeworkSpecFlow
{
    public class CreateUserPage : BasePage
    {
        public IWebElement CreateUserMenuItem => FindElement(By.XPath("//a[normalize-space()='Create User']"));
        public IWebElement EmailFiled => FindElement(By.Id("email"));
        public IWebElement PasswordField => FindElement(By.Id("password"));
        public IWebElement Address1Field => FindElement(By.Id("address1"));
        public IWebElement Address2Field => FindElement(By.Id("address2"));
        public IWebElement CityField => FindElement(By.Id("city"));
        public IWebElement ZipField => FindElement(By.Id("zip"));
        public IWebElement AnnualPaymentField => FindElement(By.Id("anual"));
        public IWebElement DescriptionField => FindElement(By.Id("description"));
        public IWebElement ButtonSubmit => FindElement(By.CssSelector("button[type='submit']"));

        

        public CreateUserPage(IWebDriver driver) : base(driver)
        {
        }

        public void IsCreateUserFormDisplayed()
        {
            Driver.WaitForElementToBeVisible(By.CssSelector("form[onsubmit='event.preventDefault();']"));
        }

        public void EnterUserDetails(User user)
        {
            EmailFiled.SendKeys(user.Email);
            PasswordField.SendKeys(user.Password);
            Address1Field.SendKeys(user.Address1);
            Address2Field.SendKeys(user.Address2);
            CityField.SendKeys(user.City);
            ZipField.SendKeys(user.Zip);
            AnnualPaymentField.SendKeys(user.AnnualPayment.ToString());
            DescriptionField.SendKeys(user.Description);
        }
    }
}
