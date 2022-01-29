﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{

    public class AddressTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareAddressUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<AddressData> fromUI = app.Address.GetAddressList();
                List<AddressData> fromDB = AddressData.GetAllContacts();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
