using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemove()
        {
            GroupData newData = new GroupData("GroupName");
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.Create(newData);
            }
            List<GroupData> oldGroups = GroupData.GetAll();
             GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);
            //Assert.AreEqual(oldGroups, newGroups);
            //foreach (GroupData group in newGroups)
            //{
            //    Assert.AreNotEqual(group.ID, toBeRemoved.ID);
            //}
        } 
    }
}
