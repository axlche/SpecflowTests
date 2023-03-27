using HomeworkSpecFlow.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HomeworkSpecFlow.StepDefinitions
{
    [Binding]
    public class CreateUserStepDefinitions
    {
        private readonly LoginPage _loginPage;
        private readonly CreateUserPage _createUserPage;
        private readonly ListOfUsersPage _listOfUsersPage;
        private readonly LoginStepDefinitions _loginSteps;

        public CreateUserStepDefinitions(SeleniumDriver seleniumDriver, LoginStepDefinitions loginSteps)
        {
            _loginPage = new LoginPage(seleniumDriver.Driver);
            _createUserPage = new CreateUserPage(seleniumDriver.Driver);
            _listOfUsersPage = new ListOfUsersPage(seleniumDriver.Driver);
            _loginSteps = loginSteps;
        }

        [StepArgumentTransformation]
        public User TransformUser(Table table)
        {
            return table.CreateInstance<User>();
        }

        [Given(@"I login to a course page")]
        public void GivenILoginToACoursePage()
        {
            _loginSteps.GivenPageWithLoginForm();
            var table = new Table(new string[] { "Username", "Password" });
            table.AddRow("walker@jw.com", "password");
            _loginSteps.WhenIEnterTheFollowingCredentials(table);
            _loginSteps.WhenIClickLoginButton();
            _loginSteps.ThenWaitingForSpinnerDisappears();
            _loginSteps.ThenCoursePageDisplays();
        }

        [When(@"I click Create User left menu item")]
        public void WhenIClickCreateUserLeftMenuItem()
        {
            _loginPage.CreateUserMenuItem.Click();
        }

        [Then(@"Page with create user form opens")]
        public void ThenPageWithCreateUserFormOpens()
        {
            _createUserPage.IsCreateUserFormDisplayed();
        }

        [When(@"I enter user information")]
        public void WhenIEnterUserDetails(User user)
        {
            _createUserPage.EnterUserDetails(user);
        }

        [When(@"I click Create button")]
        public void WhenIClickCreateButton()
        {
            _createUserPage.ButtonSubmit.Click();
        }

        [Then(@"List of Users page with table opens")]
        public void ThenListOfUsersPageWithTableOpens()
        {
            _listOfUsersPage.IsListOfUsersTableDisplayed();
        }

        [Then(@"New user is added to the table")]
        public void ThenNewUserIsAddedToTheTable(User user)
        {
            _listOfUsersPage.VerifyCreatedUser(user);
        }
        
    }
}
