using OpenQA.Selenium;
namespace WebAddressbookTests
{
    public class bNavigationHelper : HelperBase
    {
            private string baseURL;

            public bNavigationHelper(mApplicationManager manager, string baseURL): base(manager)
            {
                this.baseURL = baseURL;
            }
            public void OpenHomePage()
            {
            //Open home page
            if (driver.Url == baseURL + "/addressbook/"
            && IsElementPresent(By.Name("new")))
                {
                    return;
                }
                driver.Navigate().GoToUrl(baseURL + "/addressbook");
            }
            public void GoToGroupsPage()
            {
            
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
             driver.FindElement(By.LinkText("groups")).Click(); ;
            }
            
    }
}
