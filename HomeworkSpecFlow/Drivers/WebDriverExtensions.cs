using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkSpecFlow.Drivers
{
    public static class WebDriverExtensions
    {
        public static void WaitForElementToBeClickable(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static void WaitForElementToBeVisible(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static void WaitForElementToBeInvisible(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public static void WaitForElementToExist(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementExists(by));
        }
    }
}
