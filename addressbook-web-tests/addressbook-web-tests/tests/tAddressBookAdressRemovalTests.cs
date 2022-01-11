using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    class AddressBookAdressRemovalTests : AuthTestBase
    {
        [Test]
        public void AddressRemovalTest()
        {
            AddressData address = new AddressData("b", "a")
            {
                MiddleName = "MiddleName2"
            };
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Address.CreateAddress(address);
            }
            List<AddressData> oldAddress = app.Address.GetAddressList();
            app.Address.RemoveAddress();
            Assert.AreEqual(oldAddress.Count - 1, app.Address.GetAddressCount());
            List<AddressData> newAddress = app.Address.GetAddressList();
            oldAddress.RemoveAt(0);
            oldAddress.Sort();
            newAddress.Sort();
            Assert.AreEqual(oldAddress, newAddress);
        }
    }
}
