using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
   public class tGroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModification()
        {
            GroupData oldData = new GroupData("OldGroupName");

            GroupData newData = new GroupData("ChangedGroupName");
            newData.GroupHeader = "header is changed";
            newData.GroupFooter = "footer is changed";

            if (!app.Groups.IsGroupExist(newData.groupname))
            {
                app.Groups.Create(newData);
            }
            app.Groups.Modify(newData);
        }
    }
}
