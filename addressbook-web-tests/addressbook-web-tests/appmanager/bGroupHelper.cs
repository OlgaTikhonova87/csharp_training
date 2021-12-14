using OpenQA.Selenium;
using System;

namespace WebAddressbookTests
{
    public class bGroupHelper : HelperBase
    {

        public bGroupHelper(mApplicationManager manager) : base(manager)
        {

        }
        public bGroupHelper Removal()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public bGroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            Removal();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public bGroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }
        public bGroupHelper InitGroupCreation()
        {
            //Init New group creation
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public bGroupHelper Submit()
        {
            //Submit
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public bGroupHelper FillGroupForm(GroupData groupdata)
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
            return this;
        }

        public bGroupHelper Create(GroupData groupdata)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(groupdata);
            Submit();
            manager.Navigator.GoToGroupsPage();
            return this;
        }
        public bGroupHelper InitCreation()
        {
            //Init New creation
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}
