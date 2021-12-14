using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class mApplicationManager
    {
        protected string baseURL;
        protected IWebDriver driver;
        private StringBuilder verificationErrors;

        protected bLoginHelper bloginHelper;
        protected bNavigationHelper bnavigationHelper;
        protected bGroupHelper bgroupHelper;
        protected bAddressHelper baddressHelper;

        public mApplicationManager()
            {
             bloginHelper = new bLoginHelper(driver);
             bnavigationHelper = new bNavigationHelper(driver, baseURL);
             bgroupHelper = new bGroupHelper(driver);
            baddressHelper = new bAddressHelper(driver);
            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
        }
        public bLoginHelper Auth
        {
            get
            {
                return bloginHelper;
            }
        }
        public bNavigationHelper Navigator
        {
            get
            {
                return bnavigationHelper;
            }
        }

        public bGroupHelper Groups
        {
            get
            {
                return bgroupHelper;
            }
        }
        public bAddressHelper Address
        {
            get
            {
                return baddressHelper;
            }
        }
        

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}

