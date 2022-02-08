using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;


namespace mantis_tests

{
    public class mApplicationManager
    {
        protected string baseURL = "http://localhost";
        
        protected IWebDriver driver;
        private StringBuilder verificationErrors;


        private static ThreadLocal<mApplicationManager> app = new ThreadLocal<mApplicationManager>();

        private mApplicationManager()
        {

            driver = new FirefoxDriver();

            Registration = new RegistrationHalper(this);
            verificationErrors = new StringBuilder();
            Ftp = new FTPHelper(this);
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
                NewInstance.Driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php";
                app.Value = NewInstance;
            }
            return app.Value;
        }

        public RegistrationHalper Registration { get; set; }

        public FTPHelper Ftp  { get; set; }

    }
}

