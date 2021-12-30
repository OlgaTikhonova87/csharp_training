using OpenQA.Selenium;
using System;

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
        public bGroupHelper Modify(GroupData newData, GroupData oldData)
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsGroupExist(oldData.groupname) )
            {
                Create(oldData);
            }

            SelectGroup(oldData.groupname);
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
        public bGroupHelper Remove(GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsGroupExist(newData.groupname) )
            {
                Create(newData);
            }

            SelectGroup(newData.groupname);
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
        public bGroupHelper SelectGroup(string groupname)
        {
            // поменять на по имени как-то? Тут возник вопрос (надо спросить).
            // Могу я как-то из всего многообразия перебрать все группы и найти
            // с нужным названием или пока оставляем так? Или вообще как оно работает...
            driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
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

            //div[@id='content']/form/span"
        }
    }
}
