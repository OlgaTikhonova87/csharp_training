using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class bGroupHelper : HelperBase
    {

        public bGroupHelper(mApplicationManager manager) : base(manager)
        {

        }
        //CREATION
        //public bGroupHelper InitCreation()
        //{
        //    driver.FindElement(By.LinkText("add new")).Click();
        //    return this;
        //}
     
        public bGroupHelper Create(GroupData groupdata)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(groupdata);
            Submit();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public bGroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        //MODIFY
        public bGroupHelper Modify(GroupData newData, int index)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.GoToGroupsPage();
            return this;
        }
        public bGroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public bGroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
 
        //REMOVE
        public bGroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            Removal();
            manager.Navigator.GoToGroupsPage();
            return this;
        }
        public bGroupHelper Removal()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        //ADDITIONAL
        public bGroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }
        public bGroupHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public bGroupHelper FillGroupForm(GroupData groupdata)
        {
            Type(By.Name("group_name"), groupdata.GroupName);
            Type(By.Name("group_header"), groupdata.GroupHeader);
            Type(By.Name("group_footer"), groupdata.GroupFooter);
            return this;
        }  
        public bool IsGroupExist(string groupname)
        {
            return driver.FindElement(By.XPath("//input[@name='selected[]']")).Text == groupname;
        }
        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
           ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }

            return groups;
        }
    }
}
