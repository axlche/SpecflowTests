using HomeworkSpecFlow.Drivers;
using OpenQA.Selenium;

namespace HomeworkSpecFlow
{
    public class LoginPage : BasePage
    {
        public IWebElement LoginField => FindElement(By.Id("login"));
        public IWebElement PasswordField => FindElement(By.Id("password"));
        public IWebElement BtnLogin => FindElement(By.CssSelector(".btn-primary.rounded-2"));

        public IWebElement CreateUserMenuItem => FindElement(By.XPath("//a[normalize-space()='Create User']"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToCoursePage()
        {
            Driver.Url = "https://viktor-silakov.github.io/course-sut/";
        }

        public void EnterCredentials(string username, string password)
        {
            LoginField.SendKeys(username);
            PasswordField.SendKeys(password);
        }

        public void WaitForSpinner()
        {
            Driver.WaitForElementToBeVisible(By.Id("spinner"));
            Driver.WaitForElementToBeInvisible(By.Id("spinner"));
        }

        public void IsCoursePageLoaded()
        {
            Driver.WaitForElementToExist(By.Id("first-nav-block"));
        }
    }
}
