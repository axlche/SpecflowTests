using HomeworkSpecFlow.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkSpecFlow
{
    public class ListOfUsersPage : BasePage
    {
        private IList<IWebElement> Rows => FindElements(By.CssSelector(".tabulator-row"));
        private IWebElement EmailField(int row) => FindElement(By.CssSelector($".tabulator-row:nth-child({row}) .tabulator-cell:nth-child(1)"));
        private IWebElement Address1(int row) => FindElement(By.CssSelector($".tabulator-row:nth-child({row}) .tabulator-cell:nth-child(3)"));
        private IWebElement Address2(int row) => FindElement(By.CssSelector($".tabulator-row:nth-child({row}) .tabulator-cell:nth-child(4)"));
        private IWebElement City(int row) => FindElement(By.CssSelector($".tabulator-row:nth-child({row}) .tabulator-cell:nth-child(5)"));
        private IWebElement Zip(int row) => FindElement(By.CssSelector($".tabulator-row:nth-child({row}) .tabulator-cell:nth-child(7)"));
        private IWebElement Description(int row) => Driver.FindElement(By.CssSelector($".tabulator-row:nth-child({row}) .tabulator-cell:nth-child(8)"));
        private IWebElement AnnualPayment(int row) => FindElement(By.CssSelector($".tabulator-row:nth-child({row}) .tabulator-cell:nth-child(10)"));

        public ListOfUsersPage(IWebDriver driver) : base(driver)
        {
        }

        public void VerifyCreatedUser(User user)
        {
            Driver.WaitForElementToBeVisible(By.Id("users-table"));
            var rowsCount = Rows.Count();
            Assert.AreEqual(user.Email, EmailField(rowsCount).Text, "Emails are not equal");
            Assert.AreEqual(user.Address1, Address1(rowsCount).Text, "Address1 values are not equal");
            Assert.AreEqual(user.Address2, Address2(rowsCount).Text, "Address2 values are not equal");
            Assert.AreEqual(user.City, City(rowsCount).Text, "City values are not equal");
            Assert.AreEqual(user.Zip, Zip(rowsCount).Text, "Zip values are not equal");
            Assert.AreEqual(user.Description, Description(rowsCount).Text, "Descriptions are not equal");
            Assert.AreEqual(user.AnnualPayment, AnnualPayment(rowsCount).Text, "Annual payments are not equal");
        }

        public void IsListOfUsersTableDisplayed()
        {
            Driver.WaitForElementToBeVisible(By.Id("users-table"));
        }
    }
}
