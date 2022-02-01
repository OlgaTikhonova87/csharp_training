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
        public bGroupHelper Modify(GroupData newData, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(group.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.GoToGroupsPage();
            return this;
        }
        public int GetGroupCount()
        {
           return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public bGroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public bGroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
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
        public bGroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            Removal();
            manager.Navigator.GoToGroupsPage();
            return this;
        }
        public bGroupHelper Removal()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        //ADDITIONAL
        public bGroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.Name("selected[]")).Click();

            return this;
        }
        public bGroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value= '" +id+"'])")).Click();

            return this;
        }
        public bGroupHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
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
        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {

            if (groupCache == null)
            {
                groupCache = new List<GroupData>();

                List<GroupData> groups = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {

                    groupCache.Add(new GroupData(element.Text) { Id = element.FindElement(By.TagName("input")).GetAttribute("value") });
                }
            }

            return new List < GroupData >(groupCache);
        }
    }
}
