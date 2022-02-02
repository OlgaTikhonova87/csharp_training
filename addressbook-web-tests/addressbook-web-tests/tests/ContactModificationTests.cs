using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    class AddressBookAdressModificationTests : AuthTestBase
    {
        [Test]
        public void AddressModificationTest()
        {
            AddressData address = new AddressData("uuu", "gggg");

            AddressData oldaddress = new AddressData("a", "b")
            {
                MiddleName = "MiddleName2 " + DateTime.Now,
                NickName = "nickname2 " + DateTime.Now
            };
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Address.CreateAddress(address);
            }

            List<AddressData> oldAddress = app.Address.GetAddressList();
            AddressData toBeEdit = oldAddress[0];
            app.Address.ModifyAddress(toBeEdit);
            Assert.AreEqual(oldAddress.Count, app.Address.GetAddressCount());
            List<AddressData> newAddress = AddressData.GetAllContacts();
            oldAddress[1].FirstName = address.FirstName;
            oldAddress[1].LastName = address.LastName;
            oldAddress.Sort();
            newAddress.Sort();
         //   Assert.AreEqual(oldAddress, newAddress);
        }
    }
}
