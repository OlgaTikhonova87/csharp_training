using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : bBaseTest
    {
        [Test]
        public void GroupRemovOpenHomePage()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroup(1);
            app.Groups.Removal();
            app.Navigator.GoToGroupsPage();
            app.Auth.Logout();
        } 
    }
}
