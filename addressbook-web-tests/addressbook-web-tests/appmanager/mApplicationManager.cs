using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

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
        private static ThreadLocal<mApplicationManager> app = new ThreadLocal<mApplicationManager>();

        private mApplicationManager()
            {
            driver = new FirefoxDriver();

            bloginHelper = new bLoginHelper(this);
            bnavigationHelper = new bNavigationHelper(this, baseURL);
            bgroupHelper = new bGroupHelper(this);
            baddressHelper = new bAddressHelper(this);
            
            verificationErrors = new StringBuilder();
        }
        ~mApplicationManager()
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
        public static mApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                mApplicationManager NewInstance = new mApplicationManager();
                NewInstance.Navigator.OpenHomePage();
                app.Value = NewInstance;
            }
            return app.Value;
        }
    }
}

