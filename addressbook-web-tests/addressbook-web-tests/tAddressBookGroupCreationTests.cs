using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: BaseTest
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("GroupName " + DateTime.Now);
            group.GroupHeader = "GroupHeader " + DateTime.Now;
            group.GroupFooter = "GroupFooter " + DateTime.Now;
            FillGroupForm(group);
            Submit();
            GoToGroupsPage();
            Logout();
        }

 
             
    }
}
