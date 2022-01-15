using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            AddressData fromTable = app.Address.GetContractInformationFromTable(0);
            AddressData fromForm = app.Address.GetContractInformationFromForm(0);
            Assert.AreEqual(fromForm, fromTable);
            Assert.AreEqual(fromForm.Address, fromTable.Address);
            Assert.AreEqual(fromForm.AllPhones, fromTable.AllPhones);
        }
    }
}
