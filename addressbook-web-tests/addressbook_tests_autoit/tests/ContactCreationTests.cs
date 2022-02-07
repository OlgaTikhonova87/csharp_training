using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class ContactCreationTests: TestBase
    {
        [Test]
        public void TestContactCreation()
        
            {
            List<ContactData> oldGroups = app.Contacts.GetContactList();
            //GroupData newGroup = new GroupData()
            //{
            //    Name = "test"
            //};
            //app.Groups.Add(newGroup);
            //List<GroupData> newGroups = app.Groups.GetGroupList();
            //oldGroups.Add(newGroup);
            //oldGroups.Sort();
            //newGroups.Sort();
            //Assert.AreEqual(oldGroups, newGroups);
        }

    }

}
