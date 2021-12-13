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
        protected string baseURL;
        private bool acceptNextAlert = true;
        protected IWebDriver driver;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
        }
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        protected void Logout()
        {
            //Logout
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        protected void GoToGroupsPage()
        {
            //Go to groups Page
            driver.FindElement(By.LinkText("groups")).Click();
        }
        protected void Login(AccountData account)
        {
            //Login
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        protected void OpenHomePage()
        {
            //Open home page
            driver.Navigate().GoToUrl(baseURL + "/addressbook");
        }
        protected void Removal()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
        protected void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }
        protected void InitGroupCreation()
        {
            //Init New group creation
            driver.FindElement(By.Name("new")).Click();
        }

        protected void Submit()
        {
            //Submit
            driver.FindElement(By.Name("submit")).Click();
        }

        protected void FillGroupForm(GroupData groupdata)
        {
            //Fill group form
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form/label")).Click();
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(groupdata.GroupName);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(groupdata.GroupHeader);
            driver.FindElement(By.XPath("//div[@id='content']/form/label[3]")).Click();
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(groupdata.GroupFooter);
        }
        protected void InitCreation()
        {
            //Init New creation
            driver.FindElement(By.LinkText("add new")).Click();
        }
     }
}
