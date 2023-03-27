using HomeworkSpecFlow.Drivers;
using TechTalk.SpecFlow;

namespace HomeworkSpecFlow.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly LoginPage _loginPage;
        public LoginStepDefinitions(SeleniumDriver seleniumDriver)
        {
            _loginPage = new LoginPage(seleniumDriver.Driver);
        }

        [Given(@"Open page with login form")]
        public void GivenPageWithLoginForm()
        {
            _loginPage.GoToCoursePage();
        }

        [When(@"I enter the following credentials")]
        public void WhenIEnterTheFollowingCredentials(Table table)
        {
            var credentials = table.Rows[0];
            string username = credentials["Username"];
            string password = credentials["Password"];
            _loginPage.EnterCredentials(username, password);
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            _loginPage.BtnLogin.Click();
        }

        [Then(@"Waiting for spinner disappears")]
        public void ThenWaitingForSpinnerDisappears()
        {
            _loginPage.WaitForSpinner();
        }

        [Then(@"Course page displays")]
        public void ThenCoursePageDisplays()
        {
            _loginPage.IsCoursePageLoaded();
        }
    }
}
