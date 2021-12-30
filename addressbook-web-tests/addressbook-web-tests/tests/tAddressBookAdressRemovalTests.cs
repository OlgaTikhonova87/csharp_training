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
            app.Address.RemoveAddress(address);
        }
    }
}
