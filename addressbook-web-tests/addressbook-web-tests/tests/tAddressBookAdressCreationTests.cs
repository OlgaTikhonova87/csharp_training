using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressBookAdressCreationTests : AuthTestBase
    {
        public static IEnumerable<AddressData> RandomAddressProvider()
        {
            List<AddressData> address = new List<AddressData>();
            for (int i = 0; i < 5; i++)
            {
                address.Add(new AddressData(GenerateRandomString(10), GenerateRandomString(10))
                {
                    MiddleName = GenerateRandomString(10),
                    Address = GenerateRandomString(10),
                    Phone2 = GenerateRandomString(10),
                    NickName = GenerateRandomString(10),
                    Address2 = GenerateRandomString(10),
                    Mail1 = GenerateRandomString(10),
                    WorkPhone = GenerateRandomString(10),
                    HomePhone = GenerateRandomString(10),
                    Mail2 = GenerateRandomString(10),
                    Mail3 = GenerateRandomString(10)
                });
            }
            return address;
        }
        public static IEnumerable<AddressData> ContactDataFromXmlFile()
        {
            return (List<AddressData>)
                new XmlSerializer(typeof(List<AddressData>))
                .Deserialize(new StreamReader(@"add1.xml"));

        }
        public static IEnumerable<AddressData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<AddressData>>
                (File.ReadAllText(@"add1.json"));

        }
        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void AddressCreationTest(AddressData address)
        {
            List<AddressData> oldAddress = app.Address.GetAddressList();
            app.Address.CreateAddress(address);
            Assert.AreEqual(oldAddress.Count + 1, app.Address.GetAddressCount());
            List<AddressData> newAddress = app.Address.GetAddressList();
            oldAddress.Add(address);
            oldAddress.Sort();
            newAddress.Sort();
           // Assert.AreEqual(oldAddress, newAddress);

        }
       
    }
}

