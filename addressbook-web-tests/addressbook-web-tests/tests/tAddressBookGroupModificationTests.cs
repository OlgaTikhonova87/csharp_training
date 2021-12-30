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

            app.Groups.Modify(newData, oldData);
        }
    }
}
