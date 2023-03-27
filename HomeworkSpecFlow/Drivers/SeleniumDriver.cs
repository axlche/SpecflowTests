using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
