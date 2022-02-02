using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupDeletionTests: TestBase
    {
        [Test]
        public void TestGroupDeletion()
        
            {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData GroupToDelete = new GroupData()
            {
                Id = "0"
            };
            app.Groups.Delete(GroupToDelete);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(oldGroups[0]);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }

}
