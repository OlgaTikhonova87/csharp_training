using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class BaseTest
    {
        public IWebDriver driver { get; set; }
        public StringBuilder verificationErrors;
        public string baseURL { get; set; }

        public BaseTest(string url)
        {
            baseURL = url;
        }
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            //baseURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();
        }
        /// <summary>
        /// Открывает домашнюю страницу
        /// </summary>
        public void OpenHomePage()
        {
            //Open home page
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
