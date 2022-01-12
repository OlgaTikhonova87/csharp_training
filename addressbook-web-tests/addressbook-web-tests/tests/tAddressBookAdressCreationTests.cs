using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressBookAdressCreationTests : AuthTestBase
    {
        [Test]
        public void AddressCreationTest()
        {
            AddressData address = new AddressData("First Name " + DateTime.Now, "lastname " + DateTime.Now)
            //{
            //    MiddleName = "MiddleName " + DateTime.Now,
            //   NickName = "nickname " + DateTime.Now,
            //    Title = "Title " + DateTime.Now,
            //    Company = "Company " + DateTime.Now,
            //    Address = "Address " + DateTime.Now,
            //    HomePhone = "4556789",
            //    MobilePhone = "3223232",
            //    WorkPhone = "7686788",
            //    Fax = "5467657",
            //}
            ;

            List<AddressData> oldAddress = app.Address.GetAddressList();
            app.Address.CreateAddress(address);
            Assert.AreEqual(oldAddress.Count + 1, app.Address.GetAddressCount());
            List<AddressData> newAddress = app.Address.GetAddressList();
            oldAddress.Add(address);
            oldAddress.Sort();
            newAddress.Sort();
            Assert.AreEqual(oldAddress, newAddress);

        }
       
    }
}

