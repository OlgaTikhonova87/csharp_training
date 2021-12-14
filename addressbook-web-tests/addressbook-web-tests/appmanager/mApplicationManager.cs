using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class mApplicationManager
    {
        protected string baseURL = "http://localhost";
        protected IWebDriver driver;
        private StringBuilder verificationErrors;

        protected bLoginHelper bloginHelper;
        protected bNavigationHelper bnavigationHelper;
        protected bGroupHelper bgroupHelper;
        protected bAddressHelper baddressHelper;
        

        public mApplicationManager()
            {
            driver = new FirefoxDriver();

            bloginHelper = new bLoginHelper(this);
            bnavigationHelper = new bNavigationHelper(this, baseURL);
            bgroupHelper = new bGroupHelper(this);
            baddressHelper = new bAddressHelper(this);
            
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

        public IWebDriver Driver 
        {
            get 
            {
                return driver;
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

