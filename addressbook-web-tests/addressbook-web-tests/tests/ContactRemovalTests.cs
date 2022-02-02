using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    class AddressBookAdressRemovalTests : AddressTestBase
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
            List<AddressData> oldAddress = AddressData.GetAllContacts();
            AddressData toBeRemoved = oldAddress[0];
            app.Address.RemoveAddress(toBeRemoved);
            Assert.AreEqual(oldAddress.Count - 1, app.Address.GetAddressCount());
            List<AddressData> newAddress = AddressData.GetAllContacts();
            oldAddress.RemoveAt(0);
            oldAddress.Sort();
            newAddress.Sort();
            //Assert.AreEqual(oldAddress, newAddress);
        }
    }
}
