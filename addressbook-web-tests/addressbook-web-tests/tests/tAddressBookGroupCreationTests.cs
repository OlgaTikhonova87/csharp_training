using System;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("GroupName " + DateTime.Now);
            group.GroupHeader = "GroupHeader " + DateTime.Now;
            group.GroupFooter = "GroupFooter " + DateTime.Now;

            //app.Navigator.OpenHomePage();
            //app.Auth.Login(new AccountData("admin","secret"));
            app.Groups.Create(group);


        }
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.GroupHeader = "";
            group.GroupFooter = "";
            app.Groups.Create(group);
         

        }
    }
}
