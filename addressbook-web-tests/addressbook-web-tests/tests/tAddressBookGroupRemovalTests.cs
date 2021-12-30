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
            app.Groups.Remove(newData);
        } 
    }
}
