//using System;
//using System.Text.RegularExpressions;
//using OpenQA.Selenium;

//namespace mantis_tests
//{
//    public class RegistrationHalper : HelperBase
//    {
//        public RegistrationHalper(mApplicationManager manager) : base (manager) { }

//        public void Register(AccountData account)
//        {
//            OpenMainPge();
//            OpenRegistrationForm();
//            FillRegistrationForm(account);
//            SubmitRegistration();
//            //String url = GetConfirmationUrl(account);
//            //FillPasswordForm(url);
//            //SubmitPasswordForm();

//        }

//        private void SubmitPasswordForm()
//        {
//            throw new NotImplementedException();
//        }

//        private void FillPasswordForm(string url)
//        {
//            throw new NotImplementedException();
//        }

//        private string GetConfirmationUrl(AccountData account)
//        {
//            String message = manager.Mail.GetLastMail(account);
//            Match match = Regex.Match(message, @"http://\S*");
//            return match.Value;
//        }

//        private void OpenRegistrationForm()
//        {
//            driver.FindElement(By.CssSelector("#login-box > div > div.toolbar.center > a")).Click();
//        }

//        private void SubmitRegistration()
//        {
//            driver.FindElement(By.CssSelector("#signup-form > fieldset > input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110")).Click();
//        }

//        private void FillRegistrationForm(AccountData account)
//        {
//            driver.FindElement(By.Name("username")).SendKeys(account.Name);
//            driver.FindElement(By.Name("email")).SendKeys(account.Email);
//        }

//        private void OpenMainPge()
//        {
//            manager.Driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php";
//        }
//    }
//}
