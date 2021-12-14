using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class bGroupHelper : HelperBase
    {

        public bGroupHelper(IWebDriver driver) : base(driver)
        {

        }
        public void Removal()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }
        public void InitGroupCreation()
        {
            //Init New group creation
            driver.FindElement(By.Name("new")).Click();
        }

        public void Submit()
        {
            //Submit
            driver.FindElement(By.Name("submit")).Click();
        }

        public void FillGroupForm(GroupData groupdata)
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
        public void InitCreation()
        {
            //Init New creation
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
