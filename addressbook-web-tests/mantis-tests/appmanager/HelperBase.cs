using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests

{
    public class HelperBase
    {
        protected mApplicationManager manager;
        protected IWebDriver driver;

        public HelperBase(mApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
    
}