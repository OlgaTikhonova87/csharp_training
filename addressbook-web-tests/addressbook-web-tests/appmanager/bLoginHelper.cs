using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class bLoginHelper : HelperBase
    {
        public bLoginHelper(IWebDriver driver) : base(driver)
        {

        }
        public void Logout()
        {
            //Logout
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        public void Login(AccountData account)
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
    }
}
