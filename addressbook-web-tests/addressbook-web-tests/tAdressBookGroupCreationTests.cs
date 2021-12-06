using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
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

        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("GroupName " + DateTime.Now);
            group.GroupHeader = "GroupHeader " + DateTime.Now;
            group.GroupFooter = "GroupFooter " + DateTime.Now;
            FillGroupForm(group);
            Submit();
            GoToGroupsPage();
            Logout();
        }

        private void InitGroupCreation()
        {
            //Init New group creation
            driver.FindElement(By.Name("new")).Click();
        }

        private void Logout()
        {
            //Logout
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void Submit()
        {
            //Submit
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm(GroupData groupdata)
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

        private void GoToGroupsPage()
        {
            //Go to groups Page
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Login(AccountData account)
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

        private void OpenHomePage()
        {
            //Open home page
            driver.Navigate().GoToUrl(baseURL);
        }

        private bool IsElementPresent(By by)
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

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
