using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemove()
        {
            GroupData newData = new GroupData("GroupName");
            if (!app.Groups.IsGroupExist(newData.groupname))
            {
                app.Groups.Create(newData);
            }
            app.Groups.Remove();
        } 
    }
}
