using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace HomeworkSpecFlow.Drivers
{
    public class SeleniumDriver
    {
        public enum Browser
        {
            Chrome,
            Firefox
        }

        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        //[DataRow("chrome")]
        //[DataRow("firefox")]
        public IWebDriver Setup(string browserName)
        {
            driver = GetBrowserOption(browserName);

            _scenarioContext.Set(driver, "WebDriver");

            driver.Manage().Window.Maximize();

            return driver;
        }

        private dynamic GetBrowserOption(string browserName)
        {
            if (browserName == "chrome")
                return new ChromeDriver();
            if (browserName == "firefox")
                return new FirefoxDriver();

            return null;
        }
    }
}
