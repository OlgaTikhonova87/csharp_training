using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WebAddressbookTests
{ 
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<AddressData> oldList = group.GetContaracts();
            AddressData contact = AddressData.GetAll().Except(group.GetContaracts()).First();

            app.Address.AddContactToGroup(contact, group);

            List<AddressData> newList = group.GetContaracts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList,newList);
        }
        [Test]
        public void TestDeleteContactTFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<AddressData> oldList = group.GetContaracts();
            AddressData contact = AddressData.GetAll().Intersect(group.GetContaracts()).First();

            app.Address.DeleteContactFromGroup(contact, group);

            List<AddressData> newList = group.GetContaracts();
            newList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
