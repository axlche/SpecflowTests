using System;
using HomeworkSpecFlow.Drivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace HomeworkSpecFlow.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        IWebDriver driver;
        WebDriverWait wait;

        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [DataRow("chrome")]
        [DataRow("firefox")]
        [Given(@"Open page with login form")]
        public void GivenPageWithLoginForm()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup("firefox");

            driver.Url = "https://viktor-silakov.github.io/course-sut/";
            wait = new(driver, TimeSpan.FromSeconds(40));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login")));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("password")));
        }

        [When(@"I enter ""(.*)"" and ""(.*)""")]
        public void WhenIEnterAnd(string username, string password)
        {
            driver.FindElement(By.Id("login")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            driver.FindElement(By.CssSelector(".btn-primary.rounded-2")).Click();
        }

        [Then(@"Spinner appears")]
        public void ThenSpinnerAppears()
        {
            /*WebDriverWait*/ wait = new (driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("spinner")));
        }

        [When(@"Spinner disappeared")]
        public void WhenSpinnerDisappeared()
        {
            /*WebDriverWait*/ wait = new (driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner")));
        }

        [Then(@"Course page displays")]
        public void ThenCoursePageDisplays()
        {
            /*WebDriverWait*/ wait = new(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.Id("first-nav-block")));
        }
    }
}
