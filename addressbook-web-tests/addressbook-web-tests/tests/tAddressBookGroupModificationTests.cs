using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
   public class tGroupModificationTests : bBaseTest
    {
        [Test]
        public void GroupModification()
        {
            GroupData newData = new GroupData("GroupName");
            newData.GroupHeader = "header";
            newData.GroupFooter = "footer";
            app.Groups.Modify(7, newData);
        }
    }
}
