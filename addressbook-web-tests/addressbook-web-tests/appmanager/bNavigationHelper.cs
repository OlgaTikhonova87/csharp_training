using OpenQA.Selenium;
namespace WebAddressbookTests
{
    public class bNavigationHelper : HelperBase
    {
            private string baseURL;

            public bNavigationHelper(IWebDriver driver, string baseURL): base(driver)
            {
                this.baseURL = baseURL;
            }
            public void OpenHomePage()
            {
                //Open home page
                driver.Navigate().GoToUrl(baseURL + "/addressbook");
            }
            public void GoToGroupsPage()
            {
            //Open home page
             driver.FindElement(By.LinkText("groups")).Click(); ;
            }
            
    }
}
