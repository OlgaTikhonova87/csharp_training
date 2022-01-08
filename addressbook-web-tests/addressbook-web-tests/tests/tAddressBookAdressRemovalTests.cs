using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    class AddressBookAdressRemovalTests : AuthTestBase
    {
        [Test]
        public void AddressRemovalTest()
        {
            AddressData address = new AddressData("b")
            {
                MiddleName = "MiddleName2",
                LastName = "a"
            };
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Address.CreateAddress(address);
            }
            app.Address.RemoveAddress();
        }
    }
}
