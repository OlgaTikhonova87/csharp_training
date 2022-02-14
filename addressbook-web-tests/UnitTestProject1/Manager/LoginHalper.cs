using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHalper : HelperBase
    {
        public LoginHalper(ApplicationManager manager) : base (manager) { }

        public void Login()
        {
            AccountData account = new AccountData 
            {
                Name = "administrator",
                Password = "root"
            };

            OpenMainPge();
            FillUsername(account.Name);
            ClickLogin();
            FillPassword(account.Password);
            ClickLogin();
        }
        private void ClickLogin()
        {
            driver.FindElement(By.XPath("//input[@type= 'submit']")).Click();
        }
        private void FillUsername(string username)
        {
            driver.FindElement(By.Name("username")).SendKeys(username);
        }
        private void FillPassword(string password)
        {
            driver.FindElement(By.Name("password")).SendKeys(password);
        }
        private void OpenMainPge()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php";
        }
        public void Logout()
        {
                driver.FindElement(By.ClassName("user-info")).Click();
                driver.FindElement(By.CssSelector("#navbar-container > div.navbar-buttons.navbar-header.navbar-collapse.collapse > ul > li.grey.open > ul > li:nth-child(4) > a")).Click();
        }
    }
}
