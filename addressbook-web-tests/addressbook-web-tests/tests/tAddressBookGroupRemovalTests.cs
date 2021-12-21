using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : bBaseTest
    {
        [Test]
        public void GroupRemove()
        {
            app.Groups.Remove(1);
        } 
    }
}
