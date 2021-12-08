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
        public class AddressBookAdressCreationTests
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
            public void AddressCreationTest()
                {
           
                    OpenHomePage();
                Login(new AccountData("admin", "secret"));
                InitCreation();

                AddressData address = new AddressData("First Name " + DateTime.Now)
                {
                    MiddleName = "MiddleName " + DateTime.Now,
                    LastName = "lastname " + DateTime.Now,
                    NickName = "nickname " + DateTime.Now,
                    Title = "Title " + DateTime.Now,
                    Company = "Company " + DateTime.Now,
                    Address = "Address " + DateTime.Now,
                    HomePhone = "4556789",
                    MobilePhone = "3223232",
                    WorkPhone = "7686788",
                    Fax = "5467657",
                    Mail1 = "Mail1 " + DateTime.Now,
                    Mail2 = "Mail2 " + DateTime.Now,
                    Mail3 = "Mail3 " + DateTime.Now,
                    HomePage = "HomePage " + DateTime.Now,
                    Address2 = "address2 " + DateTime.Now,
                    Phone2 = "phone2 " + DateTime.Now,
                    Notes = "notes " + DateTime.Now,
                    BDay = DateTime.Now.Day.ToString(),
                    BMonth = "April",
                    BYear = (DateTime.Now.Year - 30).ToString(),
                    ADay = DateTime.Now.Day.ToString(),
                    AMonth = "May",
                    AYear = (DateTime.Now.Year - 1).ToString(),
                    Group = "GroupName 03.12.2021 18:06:39",
                    Photo = "C:\\fakepath\\95384925.jpg"
                };

                FillAddressForm(address);

            
                Submit();
                Logout();
            
         
           
                Assert.AreEqual("", verificationErrors.ToString());
            }
            private void FillAddressForm(AddressData address)
            {
            //Fill address form
            //try
            //{
                    driver.FindElement(By.Name("firstname")).Click();
                    driver.FindElement(By.Name("firstname")).Click();
                    driver.FindElement(By.Name("firstname")).Clear();
                    driver.FindElement(By.Name("firstname")).SendKeys(address.firstname);
                    driver.FindElement(By.Name("middlename")).Click();
                    driver.FindElement(By.Name("middlename")).Clear();
                    driver.FindElement(By.Name("middlename")).SendKeys(address.middlename);
                    driver.FindElement(By.Name("lastname")).Click();
                    driver.FindElement(By.Name("lastname")).Clear();
                    driver.FindElement(By.Name("lastname")).SendKeys(address.lastname);
                    driver.FindElement(By.Name("nickname")).Click();
                    driver.FindElement(By.Name("nickname")).Clear();
                    driver.FindElement(By.Name("nickname")).SendKeys(address.nickname);

                    driver.FindElement(By.Name("title")).Click();
                    driver.FindElement(By.Name("title")).Clear();
                    driver.FindElement(By.Name("title")).SendKeys(address.title);
                    driver.FindElement(By.Name("company")).Click();
                    driver.FindElement(By.Name("company")).Clear();
                    driver.FindElement(By.Name("company")).SendKeys(address.company);
                    driver.FindElement(By.Name("address")).Click();
                    driver.FindElement(By.Name("address")).Clear();
                    driver.FindElement(By.Name("address")).SendKeys(address.address);

                    driver.FindElement(By.Name("home")).Click();
                    driver.FindElement(By.Name("home")).Clear();
                    driver.FindElement(By.Name("home")).SendKeys(address.homephone);
                    driver.FindElement(By.Name("mobile")).Click();
                    driver.FindElement(By.Name("mobile")).Clear();
                    driver.FindElement(By.Name("mobile")).SendKeys(address.mobilephone);
                    driver.FindElement(By.Name("work")).Click();
                    driver.FindElement(By.Name("work")).Clear();
                    driver.FindElement(By.Name("work")).SendKeys(address.workphone);
                    driver.FindElement(By.Name("fax")).Click();
                    driver.FindElement(By.Name("fax")).Clear();
                    driver.FindElement(By.Name("fax")).SendKeys(address.fax);

                    driver.FindElement(By.Name("email")).Click();
                    driver.FindElement(By.Name("email")).Clear();
                    driver.FindElement(By.Name("email")).SendKeys(address.mail1);
                    driver.FindElement(By.Name("email2")).Click();
                    driver.FindElement(By.Name("email2")).Clear();
                    driver.FindElement(By.Name("email2")).SendKeys(address.mail2);
                    driver.FindElement(By.Name("email3")).Click();
                    driver.FindElement(By.Name("email3")).Clear();
                    driver.FindElement(By.Name("email3")).SendKeys(address.mail3);

                    driver.FindElement(By.Name("homepage")).Click();
                    driver.FindElement(By.Name("homepage")).Clear();
                    driver.FindElement(By.Name("homepage")).SendKeys(address.homepage);
                    driver.FindElement(By.Name("address2")).Click();
                    driver.FindElement(By.Name("address2")).Clear();
                    driver.FindElement(By.Name("address2")).SendKeys(address.address2);
                    driver.FindElement(By.Name("phone2")).Click();
                    driver.FindElement(By.Name("phone2")).Clear();
                    driver.FindElement(By.Name("phone2")).SendKeys(address.phone2);
                    driver.FindElement(By.Name("notes")).Click();
                    driver.FindElement(By.Name("notes")).Clear();
                    driver.FindElement(By.Name("notes")).SendKeys(address.notes);

                    driver.FindElement(By.Name("bday")).Click();
                    new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(address.bday);
                    driver.FindElement(By.Name("bmonth")).Click();
                    new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(address.bmonth);
                    driver.FindElement(By.Name("byear")).Click();
                    driver.FindElement(By.Name("byear")).Clear();
                    driver.FindElement(By.Name("byear")).SendKeys(address.byear);

                    driver.FindElement(By.Name("aday")).Click();
                    new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(address.aday);
                    driver.FindElement(By.Name("amonth")).Click();
                    new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(address.amonth);
                    driver.FindElement(By.Name("ayear")).Click();
                    driver.FindElement(By.Name("ayear")).Clear();
                    driver.FindElement(By.Name("ayear")).SendKeys(address.ayear);

                    driver.FindElement(By.Name("new_group")).Click();
                    //new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(address.group);
                    //driver.FindElement(By.XPath("/html/body/div/div[4]/form/input[7]")).Click();
                    //driver.FindElement(By.XPath("/html/body/div/div[4]/form/input[7]").SendKeys("C:\\fakepath\\95384925.jpg");

            //}
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //    }
        }
            public void InitCreation()
            {
                //Init New creation
                driver.FindElement(By.LinkText("add new")).Click();
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
            private void Logout()
            {
                //Logout
                driver.FindElement(By.LinkText("Logout")).Click();
            }

            private void Submit()
            {
                //Submit
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            }
            public void OpenHomePage()
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

