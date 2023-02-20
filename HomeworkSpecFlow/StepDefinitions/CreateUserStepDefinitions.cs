using System;
using HomeworkSpecFlow.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace HomeworkSpecFlow.StepDefinitions
{
    [Binding]
    public class CreateUserStepDefinitions
    {
        IWebDriver driver;
        WebDriverWait wait;

        private readonly ScenarioContext _scenarioContext;

        public CreateUserStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I login to a course page")]
        public void GivenILoginWithAndToACoursePage()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup("firefox");
            driver.Url = "https://viktor-silakov.github.io/course-sut/";
            wait = new(driver, TimeSpan.FromSeconds(10));

            driver.FindElement(By.Id("login")).SendKeys("walker@jw.com");
            driver.FindElement(By.Id("password")).SendKeys("password");
            driver.FindElement(By.CssSelector(".btn-primary.rounded-2")).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("spinner")));

        }

        [When(@"I click Create User left menu item")]
        public void WhenIClickCreateUserLeftMenuItem()
        {
            driver.FindElement(By.XPath("//a[normalize-space()='Create User']")).Click();
        }

        [Then(@"Page with create user form opens")]
        public void ThenPageWithCreateUserFormOpens()
        {
            wait = new(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("form[onsubmit='event.preventDefault();']")));

        }

        //[When(@"I enter ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", and ""(.*)""")]
        [When(@"I enter ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)""> and ""([^""]*)""")]
        public void WhenIEnterAnd(string email, string password, string address1, string address2, string city, string zip, string annualPayment, string description)
        {

            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("address1")).SendKeys(address1);
            driver.FindElement(By.Id("address2")).SendKeys(address2);
            driver.FindElement(By.Id("city")).SendKeys(city);
            driver.FindElement(By.Id("zip")).SendKeys(zip);
            driver.FindElement(By.Id("anual")).SendKeys(annualPayment);
            driver.FindElement(By.Id("description")).SendKeys(description);
        }

        [When(@"I click Create button")]
        public void WhenIClickCreateButton()
        {
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }

        [Then(@"List of Users page with table opens")]
        public void ThenListOfUsersPageWithTableOpens()
        {
            wait = new(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("users-table")));
        }

        //[Then(@"New user with ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", and ""(.*)"" added to the table")]
        [Then(@"New user with ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" and ""([^""]*)""> added to the table")]
        public void ThenNewUserWithAndAddedToTheTable(string email, string address1, string address2, string city, string zip, string description, string annualPayment)
        {
            var rows = driver.FindElements(By.CssSelector(".tabulator-row"));
            var rowsCount = rows.Count();
            Assert.AreEqual(email, driver.FindElement(By.CssSelector($".tabulator-row:nth-child({rowsCount}) .tabulator-cell:nth-child(1)")).Text, "Email are not equal");
            Assert.AreEqual(address1, driver.FindElement(By.CssSelector($".tabulator-row:nth-child({rowsCount}) .tabulator-cell:nth-child(3)")).Text, "Address1 are not equal");
            Assert.AreEqual(address2, driver.FindElement(By.CssSelector($".tabulator-row:nth-child({rowsCount}) .tabulator-cell:nth-child(4)")).Text, "Address2 are not equal");
            Assert.AreEqual(city, driver.FindElement(By.CssSelector($".tabulator-row:nth-child({rowsCount}) .tabulator-cell:nth-child(5)")).Text, "City are not equal");
            Assert.AreEqual(zip, driver.FindElement(By.CssSelector($".tabulator-row:nth-child({rowsCount}) .tabulator-cell:nth-child(7)")).Text, "Zip are not equal");
            Assert.AreEqual(description, driver.FindElement(By.CssSelector($".tabulator-row:nth-child({rowsCount}) .tabulator-cell:nth-child(8)")).Text, "Description are not equal");
            Assert.AreEqual(annualPayment, driver.FindElement(By.CssSelector($".tabulator-row:nth-child({rowsCount}) .tabulator-cell:nth-child(10)")).Text, "Annual are not equal");


            //var newRowWithUser = driver.FindElement(By.CssSelector($".tabulator-row:nth-child({rows.Count})"));
            //IList<IWebElement> cells = newRowWithUser.FindElements(By.CssSelector("tabulator-cell"));
            //foreach (IWebElement cell in cells)
            //{
            //    if (cell.GetAttribute("tabulator-field") == "email")
            //    {
            //        cell.Text = email;
            //    }
            //}


        }
    }
    
    //public void WhenIEnterAnd(string p0, string p1, string p2, string p3, string newCity, string p5, string p6, string p7)
    //{
    //    throw new PendingStepException();
    //}

    ////[Then(@"New user with ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" and ""([^""]*)""> added to the table")]
    //public void ThenNewUserWithAndAddedToTheTable(string p0, string p1, string p2, string newCity, string p4, string p5, string p6)
    //{
    //    throw new PendingStepException();
    //}



}
