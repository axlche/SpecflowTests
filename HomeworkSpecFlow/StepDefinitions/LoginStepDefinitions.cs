using System;
using HomeworkSpecFlow.Drivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HomeworkSpecFlow.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions //: BaseTest
    {
        private LoginPage _loginPage;
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
