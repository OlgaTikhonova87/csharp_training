using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestGridAndEditContactInformation()
        {
            AddressData fromTable = app.Address.GetContractInformationFromTable(0);
            AddressData fromEditForm = app.Address.GetContractInformationFromForm(0);
            Assert.AreEqual(fromEditForm, fromTable);
            Assert.AreEqual(fromEditForm.Address, fromTable.Address);
            Assert.AreEqual(fromEditForm.AllPhones, fromTable.AllPhones);
            Assert.AreEqual(fromEditForm.AllMails, fromTable.AllMails);
        }
        [Test]
        public void TestDetailsAndEditContactInformation()
        {
            AddressData fromEdit = app.Address.GetContractInformationFromForm(0);
            string fromDetails = app.Address.GetContractInformationFromDetails(0);
            string concatededitstring = fromEdit.AllInformation;
            Assert.AreEqual(fromDetails, concatededitstring);
        }
    }
}
