using System;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddressBookAdressCreationTests : bBaseTest
    {
        [Test]
        public void AddressCreationTest()
        {

            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Groups.InitCreation();
            AddressData address = new AddressData("First Name " + DateTime.Now)
            {
                MiddleName = "MiddleName " + DateTime.Now,
                LastName = "lastname " + DateTime.Now,
                NickName = "nickname " + DateTime.Now,
                Title = "Title " + DateTime.Now,
                Company = "Company " + DateTime.Now,
                Address = "Address " + DateTime.Now,
                HomePhone = "4556789",
                MobilePhone = "3223232",
                WorkPhone = "7686788",
                Fax = "5467657",
                Mail1 = "Mail1 " + DateTime.Now,
                Mail2 = "Mail2 " + DateTime.Now,
                Mail3 = "Mail3 " + DateTime.Now,
                HomePage = "HomePage " + DateTime.Now,
                Address2 = "address2 " + DateTime.Now,
                Phone2 = "phone2 " + DateTime.Now,
                Notes = "notes " + DateTime.Now,
                BDay = DateTime.Now.Day.ToString(),
                BMonth = "April",
                BYear = (DateTime.Now.Year - 30).ToString(),
                ADay = DateTime.Now.Day.ToString(),
                AMonth = "May",
                AYear = (DateTime.Now.Year - 1).ToString(),
                Group = "GroupName 03.12.2021 18:06:39",
                Photo = "C:\\fakepath\\95384925.jpg"
            };
            app.Address.FillAddressForm(address);
            app.Groups.Submit();
            app.Auth.Logout();
        }
       
    }
}

