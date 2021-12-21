﻿using System;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class tAddressBookAdressModificationTests : bBaseTest
    {
        [Test]
        public void AddressModificationTest()
        {
            AddressData address = new AddressData("First Name " + DateTime.Now)
            {
                MiddleName = "MiddleName2 " + DateTime.Now,
                LastName = "lastname2 " + DateTime.Now,
                NickName = "nickname2 " + DateTime.Now,
                Title = "Title2 " + DateTime.Now,
                Company = "Company2 " + DateTime.Now,
                Address = "Address2 " + DateTime.Now,
                HomePhone = "45567892",
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
            app.Address.ModifyAddress(7, address);

        }
    }
}
