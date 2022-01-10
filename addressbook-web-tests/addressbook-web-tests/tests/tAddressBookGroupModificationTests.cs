using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
   public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModification()
        {
            GroupData oldData = new GroupData("OldGroupName");
            GroupData group = new GroupData("Group_1");
            GroupData newData = new GroupData("ChangedGroupName");
            newData.GroupHeader = "header is changed";
            newData.GroupFooter = "footer is changed";

            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.Create(newData);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(newData,0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].GroupName = newData.GroupName;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}
