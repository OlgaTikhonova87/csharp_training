using System;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: bBaseTest
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitGroupCreation();
            GroupData group = new GroupData("GroupName " + DateTime.Now);
            group.GroupHeader = "GroupHeader " + DateTime.Now;
            group.GroupFooter = "GroupFooter " + DateTime.Now;
            app.Groups.FillGroupForm(group);
            app.Groups.Submit();
            app.Navigator.GoToGroupsPage();
            app.Auth.Logout();
        }        
    }
}
