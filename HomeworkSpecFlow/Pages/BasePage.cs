using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkSpecFlow
{
    public class BasePage
    {
        protected IWebDriver Driver { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        public IWebElement FindElement(By by)
        {
            return Driver.FindElement(by);
        }
        public IList<IWebElement> FindElements(By by)
        {
            return Driver.FindElements(by);
        }
    }
}
