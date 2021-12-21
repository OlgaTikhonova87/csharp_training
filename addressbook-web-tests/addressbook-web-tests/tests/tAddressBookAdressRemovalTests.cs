using System;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class tAddressBookAdressRemovalTests : bBaseTest
    {
        [Test]
        public void AddressModificationTest()
        {
            app.Address.RemoveAddress("34");
        }
    }
}
