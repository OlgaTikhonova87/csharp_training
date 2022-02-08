using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System;

namespace WebAddressbookTests
{ 
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> groups = GroupData.GetAll();
            if (groups.Count == 0)
            {
                GroupData newgroup = new GroupData("newgroup");
                app.Groups.Create(newgroup);
            }
             GroupData group = GroupData.GetAll()[0];


            List<AddressData> oldList = AddressData.GetAll();
            AddressData nullcontact = oldList.Except(group.GetContaracts()).FirstOrDefault();
            if (nullcontact == null)
            {
                AddressData newaddress = new AddressData("firstname" + DateTime.Now, "lastname")
                { Group = "[none]"};
                app.Address.CreateAddress(newaddress);
                oldList.Add(newaddress);
            }
            AddressData contact = AddressData.GetAll().Except(group.GetContaracts()).First();

            app.Address.AddContactToGroup(contact, group);

            List<AddressData> newList = group.GetContaracts();

            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList,newList);
        }
        [Test]
        public void TestDeleteContactTFromGroup()
        {

            List<GroupData> groups = GroupData.GetAll();
            if (groups.Count == 0)
            {
                GroupData newgroup = new GroupData("newgroup");
                app.Groups.Create(newgroup);
            }
            GroupData group = GroupData.GetAll()[0];



            List<AddressData> oldList = AddressData.GetAll();

            AddressData nullcontact = AddressData.GetAll().Intersect(group.GetContaracts()).FirstOrDefault();
            if (nullcontact == null)
            {
                AddressData newaddress = new AddressData("firstname" + DateTime.Now, "lastname" )
                { 
                    Group = group.Id
                }      ;
                app.Address.CreateAddress(newaddress);
                oldList.Add(newaddress);


            }
            AddressData contact = AddressData.GetAll().Intersect(group.GetContaracts()).First();

            app.Address.DeleteContactFromGroup(contact, group);

            List<AddressData> newList = AddressData.GetAll();

            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
