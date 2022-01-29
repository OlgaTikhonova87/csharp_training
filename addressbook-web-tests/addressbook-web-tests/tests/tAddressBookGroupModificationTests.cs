using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
   public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModification()
        {
            //GroupData oldData = new GroupData("OldGroupName");
            //GroupData group = new GroupData("Group_1");
            GroupData newData = new GroupData("ChangedGroupName");
            newData.GroupHeader = "header is changed";
            newData.GroupFooter = "footer is changed";

            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.Create(newData);
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeEdit = oldGroups[0];
            app.Groups.Modify(newData, toBeEdit);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());


            //List<GroupData> newGroups = GroupData.GetAll();
            //oldGroups[0].GroupName = newData.GroupName;
            //oldGroups.Sort();
            //newGroups.Sort();
         ////   Assert.AreEqual(oldGroups, newGroups);
         //   foreach (GroupData gr in newGroups)
         //   {
         //       if (gr.ID == toBeRemoved.ID)
         //       {
         //           Assert.AreEqual(newData.GroupName, gr.GroupName);
         //       }
         //   }

        }
    }
}
