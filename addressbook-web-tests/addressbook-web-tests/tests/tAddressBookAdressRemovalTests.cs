using System;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class tAddressBookAdressRemovalTests : AuthTestBase
    {
        [Test]
        public void AddressModificationTest()
        {
            AddressData address = new AddressData("b")
            {
                MiddleName = "MiddleName2",
                LastName = "a"
            };
            if (!app.Address.IsAddressExist(address.lastname, address.firstname))
            {
                app.Address.CreateAddress(address);
            }
            app.Address.RemoveAddress();
        }
    }
}
