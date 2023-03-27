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
    public class SeleniumDriver : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public SeleniumDriver()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
