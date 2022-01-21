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

